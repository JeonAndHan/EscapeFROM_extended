using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mouse_Text_Trigger : MonoBehaviour
{
    /// <summary>
    /// /////그냥 쥐 script
    /// </summary>

    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TextTriggerUI")]
    public GameObject m_Mouse_UI;

    [SerializeField]
    public GameObject m_ZombieMouse_UI;

    [SerializeField]
    private TextMeshProUGUI mouse_Syringe_Text;

    [SerializeField]
    private ActionController Player;

    public bool b_NormalMouse_TextTrigger;
    public bool b_makeZombieMouse;

    public bool b_textTrigger = false;

    public bool b_PlayerLock = false;

    public TextMeshProUGUI m_Investigate_text;

    private void Update()
    {

        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            m_Investigate_text.gameObject.SetActive(false);
            mouse_Syringe_Text.gameObject.SetActive(false);
            b_PlayerLock = true;
            if (b_makeZombieMouse)
            {
                //좀비약 먹였을 경우에 좀비 UI 띄워야함
                m_ZombieMouse_UI.gameObject.SetActive(true);
            }
            else
            {
                m_Mouse_UI.gameObject.SetActive(true);
            }
        }
        else
        {
            m_Mouse_UI.gameObject.SetActive(false);
            m_ZombieMouse_UI.gameObject.SetActive(false);
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
                    Debug.Log("만약 player의 인벤토리에 RedSyringe나 GreenSyringe가 있다면");
                    mouse_Syringe_Text.gameObject.SetActive(true);
                    b_NormalMouse_TextTrigger = true;
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
            b_NormalMouse_TextTrigger = false;
        }
    }
}
