using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public bool b_textTrigger = false;

    public TextMeshProUGUI m_Investigate_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            b_textTrigger = true;
            m_Investigate_text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player out");
            b_textTrigger = false;
            m_Investigate_text.gameObject.SetActive(false);
        }
    }

}
