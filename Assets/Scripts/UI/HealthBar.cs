using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    protected Image m_bar;
    [SerializeField]
    protected TextMeshProUGUI m_value_text;

    public void ShowHPbar(float current, float max)
    {
        
        m_bar.fillAmount = current / max;
        m_value_text.text = string.Format("{0} / {1}", current.ToString("N0"), max.ToString("N0"));
       
    }
}
