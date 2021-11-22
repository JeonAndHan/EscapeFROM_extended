using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Mouse_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Mouse_UI.gameObject.SetActive(true);
            b_PlayerLock = true;
        }
        else
        {
            m_Mouse_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
