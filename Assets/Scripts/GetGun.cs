using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetGun : MonoBehaviour
{

    //Todo
    //
    //1. 매니저를 암살하지 않고 총을 가져갔을 시에 gameover
    //2. 매니저를 암살하고 총을 습득했을 때 player의 총 active true

    SphereCollider m_collider;

    [SerializeField]
    private player playerCtrl;

    [SerializeField]
    private TextMeshProUGUI acquire_text;

    [SerializeField]
    private Manager_Assassinate_Trigger manager_assassinate_trigger;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private GameObject player_Gun;

    [SerializeField]
    private Image BlackOut;

    [SerializeField]
    private AudioSource gunfire_sound;

    public bool player_die_2ndfloor;

    private Slot slot;

    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<SphereCollider>();
        slot = FindObjectOfType<Slot>();

    }

    // Update is called once per frame
    void Update()
    {
        //총을 획득하고 && 이층으로 진입했다면  && slot.b_secondFloor_DoorOpen
        if (ingameCtrl.m_pressZ && acquire_text.gameObject.activeInHierarchy && ingameCtrl.b_secondFloor_DoorOpen)
        {
            Debug.Log("Z를 누르고 텍스트 떠있고 2층 문이 열렸다면");
            //매니저가 죽었다면
            if (manager_assassinate_trigger.b_manager_dead)
            {
                player_Gun.gameObject.SetActive(true);
                playerCtrl.b_getGun = true;
                acquire_text.gameObject.SetActive(false);

                if (playerCtrl.b_getAxe)
                {
                    ingameCtrl.toggleTextTrue();
                }

                //총을 얻고 도끼가 켜져있다면 Axe는 꺼두기
                if (playerCtrl.m_Axe.activeInHierarchy)
                {
                    playerCtrl.m_Axe.SetActive(false);
                }

                this.gameObject.SetActive(false);
            }
            else
            {
                //매니저가 플레이어를 쳐다보고 화면이 검어지고 총소리 들리면서 game over
                player_die_2ndfloor = true;
                StartCoroutine(blackOut_coroutine());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           acquire_text.gameObject.SetActive(true);
            Debug.Log("player enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            acquire_text.gameObject.SetActive(false);
            Debug.Log("player exit");
        }
    }

    IEnumerator blackOut_coroutine()
    {
        WaitForSeconds two = new WaitForSeconds(2f);
        yield return two;
        if (!gunfire_sound.isPlaying)
        {
            gunfire_sound.Play();
        }
        BlackOut.gameObject.SetActive(true);
        playerCtrl.gameover_fun();
    }

}
