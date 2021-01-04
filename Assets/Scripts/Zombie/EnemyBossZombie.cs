using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossZombie : EnemyMelee
{
    public GameObject meleeAttackArea;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        attackCoolTime = 3f;
        attackCoolTimeCacl = attackCoolTime;

        attackRange = 3f;
        m_nav.stoppingDistance = 2f;
        StartCoroutine(ResetAttackArea());

    }


    IEnumerator ResetAttackArea()
    {
        while (true)
        {
            yield return null;
            if (!meleeAttackArea.activeInHierarchy && currentState == State.ATTACK)
            {
                yield return new WaitForSeconds(attackCoolTime);
                meleeAttackArea.SetActive(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(currentState == State.DEATH)
        {
            StopAllCoroutines();
        }
    }

}
