using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Statue_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("Sound")]
    SoundManager Sound;
    EffectManager Effect;

    private void Start()
    {
        Sound = FindObjectOfType<SoundManager>();
        Effect = FindObjectOfType<EffectManager>();
    }

    private void Update()
    {

        if (ingameCtrl.m_pressR & b_textTrigger)
        {
            Effect.EffectPlay(6);
            m_Investigate_text.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }
}
