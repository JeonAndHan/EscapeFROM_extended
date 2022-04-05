using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    public static UICtrl Instance;

    [SerializeField]
    private ActionController actionctrl;

    [SerializeField]
    private HealthBar m_playerHpBar;
    public Button m_help_bth;
    public Button m_helpUI_close_btn;
    public Button m_StartStory_Close_btn;

    public GameObject m_manipulation_UI;
    public GameObject m_StartStoryUI;

    private bool m_press_btn = false; //true

    private bool b_StoryClose_btn = true;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void showHp(float current,float max)
    {
        m_playerHpBar.ShowHPbar(current, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_press_btn)
        {
            m_manipulation_UI.gameObject.SetActive(true);
            actionctrl.playerLock = true;
        }
        else
        {
            m_manipulation_UI.gameObject.SetActive(false);
            actionctrl.playerLock = false;
        }

        if (!b_StoryClose_btn)
        {
            actionctrl.playerLock = false;
            m_StartStoryUI.gameObject.SetActive(false);
        }

        if(m_StartStoryUI.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                m_StartStoryUI.SetActive(false);
            }
        }
    }

    public void pressHelp()
    {
        m_press_btn = true;
    }

    public void ManipulationpressClose()
    {
        m_press_btn = false;
    }

    public void startStoryUI_Close()
    {
        b_StoryClose_btn = false;
    }
}
