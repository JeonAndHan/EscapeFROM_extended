﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Statue_Trigger2 : TextTrigger
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
            Effect.EffectPlay(7);
        }

    }
}
