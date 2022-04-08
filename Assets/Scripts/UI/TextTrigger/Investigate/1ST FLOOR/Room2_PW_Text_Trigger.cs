using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_PW_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    // [SerializeField]
    // private Room2PW Room2_PW_Ctrl;

    [Header("TextTriggerUI")]
    public GameObject m_Room2_PW_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Room2_PW_UI.gameObject.SetActive(true);
            ingameCtrl.cursorTrue();
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else if(!b_textTrigger)
        {
            m_Room2_PW_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
            ingameCtrl.cursorFalse();
        }

        // if (Room2_PW_Ctrl.m_right)
        // {
        //     m_Investigate_text.gameObject.SetActive(false);
        //     m_Room2_PW_UI.gameObject.SetActive(false);
        //     this.gameObject.SetActive(false);
        // }
    }
}
