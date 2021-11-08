using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int bulletsPerMag; //한 탄창의 탄환 수
    public int bulletsTotal; // 잔여 탄환 개수
    public int currentBullets; // 현재 장전된 탄환의 수
    [SerializeField]
    private float range; // 총의 사거리
    [SerializeField]
    private float fireRate; // 발사간격
    public TextMeshProUGUI m_bullet_info_text;  //총알 개수 UI
    public GameObject m_Gun_UI;
    public GameObject m_Gun;
    public bool b_canFire;

    private float fireTimer = 0f;

    public Transform shootPoint;

    [SerializeField]
    private InventoryObject inventory;

    [SerializeField]
    private ItemObject GunItem;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
        m_bullet_info_text.text = currentBullets + "/" + bulletsTotal;
        fireTimer = 0f;
        b_canFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Gun.activeInHierarchy)
        {
            m_Gun_UI.SetActive(true);
        }
        else
        {
            m_Gun_UI.SetActive(false);
        }

        if (Input.GetMouseButton(0) && this.gameObject.activeInHierarchy)
        {
            if (currentBullets > 0)
            {
                Fire();
                b_canFire = true;
            }
            else
            {
                b_canFire = false;
            }

            if (fireTimer < fireRate)
                fireTimer += Time.deltaTime;
            else
                fireTimer = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fireTimer = 0f;
        }
    }

    public void Reload()
    {
        int bulletsToReload = bulletsPerMag - currentBullets;
        if (bulletsToReload > bulletsTotal)
            bulletsToReload = bulletsTotal;

        currentBullets += bulletsToReload;
        bulletsTotal -= bulletsToReload;
        m_bullet_info_text.text = currentBullets + " / " + bulletsTotal; 
    }

    private void Fire()
    {
        if (fireTimer < fireRate)
            return;        

        Debug.Log("Shot Fired");
        RaycastHit hit;
        if(Physics.Raycast(shootPoint.position, shootPoint.transform.up, out hit, range))
        {
            if (hit.collider.gameObject.CompareTag("BossZombie")|| hit.collider.gameObject.CompareTag("Zombie"))
            {
                hit.collider.gameObject.SendMessage("Hit", 80);
                Debug.Log("Hit");
            }            
            Debug.Log("hit" + hit.collider.gameObject.name);
        }

        currentBullets--;
        fireTimer = 0.0f;
        m_bullet_info_text.text = currentBullets + "/" + bulletsTotal;
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = shootPoint.transform.up * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
