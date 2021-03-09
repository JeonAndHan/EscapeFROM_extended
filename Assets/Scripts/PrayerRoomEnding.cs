using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerRoomEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            bool wearCape = other.gameObject.GetComponent<player>().m_wearCape;
            if (!wearCape)
            {
                //player가 cape를 안 입고 있다면 ending
            }
        }
    }
}
