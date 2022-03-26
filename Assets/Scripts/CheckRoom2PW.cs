using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRoom2PW : MonoBehaviour
{
    [Header("InputUI")]
    public GameObject m_Input_UI;

    public GameObject m_door;
    EffectManager Effect;
    DoorEffectManager DoorEffect;
    public bool m_right = false; //비밀번호 맞았을 때 true

    void Start()
    {
        Effect = FindObjectOfType<EffectManager>();
        DoorEffect = FindObjectOfType<DoorEffectManager>();
    }

    public void check(InputField f)
    {
        if (f.text == "escape" || f.text == "ESCAPE")
        {
            Debug.Log("암호 맞춤");
            m_Input_UI.SetActive(false);
            m_door.gameObject.transform.localEulerAngles = new Vector3(0f, -10f, 0f);
            m_right = true;
            Effect.EffectPlay(3);
            DoorEffect.Play();
        }
        else
        {
            Debug.Log("틀린답");
            m_Input_UI.SetActive(false);
            Effect.EffectPlay(4);
        }
    }
}
