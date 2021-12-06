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

    [SerializeField]
    private float m_maxHP;
    public float m_currentHP;
    public bool m_isDead;
    public bool m_isHit = false;

    public LayerMask m_layerMask;

    // Start is called before the first frame update
    protected void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<CapsuleCollider>();
        m_nav = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_currentHP = m_maxHP;
        StartCoroutine(CalcCoolTime());
    }

    public void Hit(float damage)
    {
        if (m_currentHP > 0)
        {
            m_currentHP -= damage;
            m_isHit = true;
            m_Anim.SetTrigger("HIT");
        }

        if (m_currentHP <= 0 && !m_isDead)
        {
            m_Anim.SetTrigger("DEATH");
            m_isDead = true;
            m_collider.isTrigger = true;
            m_isHit = false;
            StopAllCoroutines();
        }
    }

    protected bool CanAttackState()
    {
        distance = Vector3.Distance(m_player.transform.position, transform.position);

        if ( distance <= attackRange )
            return true;
        else
            return false;
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