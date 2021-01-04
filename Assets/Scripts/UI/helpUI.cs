using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpUI : MonoBehaviour
{
    public Button m_help_bth;
    public Button m_close_btn;
    public GameObject m_manipulation_UI;

    private bool m_press_btn = true;

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
