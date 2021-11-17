using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Acquire_Text_Trigger : MonoBehaviour
{
    public bool b_textTrigger = false;

    public TextMeshProUGUI m_Acquire_text;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            b_textTrigger = true;
            m_Acquire_text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player out");
            b_textTrigger = false;
            m_Acquire_text.gameObject.SetActive(false);
        }
    }
}
