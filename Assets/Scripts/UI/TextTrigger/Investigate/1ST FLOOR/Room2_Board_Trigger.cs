using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Board_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Room2_Board_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Room2_Board_UI.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else
        {
            m_Room2_Board_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
