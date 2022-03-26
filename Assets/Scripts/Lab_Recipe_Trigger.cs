using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Recipe_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Lab_Recipe_UI;

    // Update is called once per frame
    private void Update()
    {
        if(ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Lab_Recipe_UI.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else
        {
            m_Lab_Recipe_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }
}
