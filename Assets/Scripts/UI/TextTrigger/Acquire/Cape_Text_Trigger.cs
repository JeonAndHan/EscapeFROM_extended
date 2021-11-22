using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cape_Text_Trigger : Acquire_Text_Trigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

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
}
