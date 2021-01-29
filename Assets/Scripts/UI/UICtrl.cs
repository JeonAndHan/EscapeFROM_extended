using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    public static UICtrl Instance;

    [SerializeField]
    private HealthBar m_playerHpBar;
    public Button m_help_bth;
    public Button m_close_btn;
    public GameObject m_manipulation_UI;
    [SerializeField]
    private GameObject[] m_BloodEffect;
    public player m_playerScript;

    private bool m_press_btn = false; //true

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_press_btn)
        {
            m_manipulation_UI.SetActive(true);
        }
        else
        {
            m_manipulation_UI.SetActive(false);
        }

        if (m_playerScript.m_playerHit)
        {
            for (int i = 0; i < m_BloodEffect.Length; i++)
            {
                m_BloodEffect[i].SetActive(true);
               // Debug.Log("BloodEffect true");
            }
        }
        else
        {
            for (int i = 0; i < m_BloodEffect.Length; i++)
            {
                m_BloodEffect[i].SetActive(false);
            }
        }
    }

    public void pressHelp()
    {
        m_press_btn = true;
    }

    public void pressClose()
    {
        m_press_btn = false;
    }

}
