using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int bulletsPerMag; //한 탄창의 탄환 수
    [SerializeField]
    private int bulletsTotal; // 잔여 탄환 개수
    [SerializeField]
    private int currentBullets; // 현재 장전된 탄환의 수
    [SerializeField]
    private float range; // 총의 사거리
    [SerializeField]
    private float fireRate; // 발사간격

    private float fireTimer;

    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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

        Debug.Log("Shot Fired");
        RaycastHit hit;
        if(Physics.Raycast(shootPoint.position, shootPoint.transform.up, out hit, range))
        {
            Debug.Log("Hit");
        }

        currentBullets--;
        fireTimer = 0.0f;
    }
}
