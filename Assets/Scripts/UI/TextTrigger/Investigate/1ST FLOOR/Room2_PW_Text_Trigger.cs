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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             if (ingameCtrl.m_pressR)
        {
            m_Room2_PW_UI.gameObject.SetActive(true);
            ingameCtrl.cursorTrue();
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        }
    }

    private void ontriggerexit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Room2_PW_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
            ingameCtrl.cursorFalse();
        }
    }
}
