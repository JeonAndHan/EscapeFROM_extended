using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Report_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Lab_UI;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Lab_UI.gameObject.SetActive(true);
        }
        else
        {
            m_Lab_UI.gameObject.SetActive(false);
        }
    }
}
