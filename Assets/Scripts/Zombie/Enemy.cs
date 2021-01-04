using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected Rigidbody m_rigidbody;
    protected CapsuleCollider m_collider;
    protected NavMeshAgent m_nav;
    protected Animator m_Anim;
    protected GameObject m_player;

    protected float attackRange = 3f;
    protected float attackCoolTime = 3f;
    protected float attackCoolTimeCacl = 3f;
    protected float distance;
    protected bool canAttack = true;

    public LayerMask m_layerMask;

    // Start is called before the first frame update
    protected void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<CapsuleCollider>();
        m_nav = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();

        StartCoroutine(CalcCoolTime());
    }

    protected bool CanAttackState()
    {
        Vector3 targetDir = new Vector3(m_player.transform.position.x - transform.position.x,
            0f, m_player.transform.position.z - transform.position.z);

        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z),
            targetDir, out RaycastHit hit, 30f, m_layerMask);

        distance = Vector3.Distance(m_player.transform.position, transform.position);

            if (hit.transform == null)
            {
                //Debug.Log("hit.transform == null");
                return false;
            }


            if (hit.transform.CompareTag("Player") && distance <= attackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
    }

    protected virtual IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            if (!canAttack)
            {
                attackCoolTimeCacl -= Time.deltaTime;
                if(attackCoolTimeCacl <= 0)
                {
                    attackCoolTimeCacl = attackCoolTime;
                    canAttack = true;
                }
            }
        }
    }


}


//몬스터 FSM 참조 : https://www.youtube.com/watch?v=3xMlYb4_ItQ