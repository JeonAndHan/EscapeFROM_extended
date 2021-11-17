using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room1_Safe_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private GameObject m_Player_Axe;

    [SerializeField]
    private GameObject m_Safe_Axe;

    [SerializeField]
    private TextMeshProUGUI m_Acquire_text;

    [Header("TextTriggerUI")]
    public GameObject m_Safe_UI;

    //금고 pw 관리 스크립트
    public keyPadCtrl m_keypad;

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Safe_UI.gameObject.SetActive(true);
        }
        else
        {
            m_Safe_UI.gameObject.SetActive(false);
        }

        if (m_keypad.m_right && b_textTrigger && !m_Player_Axe.gameObject.activeInHierarchy)
        {
            m_Acquire_text.gameObject.SetActive(true);

            if (ingameCtrl.m_pressZ)
            {
                m_Player_Axe.SetActive(true);
                m_Safe_Axe.SetActive(false);
                m_Acquire_text.gameObject.SetActive(false);
            }
        }
    }


    // 문열리는 effect 추가
}
