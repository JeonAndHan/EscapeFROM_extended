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

    public player playerCtrl;

    [SerializeField]
    private TextMeshProUGUI m_recipeGuide_text;

    [SerializeField]
    private TextMeshProUGUI toggle_text;

    public bool b_fistFloor_DoorOpen;
    public bool b_secondFloor_DoorOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_pressR = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            m_pressR = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_pressZ = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            m_pressZ = false;
        }

        //도끼와 총 toggle해주기
        if (Input.GetKeyDown(KeyCode.E) && playerCtrl.b_getGun && playerCtrl.b_getAxe)
        {
            //E를 누르고 총이 활성화 되어있다면 도끼를 켜주기
            if (playerCtrl.m_Gun.activeInHierarchy)
            {
                playerCtrl.m_Gun.SetActive(false);
                playerCtrl.m_Axe.SetActive(true);
            }
            else if (playerCtrl.m_Axe.activeInHierarchy)
            {
                playerCtrl.m_Gun.SetActive(true);
                playerCtrl.m_Axe.SetActive(false);
            }
        }
    }

    //Recipe Guild Text
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

    //Gun and Axe toggle Guide Text
    public void toggleTextTrue()
    {
        toggle_text.gameObject.SetActive(true);
        toggle_text.text = "Now you can change the Gun and Axe\n" + "Press " + "<color=yellow>" + "'E'" + "</color>" + " to change";
        StartCoroutine(toggleTextOff());
    }

    IEnumerator toggleTextOff()
    {
        WaitForSeconds three = new WaitForSeconds(3f);
        yield return three;

        toggle_text.gameObject.SetActive(false);
    }

    public void cursorTrue()
    {
        Cursor.visible = true;
    }

    public void cursorFalse()
    {
        Cursor.visible = false;
    }
}
