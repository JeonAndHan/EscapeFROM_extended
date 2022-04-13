using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Button m_restart_Btn;
    public Button m_quit_Btn;

    private void OnEnable()
    {
        Cursor.visible = true;
    }

    public void restart()
    {
        Debug.Log("restart 눌림");
        SceneManager.LoadScene("Environment");
    }

    public void quit()
    {
        Debug.Log("quit 눌림");
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
    }
}
