using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prayerRoom_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Prayer_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Prayer_UI.gameObject.SetActive(true);
        }
        else
        {
            m_Prayer_UI.gameObject.SetActive(false);
        }
    }
}
