using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zomebie_Mouse_Text_Trigger : MonoBehaviour
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Zombie_UI;
    public GameObject m_Mouse_UI;

    [SerializeField]
    private TextMeshProUGUI mouse_Syringe_Text;

    [SerializeField]
    private ActionController Player;

    public bool b_ZombieMouse_TextTrigger;

    public bool b_textTrigger = false;

    public bool b_PlayerLock = false;

    public bool b_makeNormalMouse = false;

    public TextMeshProUGUI m_Investigate_text;


    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            mouse_Syringe_Text.gameObject.SetActive(false);
            m_Investigate_text.gameObject.SetActive(false);
            b_PlayerLock = true;

            if (b_makeNormalMouse)
            {
                //치료제 먹였을 경우 일반쥐 UI 띄워야함
                m_Mouse_UI.gameObject.SetActive(true);
            }
            else
            {
                m_Zombie_UI.gameObject.SetActive(true);
            }
        }
        else
        {
            m_Mouse_UI.gameObject.SetActive(false);
            m_Zombie_UI.gameObject.SetActive(false);
            b_PlayerLock = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            b_textTrigger = true;
            m_Investigate_text.gameObject.SetActive(true);
            m_Investigate_text.text = "Press " + "<color=yellow>" + "'R'" + "</color>" + " to investigate";

            for (int i = 0; i < Player.inventory.GetSlots.Length; i++)
            {
                //만약 player의 인벤토리에 RedSyringe나 GreenSyringe가 있다면
                if (Player.inventory.GetSlots[i].item.Id == 0 || Player.inventory.GetSlots[i].item.Id == 6)
                {
                    mouse_Syringe_Text.gameObject.SetActive(true);
                    b_ZombieMouse_TextTrigger = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player out");
            b_textTrigger = false;
            m_Investigate_text.gameObject.SetActive(false);

            mouse_Syringe_Text.gameObject.SetActive(false);
            b_ZombieMouse_TextTrigger = false;
        }
    }
}
