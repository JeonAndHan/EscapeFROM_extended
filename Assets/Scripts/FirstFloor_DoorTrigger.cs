using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstFloor_DoorTrigger : MonoBehaviour
{
    public bool b_FirstDoor;

    [SerializeField]
    private TextMeshProUGUI m_keyText;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    private void Update()
    {
        if (ingameCtrl.b_fistFloor_DoorOpen)
        {
            m_keyText.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ingameCtrl.b_fistFloor_DoorOpen)
        {
            b_FirstDoor = true;
            m_keyText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            b_FirstDoor = false;
            m_keyText.gameObject.SetActive(false);
        }
    }
}
