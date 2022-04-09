using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_PW_Text_Trigger : MonoBehaviour
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private GameObject m_Investigate_text;

    [Header("TextTriggerUI")]
    public GameObject m_Room2_PW_UI;

    [SerializeField]
    private CheckRoom2PW checkinput;

    private void Update()
    {
        if(checkinput.m_right)
        {
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Investigate_text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ingameCtrl.m_pressR)
        {
            m_Room2_PW_UI.gameObject.SetActive(true);
            ingameCtrl.cursorTrue();
            m_Investigate_text.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_Room2_PW_UI.gameObject.SetActive(false);
            ingameCtrl.cursorFalse();
            m_Investigate_text.gameObject.SetActive(false);
        }
    }
}
