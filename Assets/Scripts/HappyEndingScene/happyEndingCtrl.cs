using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class happyEndingCtrl : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_helicopter;

    private float m_time;

    [SerializeField]
    private GameObject[] m_narration;

    // Start is called before the first frame update
    void Start()
    {
        m_helicopter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        Debug.Log(m_time);

        if(m_time < 10)
        {
            m_narration[0].gameObject.SetActive(true);
        }
        
        if(m_time >10 && m_time < 20)
        {
            Debug.Log("time > 5 && time < 10");
            m_narration[0].gameObject.SetActive(false);
            m_narration[1].gameObject.SetActive(true);
        }

        if(m_time > 20 && m_time < 30)
        {
            m_narration[1].gameObject.SetActive(false);
            m_narration[2].gameObject.SetActive(true);
        }

        if(m_time > 30)
        {
            SceneManager.LoadScene("ClearEnding");
        }
    }

}
