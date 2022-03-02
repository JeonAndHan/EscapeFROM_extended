using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrayerRoom_Safe_TextTrigger : TextTrigger
{
    //Todo
    //1. 트리거에 들어가면 investigate 알림 메세지 나와야함.
    //2. 알림 메세지대로 R 누르면 key pad 나와서 pw 맞춰야함.
    //3. 맞추면 door effect, acquire 메세지 나와야함 -> key pad ctrl에서 해줌
    //4. acquire했다면 알림 메세지 다 끄기.

    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private GameObject m_Player_Axe;

    [SerializeField]
    private GameObject m_Safe_Axe;

    public player playerCtrl;

    [SerializeField]
    private TextMeshProUGUI m_Acquire_text;

    [Header("TextTriggerUI")]
    public GameObject m_Safe_UI;

    //금고 pw 관리 스크립트
    public keyPadCtrl m_keypad;



    private void Update()
    {
        //text 트리거에 있고, R 버튼을 눌렀다면
        if (ingameCtrl.m_pressR && b_textTrigger && !m_Player_Axe.gameObject.activeInHierarchy)
        {
            m_Safe_UI.gameObject.SetActive(true);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;
        }
        else
        {
            m_Safe_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }

        //키패드가 맞았고 트리거에 있고, 도끼가 플레이어한테 없다면
        if (m_keypad.m_right && b_textTrigger && !m_Player_Axe.gameObject.activeInHierarchy)
        {
            Debug.Log("Acquire text");
            m_Acquire_text.gameObject.SetActive(true);
            m_Acquire_text.text = "Press " + "<color=yellow>" + "'Z'" + "</color>" + " to aquire " + "Axe";
            m_Investigate_text.gameObject.SetActive(false);

            if (ingameCtrl.m_pressZ)
            {
                m_Player_Axe.SetActive(true);
                m_Safe_Axe.SetActive(false);
                playerCtrl.b_getAxe = true;
                m_Acquire_text.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
