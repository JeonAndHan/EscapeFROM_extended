using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room1Pw : MonoBehaviour
{
    //safe keypad Ctrl
    public Button m_num1;
    public Button m_num2;
    public Button m_num3;
    public Button m_num4;
    public Button m_num5;
    public Button m_num6;
    public Button m_num7;
    public Button m_num8;
    public Button m_num9;
    public Button m_num0;
    public Button m_Green;

    private string[] m_clicked = new string[6];
    private bool m_green;

    private int m_count = 0; //6번 입력받고 더이상 못받게 count
    public bool m_right = false; //비밀번호 맞았을 때 true
    public GameObject m_Room1_door;
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
        if (m_clicked[0] == "0" && m_clicked[1] == "3" && m_clicked[2] == "9" && m_clicked[3] == "4" && m_clicked[4]=="4" && m_clicked[5]=="3")
        {
            m_right = true;
            Debug.Log("금고 번호 맞춤");
            m_Room1_door.SetActive(false);
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

    public void ClickOne()
    {
        m_clicked[m_count] = "1";
        m_count++;
        Debug.Log("1번눌림");
        Effect.EffectPlay(5);

    }

    public void ClickTwo()
    {
        m_clicked[m_count] = "2";
        m_count++;
        Debug.Log("2번눌림");
        Effect.EffectPlay(5);

    }
    public void ClickThree()
    {
        m_clicked[m_count] = "3";
        m_count++;
        Debug.Log("3번눌림");
        Effect.EffectPlay(5);

    }
    public void ClickFour()
    {
        m_clicked[m_count] = "4";
        m_count++;
        Debug.Log("4번눌림");
        Effect.EffectPlay(5);

    }
    public void ClickFive()
    {
        m_clicked[m_count] = "5";
        m_count++;
        Effect.EffectPlay(5);

    }
    public void ClickSix()
    {
        m_clicked[m_count] = "6";
        m_count++;
        Debug.Log("6번눌림");
        Effect.EffectPlay(5);

    }
    public void ClickSeven()
    {
        m_clicked[m_count] = "7";
        m_count++;
        Effect.EffectPlay(5);

    }
    public void ClickEight()
    {
        m_clicked[m_count] = "8";
        m_count++;
        Effect.EffectPlay(5);

    }
    public void ClickNine()
    {
        m_clicked[m_count] = "9";
        m_count++;
        Effect.EffectPlay(5);

    }
    public void ClickZero()
    {
        m_clicked[m_count] = "0";
        m_count++;
        Effect.EffectPlay(5);

    }

    public void ClickGreen()
    {
        m_green = true;
        Debug.Log("green 눌림");
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