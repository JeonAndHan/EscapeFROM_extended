﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour
{
    [Header("TextTriggerScript")]
    //public TextTrigger m_TextTrigger;
    public TextTrigger m_Room1_Board_Text;
    public TextTrigger m_Room2_Board_Text;
    public TextTrigger m_Computer_Text;
    public TextTrigger m_Desk_Text;
    public TextTrigger m_Safe_Text;
    public TextTrigger m_Room1PW_Text;
    public TextTrigger m_Statue1_Text;
    public TextTrigger m_Statue2_Text;
    public TextTrigger m_Statue3_Text;
    public TextTrigger m_Room2PW_Text;
    public TextTrigger m_PrayerRoom_Text;
    public TextTrigger m_Lab_Report_Text;
    public TextTrigger m_Recipe_Zombie_Drug_Text;
    public TextTrigger m_Recipe_Antidote_Text;
    public TextTrigger m_Zombie_Mouse_Text;
    public TextTrigger m_Mouse_Text;
    public TextTrigger m_Zombie_Drug_Text;
    public TextTrigger m_Antidote_Text;
    public TextTrigger m_Key_Text;
    public TextTrigger m_Cape_Text;
    public TextTrigger m_Room_Bullet_Text;
    public TextTrigger m_Toilet_Bullet_Text;
    public TextTrigger m_Water_Text;

    [Header("TextTriggerUI")]
    public GameObject m_Room1_Board_UI;
    public GameObject m_Room2_Board_UI;
    public GameObject m_Desk_UI;
    public GameObject m_safe_UI;
    public GameObject m_Room1PW_UI;
    public GameObject m_Room2PW_UI;
    public GameObject m_Trick;
    public GameObject m_Prayer_Diary_UI;
    public GameObject m_Lab_Report_UI;
    public TextMeshProUGUI m_Investigate_Text;
    public TextMeshProUGUI m_acquire_Text;
    public Canvas m_canvas;


    [Header("TimeAttack")]
    public GameObject m_TimeAttack_UI;
    public TextMeshProUGUI m_Time_Text;
    private float time=-1f;

    [Header("TextTriggerBool")]
    private bool m_computer_investigate;
    private bool m_Room1_Board_investigate;
    private bool m_Room2_Board_investigate;
    private bool m_Desk_investigate;
    private bool m_Safe_investigate;
    private bool m_Room1PW_investigate;
    private bool m_Statue1_investigate;
    private bool m_Statue2_investigate;
    private bool m_Statue3_investigate;
    private bool m_Room2PW_investigate;
    private bool m_PrayerRoom_investigate;
    private bool m_Lab_Report_investigate;
    private bool m_Zombie_Mouse_investigate;
    private bool m_Mouse_investigate;

    [Header("TextTriggerBool_Aquire")]
    private bool m_weapon_acquire;
    private bool m_cape_acquire;
    private bool m_zombie_drug_acquire;
    private bool m_antidote_acquire;
    private bool m_key_aquire;
    private bool m_room_bullet_aquire;
    private bool m_toilet_bullet_aquire;
    private bool m_water_acquire;
    private bool m_recipe_zombie_drug_acquire;
    private bool m_recipe_antidote_acquire;


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


    void Start()
    {
        m_explosion.SetActive(false);
        Sound = FindObjectOfType<SoundManager>();
        Effect = FindObjectOfType<EffectManager>();
        DoorEffect = FindObjectOfType<DoorEffectManager>();
    }

    // Update is called once per frame
    void Update()
    {

        investigate_TextTrigger();
        acquire_TextTrigger();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_pressZ = true;
            Debug.Log("press Z");
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            m_pressZ = false;
            Debug.Log("z에서 손 뗌");
        }

        if(m_pressR && !m_TimeAttack_UI.activeInHierarchy && m_Computer_Text.m_textTrigger)
        {
            time = 600f; 
            m_TimeAttack_UI.gameObject.SetActive(true);
            Sound.Play();
        }


        if(m_pressR && m_Statue1_investigate)
        {
            Effect.EffectPlay(7);
        }
        if(m_pressR && m_Statue2_investigate)
        {
            Effect.EffectPlay(6);
        }

        if(m_pressR && m_Statue3_investigate) //R버튼이 눌리고 statue3의 트리거에 들어가있다면
        {
            m_Trick.gameObject.SetActive(true);
            Effect.EffectPlay(8);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            m_pressR = true;
            Debug.Log("press R");
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m_pressR = false;
            Debug.Log("R에서 손뗌");
        }

        if(m_pressR && m_Room1_Board_investigate) // R버튼이 눌리고 room1의 트리거에 들어가 있다면
        {
            m_Room1_Board_UI.SetActive(true);
        }
        else
        {
            m_Room1_Board_UI.SetActive(false);
        }

        if (m_pressR && m_Room2_Board_investigate) // R버튼이 눌리고 room2의 트리거에 들어가 있다면
        {
            m_Room2_Board_UI.SetActive(true);
        }
        else
        {
            m_Room2_Board_UI.SetActive(false);
        }

        if (m_pressR && m_Desk_investigate) // R버튼이 눌리고 Desk의 트리거에 들어가 있다면
        {
            m_Desk_UI.SetActive(true);
        }
        else
        {
            m_Desk_UI.SetActive(false);
        }

        if (m_pressR && m_Safe_investigate && !m_keypad.m_right) //R버튼이 눌리고 safe 트리거에 들어가있고 비번을 맞추지 못했다면
        {
            m_safe_UI.SetActive(true);
        }
        else
        {
            m_safe_UI.SetActive(false);
        }

        if (m_pressR && m_Room1PW_investigate && ! m_room1_pw.m_right) //R버튼이 눌리고 room1PW 트리거에 들어가있고 비번을 맞추지 못했다면
        {
            m_Room1PW_UI.SetActive(true);
        }
        else
        {
            m_Room1PW_UI.SetActive(false);
        }

        if(m_pressR && m_Room2PW_investigate && !m_room2_pw.m_right)
        {
            m_Room2PW_UI.SetActive(true);
        }
        else
        {
            m_Room2PW_UI.SetActive(false);
        }

        if (m_pressR && m_PrayerRoom_investigate) 
        {
            m_Prayer_Diary_UI.SetActive(true);
        }
        else
        {
            m_Prayer_Diary_UI.SetActive(false);
        }

        if (m_pressR && m_Lab_Report_investigate)
        {
            m_Lab_Report_UI.SetActive(true);
        }
        else
        {
            m_Lab_Report_UI.SetActive(false);
        }


        int i, j;

        //timeAttack
        if (time > 0)
        {
            time -= Time.deltaTime;
            i = (int)(time / 60);
            j = (int)(time % 60);
            m_Time_Text.text = i + " : " + j.ToString();
        }
        /* GAME OVER ENDING 1 - TIME OVER */
        else if ((int)time == 0)
        {
            Debug.Log("타임종료");
            m_explosion.SetActive(true);
            m_explosion_true = true;
            Sound.Stop();
            StartCoroutine(gameover());
        }
               
    }

    public void acquire_TextTrigger()
    {
        if(m_keypad.m_right && m_Safe_Text.m_textTrigger && !m_player_weapon.gameObject.activeInHierarchy)
        {
            m_acquire_Text.gameObject.SetActive(true);
            m_weapon_acquire=true;
        } else if(m_Cape_Text.m_textTrigger && !m_player_cape.gameObject.activeInHierarchy)
        {
            m_acquire_Text.gameObject.SetActive(true);
            m_cape_acquire=true;
        } else if(m_Zombie_Drug_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Antidote_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Key_Text.m_textTrigger && m_key_aquire){
        //TODO: 인벤토리에 추가하면 acquire text inactives
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Room_Bullet_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Toilet_Bullet_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Recipe_Zombie_Drug_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Water_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else if(m_Recipe_Antidote_Text.m_textTrigger)
        //TODO: 인벤토리에 추가하면 acquire text inactives
        {
            m_acquire_Text.gameObject.SetActive(true);
        } else
        {
            m_acquire_Text.gameObject.SetActive(false);
        }



        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Safe_Text.m_textTrigger) // z가 눌렸고, acquiretext가 true라면
        {
            m_safe_weapon.gameObject.SetActive(false);
            m_player_weapon.gameObject.SetActive(true);
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Cape_Text.m_textTrigger) // z가 눌렸고, acquiretext가 true라면
        {
            m_hanger_cape.gameObject.SetActive(false);
            m_player_cape.gameObject.SetActive(true);
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Zombie_Drug_Text.m_textTrigger)
        {
            m_zombie_drug.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Antidote_Text.m_textTrigger)
        {
            m_antidote.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_Key_Text.m_textTrigger)
        {
            m_safe_door.transform.localEulerAngles = new Vector3(0f, -120f, 0f);
            DoorEffect.Play();
            m_key_aquire=true;
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Key_Text.m_textTrigger)
        {
            m_key.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Room_Bullet_Text.m_textTrigger)
        {
            m_room_bullet.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Toilet_Bullet_Text.m_textTrigger)
        {
            m_toilet_bullet.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Water_Text.m_textTrigger)
        {
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Recipe_Zombie_Drug_Text.m_textTrigger)
        {
            m_recipe_zombie_drug.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
        if(m_pressZ && m_acquire_Text.gameObject.activeInHierarchy && m_Recipe_Antidote_Text.m_textTrigger)
        {
            m_recipe_antidote.gameObject.SetActive(false);
            //TODO: 인벤토리에 추가
        }
    }

    public void investigate_TextTrigger()
    {
        if (m_Room1_Board_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room1_Board_investigate = true;
        }
        else if (m_Room2_Board_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room2_Board_investigate = true;
        }
        else if (m_Computer_Text.m_textTrigger && !m_TimeAttack_UI.activeInHierarchy)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_computer_investigate = true;
        }
        else if (m_Desk_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Desk_investigate = true;
        }
        else if (m_Safe_Text.m_textTrigger && !m_keypad.m_right)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Safe_investigate = true;
        }
        else if(m_Room1PW_Text.m_textTrigger && !m_room1_pw.m_right)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room1PW_investigate = true;
        }
        else if (m_Statue1_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Statue1_investigate = true;
        }
        else if (m_Statue2_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Statue2_investigate = true;
        }
        else if (m_Statue3_Text.m_textTrigger && !m_Trick.activeInHierarchy)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Statue3_investigate = true;
        }
        else if (m_Room2PW_Text.m_textTrigger && !m_room2_pw.m_right)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Room2PW_investigate = true;
        }
        else if (m_PrayerRoom_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_PrayerRoom_investigate = true;
        }
        else if (m_Lab_Report_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Lab_Report_investigate = true;
        }
        else if(m_Zombie_Mouse_Text.m_textTrigger)
        {
            m_Investigate_Text.gameObject.SetActive(true);
            m_Zombie_Mouse_investigate=true;
        }
        else if(m_Mouse_Text.m_textTrigger){
            m_Investigate_Text.gameObject.SetActive(true);
            m_Mouse_investigate=true;
        }
        else
        {
            m_Investigate_Text.gameObject.SetActive(false);
            m_computer_investigate = false;
            m_Room1_Board_investigate = false;
            m_Room2_Board_investigate = false;
            m_Desk_investigate = false;
            m_Safe_investigate = false;
            m_Room1PW_investigate = false;
            m_Statue1_investigate = false;
            m_Statue2_investigate = false;
            m_Statue3_investigate = false;
            m_Room2PW_investigate = false;
            m_PrayerRoom_investigate = false;
            m_Lab_Report_investigate = false;
            m_Zombie_Mouse_investigate=false;
            m_Mouse_investigate=false;
        }
    }

    IEnumerator gameover()
    {
        WaitForSeconds Delay1sec = new WaitForSeconds(1f);
        yield return Delay1sec;

        SceneManager.LoadScene("GameOver");
    }
}
