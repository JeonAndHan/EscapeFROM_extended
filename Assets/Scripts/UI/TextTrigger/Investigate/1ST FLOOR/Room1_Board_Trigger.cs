using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_Board_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Room1_Board_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Room1_Board_UI.gameObject.SetActive(true);
            b_PlayerLock = true;
        }
        else
        {
            m_Room1_Board_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
