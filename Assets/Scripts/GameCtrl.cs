using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour
{
    [Header("TextTriggerScript")]
    //public TextTrigger m_TextTrigger;

    public TextTrigger m_Lab_Report_Text;


    [Header("TextTriggerUI")]

    public GameObject m_Trick;

    public GameObject m_Lab_Report_UI;

    public Canvas m_canvas;



    [Header("TextTriggerBool_Aquire")]
    private bool m_weapon_acquire;
    private bool m_cape_acquire;


    [Header("KeyBoardBool")]
    public bool m_pressR;
    public bool m_pressZ;

    public keyPadCtrl m_keypad;
    public Room1Pw m_room1_pw;
    public Room2PW m_room2_pw;

    [Header("Weapon")]
    public GameObject m_player_weapon;
    public GameObject m_safe_weapon;

    [Header("Explosion")]
    public GameObject m_explosion;
    public bool m_explosion_true = false;

    [Header("Sound")]
    SoundManager Sound;
    EffectManager Effect;

    [Header("Inventory Items")]
    public GameObject m_key;
    public GameObject m_toilet_bullet;
    public GameObject m_room_bullet;
    public GameObject m_zombie_drug;
    public GameObject m_antidote;
    public GameObject m_water;
    public GameObject m_recipe_zombie_drug;
    public GameObject m_recipe_antidote;

    [Header("Cape")]
    public GameObject m_player_cape;
    public GameObject m_hanger_cape;

    [Header("Safe")]
    public GameObject m_safe_door;
    DoorEffectManager DoorEffect;

    [Header("1st floor door")]
    public GameObject m_1st_door;


    void Start()
    {
        m_explosion.SetActive(false);
        Sound = FindObjectOfType<SoundManager>();
        Effect = FindObjectOfType<EffectManager>();
        DoorEffect = FindObjectOfType<DoorEffectManager>();
    }


    void Update()
    {

    }

    //public void acquire_TextTrigger()
    //{
    //    if (m_keypad.m_right && m_Safe_Text.m_textTrigger && !m_player_weapon.gameObject.activeInHierarchy)
    //    {
    //        m_acquire_Text.gameObject.SetActive(true);
    //        m_weapon_acquire = true;
    //    }
    //    //else if (m_Cape_Text.m_textTrigger && !m_player_cape.gameObject.activeInHierarchy)
    //    //{
    //    //    m_acquire_Text.gameObject.SetActive(true);
    //    //    m_cape_acquire = true;
    //    //}
    //    else
    //    {
    //        m_acquire_Text.gameObject.SetActive(false);
    //    }



    //if (m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Safe_Text.m_textTrigger) // z가 눌렸고, acquiretext가 true라면
    //{
    //    m_safe_weapon.gameObject.SetActive(false);
    //    m_player_weapon.gameObject.SetActive(true);
    //}
    //if (m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Cape_Text.m_textTrigger) // z가 눌렸고, acquiretext가 true라면
    //{
    //    m_hanger_cape.gameObject.SetActive(false);
    //    m_player_cape.gameObject.SetActive(true);
    //}



    //if(m_pressR && m_Key_Text.m_textTrigger){
    //    m_safe_door.transform.localEulerAngles = new Vector3(0f, -120f, 0f);
    //    DoorEffect.Play();
    //   // m_key_aquire=true;
    //}
    //if(m_pressR && m_Investigate_Text.gameObject.activeInHierarchy)
    //{
    //    m_1st_door.gameObject.SetActive(false);
    //}


}