using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrayerRoom_Safe_TextTrigger : TextTrigger
{
    //Todo
    //1. Ʈ���ſ� ���� investigate �˸� �޼��� ���;���.
    //2. �˸� �޼������ R ������ key pad ���ͼ� pw �������.
    //3. ���߸� door effect, acquire �޼��� ���;��� -> key pad ctrl���� ����
    //4. acquire�ߴٸ� �˸� �޼��� �� ����.

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

    //�ݰ� pw ���� ��ũ��Ʈ
    public keyPadCtrl m_keypad;



    private void Update()
    {
        //text Ʈ���ſ� �ְ�, R ��ư�� �����ٸ�
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

        //Ű�е尡 �¾Ұ� Ʈ���ſ� �ְ�, ������ �÷��̾����� ���ٸ�
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
