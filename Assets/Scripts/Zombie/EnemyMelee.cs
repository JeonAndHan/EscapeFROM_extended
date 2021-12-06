using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    private EnemyBossZombie m_boss;
    private EnemyZombie m_zombie;
    private player m_Target;
    private MonsterAnimCtrl m_animCtrl; //

    public enum State
    {
        IDLE,
        WALK,
        ATTACK,
        DEATH,
        HIT,
    };

    public ZombieTrigger m_zombieTrigger;

    public State currentState = State.IDLE;
    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    EffectManager Effect;
    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        m_boss = gameObject.GetComponent<EnemyBossZombie>();
        m_zombie = gameObject.GetComponent<EnemyZombie>();
        StartCoroutine(FSM());
        Effect = FindObjectOfType<EffectManager>();
        m_animCtrl = GetComponent<MonsterAnimCtrl>();
    }

    protected virtual IEnumerator FSM()
    {
        yield return null;
        //player가 방을 벗어나지 않았다면 idle 상태로 대기
        while (!m_zombieTrigger.m_Trigger)
        {
            yield return Delay250;
        }

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());

        }
    }


    protected virtual IEnumerator IDLE()
    {
        yield return null;
        m_isHit = false;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("IDLE"))
        {
            m_Anim.SetTrigger("IDLE");
        }

        if (CanAttackState())
        {
            if (canAttack && !m_isHit)
            {
                currentState = State.ATTACK;
            }
            else
            {
                currentState = State.IDLE;
                transform.LookAt(m_player.transform.position);
            }
        }
        else if(distance < 15f && !(currentState==State.HIT))
        {
            currentState = State.WALK;
        }
        else
        {
            currentState = State.IDLE;
        }
    }

    protected virtual IEnumerator ATTACK()
    {
        yield return null;
        m_isHit = false;

        m_nav.stoppingDistance = 2f;
        m_nav.isStopped = true;

        m_nav.isStopped = false;
        canAttack = false;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACK"))
        {
            Debug.Log("Attack Anim");
            m_Anim.SetTrigger("ATTACK");
            if (this.gameObject.CompareTag("BossZombie"))
            {
                m_Target = m_player.GetComponent<player>();
                m_Target.Hit(20);
                Effect.EffectPlay(1);
            }
            else if (this.gameObject.CompareTag("Zombie"))
            {
                m_Target = m_player.GetComponent<player>();
                m_Target.Hit(10);
                Effect.EffectPlay(0);
            }

        }
        yield return Delay500;

        m_nav.speed = 2f;
        m_nav.stoppingDistance = attackRange;
        currentState = State.IDLE;

    }

    protected virtual IEnumerator WALK()
    {
        m_isHit = false;
        yield return null;

        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("WALK"))
        {
            m_Anim.SetTrigger("WALK");
        }

        if(CanAttackState() && canAttack)
        {
            currentState = State.ATTACK;
        }
        else if(distance > 15f)
        {
            m_nav.SetDestination(transform.position - Vector3.forward*5f);
        }
        else
        {
            m_nav.SetDestination(m_player.transform.position);
        }
    }

}
