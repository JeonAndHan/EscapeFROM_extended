using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_PW_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Room2_PW_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Room2_PW_UI.gameObject.SetActive(true);
        }
        else
        {
            m_Room2_PW_UI.gameObject.SetActive(false);
        }
    }
}
