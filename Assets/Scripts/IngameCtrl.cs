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

        ////도끼와 총 toggle해주기
        //if (Input.GetKeyDown(KeyCode.E) && playerCtrl.b_getGun)
        //{
        //    //E를 누르고 총이 활성화 되어있다면 도끼를 켜주기
        //    if (playerCtrl.m_Gun.activeInHierarchy)
        //    {
        //        playerCtrl.m_Gun.SetActive(false);
        //        playerCtrl.m_Axe.SetActive(true);
        //    }
        //    else if (playerCtrl.m_Axe.activeInHierarchy)
        //    {
        //        playerCtrl.m_Gun.SetActive(true);
        //        playerCtrl.m_Axe.SetActive(true);
        //    }
        //}

        ////총을 얻었을 때 b_getGun = true 해주기
        ////총을 얻고 도끼가 켜져있다면 Axe는 꺼두기
        //if (playerCtrl.b_getGun && playerCtrl.m_Axe.activeInHierarchy)
        //{
        //    playerCtrl.m_Axe.SetActive(false);
        //}
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
