using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingDoorCtrl : MonoBehaviour
{
    public EnemyMelee[] m_zombie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allZombieDead();   
    }

    private void allZombieDead()
    {
        //모든 좀비가 죽었다면
        if (m_zombie[0].m_currentHP <= 0 && m_zombie[1].m_currentHP <= 0 && m_zombie[2].m_currentHP <= 0
            && m_zombie[3].m_currentHP <= 0 && m_zombie[4].m_currentHP <= 0)
        {
            this.gameObject.transform.localEulerAngles = new Vector3(0, 170, 0);
        }
    }
}
