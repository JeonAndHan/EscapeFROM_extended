using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Computer_Text_Trigger : TextTrigger
{
    [SerializeField]
    private IngameCtrl ingameCtrl;

    [Header("TimeAttack")]
    public GameObject m_TimeAttack_UI;
    public TextMeshProUGUI m_Time_Text;
    private float time = -1f;

    [Header("Explosion")]
    public GameObject m_explosion;
    public bool m_explosion_true = false;

    [Header("Sound")]
    SoundManager Sound;
    EffectManager Effect;

    private void Start()
    {
        m_explosion.SetActive(false);
        Sound = FindObjectOfType<SoundManager>();
        Effect = FindObjectOfType<EffectManager>();
    }

    private void Update()
    {
        if (ingameCtrl.m_pressR && b_textTrigger)
        {
            if (!m_TimeAttack_UI.activeInHierarchy)
            {
                time = 600f;
                m_TimeAttack_UI.gameObject.SetActive(true);
                Sound.Play();
                m_Investigate_text.gameObject.SetActive(false);
            }
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

    IEnumerator gameover()
    {
        WaitForSeconds Delay1sec = new WaitForSeconds(1f);
        yield return Delay1sec;

        SceneManager.LoadScene("GameOver");
    }
}
