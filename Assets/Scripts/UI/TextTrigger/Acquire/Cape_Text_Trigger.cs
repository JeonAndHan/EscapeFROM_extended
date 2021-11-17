using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cape_Text_Trigger : Acquire_Text_Trigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("Cape")]
    public GameObject m_player_cape;
    public GameObject m_hanger_cape;


    private void Update()
    {
        if (ingameCtrl.m_pressZ && b_textTrigger)
        {
            m_player_cape.SetActive(true);
            m_hanger_cape.SetActive(false);
        }
        else
        {
            m_player_cape.SetActive(false);
            m_hanger_cape.SetActive(true);
        }
    }
}
