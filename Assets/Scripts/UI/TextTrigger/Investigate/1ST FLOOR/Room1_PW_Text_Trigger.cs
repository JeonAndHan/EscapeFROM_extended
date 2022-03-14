using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_PW_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    public Room1Pw m_room1_pw;

    [Header("TextTriggerUI")]
    public GameObject m_PW_UI;

    private void Update()
    {
        //R을 눌렀고 텍스트 트리거에 들어갔고, 비밀번호를 맞추지 못했다면 UI 띄우기
        if (ingameCtrl.m_pressR && b_textTrigger && !m_room1_pw.m_right)
        {
            m_PW_UI.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else
        {
            m_PW_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }

        if (m_room1_pw.m_right)
        {
            this.gameObject.SetActive(false);
            m_Investigate_text.gameObject.SetActive(false);
        }
    }
}
