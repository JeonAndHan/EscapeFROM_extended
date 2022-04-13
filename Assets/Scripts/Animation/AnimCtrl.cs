using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    Animator m_Anim;
    string m_prevTriggerName;

    public AnimatorClipInfo[] GetAnimatorClipInfo()
    {
        //현재 상태에 의해 재생되는 AnimatorClipInfo의 목록을 가져옴
        return m_Anim.GetCurrentAnimatorClipInfo(0);
    }

    public float GetPlayTime(string animTriggerName)
    {
        var stateInfo = m_Anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(animTriggerName))
        {
            var length = stateInfo.length;
            return stateInfo.normalizedTime * length;
        }
        return 0f;
    }

    public void Stop()
    {
        Debug.Log("Stop");
        m_Anim.speed = 0f;
    }
    public void Resume()
    {
        Debug.Log("Resume");
        m_Anim.speed = 1f;
    }

    public float GetAnimationClipLength(string animClipName)
    {
        var ac = m_Anim.runtimeAnimatorController;
        var clips = ac.animationClips;
        for(int i=0; i<clips.Length; i++)
        {
            if (clips[i].name.Equals(animClipName))
            {
                return clips[i].length;
            }
        }
        return 0f;
    }

    public void Play(string animTriggerName, bool isFade = true)
    {
        //true 매개 변수가 value이거나 빈 문자열("")이면 null이고, 그러지 않으면 false
        if (!string.IsNullOrEmpty(m_prevTriggerName))
        {
            m_Anim.ResetTrigger(m_prevTriggerName);
            m_prevTriggerName = string.Empty;
        }

        if (isFade)
        {
            m_Anim.SetTrigger(animTriggerName);
            m_prevTriggerName = animTriggerName;
        }
        else
        {
            m_Anim.Play(animTriggerName, 0, 0f);
        }
    }

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        m_prevTriggerName = string.Empty;
    }




}
