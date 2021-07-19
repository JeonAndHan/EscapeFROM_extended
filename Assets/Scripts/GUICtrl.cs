using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICtrl : MonoBehaviour
{
    public static GUICtrl uiInstance;

    private void Awake()
    {
        if (uiInstance == null)
        {
            uiInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
