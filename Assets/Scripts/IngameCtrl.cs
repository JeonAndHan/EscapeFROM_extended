using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngameCtrl : MonoBehaviour
{

    [Header("Press key Bool")]
    public bool m_pressR;
    public bool m_pressZ;

    [Header("TextTriggerBool_Aquire")]
    private bool m_weapon_acquire;
    private bool m_cape_acquire;

    [SerializeField]
    private TextMeshProUGUI m_recipeGuide_text;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_pressR = true;
            Debug.Log("press R");
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m_pressR = false;
            Debug.Log("R에서 손뗌");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_pressZ = true;
            Debug.Log("press Z");
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            m_pressZ = false;
            Debug.Log("z에서 손 뗌");
        }
    }

    public void recipeGuide()
    {
        m_recipeGuide_text.gameObject.SetActive(true);
        m_recipeGuide_text.text = "Now you can make somthing!\n" + "Press " + "<color=yellow>" + "'C'" + "</color>" + " to use Recipe";
    }

    public void CoroutineDeleteRecipeGuide()
    {
        StartCoroutine(deleteRecipeGuide());
    }

    IEnumerator deleteRecipeGuide()
    {
        WaitForSeconds three = new WaitForSeconds(3f);
        yield return three;

        m_recipeGuide_text.gameObject.SetActive(false);
    }
}
