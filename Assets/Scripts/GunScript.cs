using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int bulletPerMag; //한 탄창의 탄환수
    public int bulletsTotal; //잔여 탄환 개수
    public int currentBullets; //현재 장전된 탄환의 수
    public float range; //총의 사거리
    public float fireRate; //발사 간격
    private float fireTimer; //발사 시간 조정
    [SerializeField]
    private float m_bulletDamage;
    
    public Transform m_BulletPos; //총알이 발사되는 지점
   

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            if (currentBullets > 0)
                Fire();
        }

        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void Fire()
    {
        if (fireTimer < fireRate)
            return;

        Debug.Log("Shoot Fired");
        RaycastHit hit;
        if (Physics.Raycast(m_BulletPos.position, m_BulletPos.transform.up, out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name + "hit");
            if (hit.collider.gameObject.CompareTag("BossZombie") || hit.collider.gameObject.CompareTag("Zombie"))
            {
                hit.collider.gameObject.SendMessage("Hit", m_bulletDamage);
                Debug.Log(hit.collider.gameObject.name + "hit");
            }

        }
        currentBullets--;
        fireTimer = 0.0f;
    }
}
