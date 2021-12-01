using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Desk_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Desk_UI.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else
        {
            m_Desk_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
