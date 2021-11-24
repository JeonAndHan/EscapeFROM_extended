using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cape_Text_Trigger : MonoBehaviour
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private TextMeshProUGUI m_Acquire_text;

    private bool b_textTrigger;

    public bool b_wear_cape = false;

    [Header("Cape")]
    public GameObject m_player_cape;
    public GameObject m_hanger_cape;


    private void Update()
    {

        if (ingameCtrl.m_pressZ && b_textTrigger)
        {
            m_player_cape.SetActive(true);
            m_hanger_cape.SetActive(false);

            b_wear_cape = true;

            m_Acquire_text.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            b_wear_cape = false;
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            b_textTrigger = true;
            m_Acquire_text.gameObject.SetActive(true);
            m_Acquire_text.text = "Press " + "<color=yellow>" + "'Z'" + "</color>" + " to aquire " + "Cape";
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
