using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Statue_Text_Trigger3 : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private GameObject m_Trick;

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
            Effect.EffectPlay(8);
            m_Trick.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }
}
