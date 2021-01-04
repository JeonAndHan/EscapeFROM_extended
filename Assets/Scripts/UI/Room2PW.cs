using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2PW : MonoBehaviour
{
    public Button m_Ebtn;
    public Button m_Sbtn;
    public Button m_Cbtn;
    public Button m_Abtn;
    public Button m_Pbtn;
    public Button m_EnterBtn;

    private string[] m_clicked = new string[6];
    private int m_count = 0; //6번 입력받고 더이상 못받게 count
    private bool m_enter = false; //enter키 눌렀을 때
    public bool m_right = false; //비밀번호 맞았을 때 true

    public GameObject m_door;
    EffectManager Effect;
    DoorEffectManager DoorEffect;


    // Start is called before the first frame update
    void Start()
    {
        Effect = FindObjectOfType<EffectManager>();
        DoorEffect = FindObjectOfType<DoorEffectManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void check_password()
    {
        if (m_clicked[0] == "E" && m_clicked[1] == "S" && m_clicked[2] == "C" && m_clicked[3] == "A" && m_clicked[4] == "P" && m_clicked[5] == "E")
        {
            Debug.Log("금고 번호 맞춤");
            m_door.gameObject.transform.localEulerAngles = new Vector3(0f, -10f, 0f);
            m_right = true;
            Effect.EffectPlay(3);
            DoorEffect.Play();

        }
        else
        {
            Debug.Log("번호 초기화");
            m_count = 0;
            m_clicked = new string[6];//배열초기화
            Effect.EffectPlay(4);

        }
    }

    public void ClickE()
    {
        m_clicked[m_count] = "E";
        m_count++;
        Debug.Log("E 눌림");
        Effect.EffectPlay(5);

    }

    public void ClickS()
    {
        m_clicked[m_count] = "S";
        m_count++;
        Debug.Log("S 눌림");
        Effect.EffectPlay(5);

    }

    public void ClickC()
    {
        m_clicked[m_count] = "C";
        m_count++;
        Debug.Log("C 눌림");
        Effect.EffectPlay(5);

    }

    public void ClickA()
    {
        m_clicked[m_count] = "A";
        m_count++;
        Debug.Log("A 눌림");
        Effect.EffectPlay(5);

    }

    public void ClickP()
    {
        m_clicked[m_count] = "P";
        m_count++;
        Debug.Log("P 눌림");
        Effect.EffectPlay(5);

    }

    public void ClickEnter()
    {
        m_enter = true;
        Debug.Log("enter 눌림");
        if (m_count == 6)
        {
            check_password();
        }
        else
        {
            Debug.Log("번호 초기화");
            m_count = 0;
            m_clicked = new string[6];//배열초기화
            Effect.EffectPlay(4);
            
        }
    }




}
