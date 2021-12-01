using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("player변수")]
    [SerializeField]
    float m_speed;
    [SerializeField]
    float m_runSpeed;
    [SerializeField]
    Vector3 m_dir;
    private bool m_isDead = false;

    Rigidbody m_rigidbody;
    CapsuleCollider m_collider;
    Animator m_Anim;
    private int m_JumpCount = 0;
    private bool m_isRun;
    private bool m_isGunWithRun;

    public Computer_Text_Trigger computer_text_Trigger;
    public IngameCtrl ingameCtrl;

    [Header("ShortCape변수")]
    public bool m_wearCape;
    [SerializeField]
    GameObject m_ShortCape;


    [Header("Weapon변수")]
    [SerializeField]
    GameObject m_handAttackArea;
    [SerializeField]
    GameObject m_weaponAttackArea;
    public GameObject m_player_weapon;
    public bool m_is_Weapon_attack = false;
    private float m_weapon_Damage = 50f;
    private float m_hand_Damage = 20f;

    [Header("camera변수")]
    public Camera m_camera;
    public Transform m_cameraArm;
    private float m_lookSensitivity = 1.3f;
    private float m_cameraRotationLimit = 38f;
    private float m_currentCameraRotationX;

    [Header("playerHP변수")]
    [SerializeField]
    private float m_maxHP;
    private float m_currentHP;
    EffectManager Effect;
    SoundManager Sound;

    [Header("GUN변수")]
    [SerializeField]
    public GameObject m_Gun;
    [SerializeField]
    private Weapon m_weaponScript;

    [Header("Inventory 변수")]
    [SerializeField]
    ActionController m_actionController;
  //  public InventoryObject inventory;
    public bool b_itemTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<CapsuleCollider>();
        m_Anim = GetComponent<Animator>();

        m_currentHP = m_maxHP;
        UICtrl.Instance.showHp(m_currentHP, m_maxHP);
        Effect = FindObjectOfType<EffectManager>();
        Sound = FindObjectOfType<SoundManager>();

    }

    public void Hit(float damage)
    {
        if (!m_isDead)
        {
            m_currentHP -= damage;
            UICtrl.Instance.showHp(m_currentHP, m_maxHP);
            if (m_currentHP <= 0)
            {
                m_Anim.SetTrigger("DIE");
                m_isDead = true;
                Sound.Stop();
                Effect.EffectPlay(1);
                StartCoroutine(gameover());
            }
        }
    }

    public void attackTarget(GameObject target)
    {

        if (m_player_weapon.activeInHierarchy) //player가 무기를 들고있다면
        {
            target.SendMessage("Hit", m_weapon_Damage);
        }
        else //player가 맨손이라면
        {
            target.SendMessage("Hit", m_hand_Damage);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (computer_text_Trigger.m_explosion_true && !m_isDead)
        {
            m_Anim.SetTrigger("DIE");
            m_isDead = true;
        }

        if (!m_isDead)
        {
            if (!m_actionController.playerLock)
            {
                if (!ingameCtrl.m_pressR)
                {
                    Move();
                    camera_Rotation();
                    character_Rotation();
                }

                if (Input.GetMouseButton(0) && !ingameCtrl.m_pressR)
                {

                    if (m_player_weapon.activeInHierarchy)
                    {
                        m_Anim.SetBool("WEAPONATTACK", true);
                        m_Anim.SetBool("WALK", false);
                        m_is_Weapon_attack = true;
                        Effect.EffectPlay(2);
                    }
                    else if (m_Gun.activeInHierarchy)
                    {
                        m_Anim.SetBool("SHOOT", true);
                        m_Anim.SetBool("WALK", false);
                    }
                    else
                    {
                        m_Anim.SetBool("ATTACK", true);
                        m_is_Weapon_attack = false;
                    }

                }
                else
                {
                    if (m_player_weapon.activeInHierarchy)
                    {
                        m_Anim.SetBool("WEAPONATTACK", false);
                        // m_weaponAttackArea.SetActive(false);
                    }
                    else if (m_Gun.activeInHierarchy)
                    {
                        m_Anim.SetBool("SHOOT", false);
                    }
                    else
                    {
                        m_Anim.SetBool("ATTACK", false);
                        //m_handAttackArea.SetActive(false);
                    }

                }

                if (Input.GetKey(KeyCode.Z) && !ingameCtrl.m_pressR)
                {
                    m_Anim.SetBool("PICKUP", true);
                }
                else
                {
                    m_Anim.SetBool("PICKUP", false);
                }

                if (m_JumpCount < 1 && Input.GetButtonDown("Jump") && !ingameCtrl.m_pressR)
                {
                    m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 6, m_rigidbody.velocity.z);
                    m_JumpCount++;
                }
                m_Anim.SetFloat("JUMP", m_rigidbody.velocity.y);

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (m_Gun.activeInHierarchy)
                    {
                        m_isGunWithRun = true;
                    }
                    else
                    {
                        m_isRun = true;
                    }
                }

                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    if (m_Gun.activeInHierarchy)
                    {
                        m_isGunWithRun = false;
                    }
                    else
                    {
                        m_isRun = false;
                    }
                }
            }
        }
    }


    public void AttackAreaTrue()
    {
        if (m_player_weapon.activeInHierarchy)
        {
            m_weaponAttackArea.SetActive(true);
        }
        else
        {
            m_handAttackArea.SetActive(true);
        }
    }

    public void AttackAreaFalse()
    {
        if (m_player_weapon.activeInHierarchy)
        {
            m_weaponAttackArea.SetActive(false);
        }
        else
        {
            m_handAttackArea.SetActive(false);
        }
    }

    void character_Rotation()
    {
        float YRotation = Input.GetAxisRaw("Mouse X");
        Vector3 charRotationY = new Vector3(0, YRotation, 0) * m_lookSensitivity;
        m_rigidbody.MoveRotation(m_rigidbody.rotation * Quaternion.Euler(charRotationY));
    }

    void camera_Rotation()
    {
        float XRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = XRotation * m_lookSensitivity;
        m_currentCameraRotationX -= cameraRotationX;
        m_currentCameraRotationX = Mathf.Clamp(m_currentCameraRotationX, -m_cameraRotationLimit, m_cameraRotationLimit);

        m_camera.transform.localEulerAngles = new Vector3(m_currentCameraRotationX, 0, 0);
    }

    private void Move()
    {

        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;
        Vector3 m_velocity = (moveHorizontal + moveVertical).normalized * m_speed;

        //벡터의 크기가 달라서 속도 차이? -> .normalize

        bool isMove = false;

        if (moveDirX != 0 || moveDirZ != 0)
        {
            isMove = true;
            m_Anim.SetBool("IDLE", false);
        }
        else
        {
            isMove = false;
            m_Anim.SetBool("IDLE", true);
            m_Anim.SetBool("WALK", false);
            m_Anim.SetBool("RUN", false);
            m_Anim.SetBool("RUNWITHGUN", false);

        }


        if (isMove)
        {
            m_Anim.SetBool("IDLE", false);

            m_rigidbody.MovePosition(transform.position + m_velocity * Time.deltaTime);


            if (m_isRun && !m_Gun.activeInHierarchy) //총 없이 달리는것
            {
                m_Anim.SetBool("RUN", true);
                m_Anim.SetBool("RUNWITHGUN", false);
                m_Anim.SetBool("WALK", false);
                m_rigidbody.MovePosition(transform.position + (moveHorizontal + moveVertical).normalized * m_runSpeed * Time.deltaTime);
            }
            else if (m_isGunWithRun && m_Gun.activeInHierarchy) //총이 있을 때 달리는 것
            {
                m_Anim.SetBool("RUN", false);
                m_Anim.SetBool("RUNWITHGUN", true);
                m_Anim.SetBool("WALK", false);
                m_rigidbody.MovePosition(transform.position + (moveHorizontal + moveVertical).normalized * m_runSpeed * Time.deltaTime);
            }
            else  //walk
            {
                m_Anim.SetBool("RUN", false);
                m_Anim.SetBool("RUNWITHGUN", false);
                m_Anim.SetBool("WALK", isMove);
                m_rigidbody.MovePosition(transform.position + m_velocity * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_JumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            b_itemTrigger = true;
        }
    }

    IEnumerator gameover()
    {
        WaitForSeconds Delay2sec = new WaitForSeconds(2f);
        yield return Delay2sec;

        SceneManager.LoadScene("GameOver");
    }

}
