using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zomebie_Mouse_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Zombie_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Zombie_UI.gameObject.SetActive(true);
            b_PlayerLock = true;
        }
        else
        {
            m_Zombie_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
