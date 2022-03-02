using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondFloor_DoorTrigger : MonoBehaviour
{
    public bool b_SecondFloor_DoorTrigger;

    [SerializeField]
    private TextMeshProUGUI m_keyText;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    private void Update()
    {
        if (ingameCtrl.b_secondFloor_DoorOpen)
        {
            m_keyText.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ingameCtrl.b_secondFloor_DoorOpen)
        {
            b_SecondFloor_DoorTrigger = true;
            m_keyText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            b_SecondFloor_DoorTrigger = false;
            m_keyText.gameObject.SetActive(false);
        }
    }
}
