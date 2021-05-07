using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    public InputField m_InputField;
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_InputField.text);
        Debug.Log(m_Text.text);
    }
}
