using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimCtrl : AnimCtrl
{
    public enum eAnimState
    {
        IDLE,
        RUN,
        ATTACK,
        DIE,
        MAX
    }
    eAnimState m_state;
    Dictionary<int, eAnimState> m_dicAnimState = new Dictionary<int, eAnimState>();

    public eAnimState GetAnimState()
    {
        return m_state;
    }

    public eAnimState GetAnimState(eAnimState state)
    {
        int hash = GetAnimHash(state);
        return m_dicAnimState[hash];
    }

    public int GetAnimHash(eAnimState state)
    {
        return Animator.StringToHash(state.ToString());
    }

    public void Play(eAnimState animState, bool isFade = true)
    {
        m_state = animState;
        base.Play(animState.ToString(), isFade);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<(int)eAnimState.MAX; i++)
        {
            m_dicAnimState.Add(Animator.StringToHash(((eAnimState)i).ToString()), (eAnimState)i);
        }
    }

    
}
