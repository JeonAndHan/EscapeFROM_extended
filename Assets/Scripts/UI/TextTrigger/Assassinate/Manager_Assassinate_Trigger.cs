using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Assassinate_Trigger : MonoBehaviour
{
    //Todo
    //player가 collider에 들어오면 안내 text 띄우기

    [SerializeField]
    private TextMeshProUGUI m_Assassinate_text;

    [SerializeField]
    private IngameCtrl ingameCtrl;

    [SerializeField]
    private Animator manager_anim;

    public bool b_manager_dead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Assassinate_text.gameObject.activeInHierarchy && ingameCtrl.m_pressR && !b_manager_dead)
        {
            Debug.Log("매니저 암살");
            //매니저 암살 애니넣기
            manager_anim.SetTrigger("DIE");
            b_manager_dead = true;
            m_Assassinate_text.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Assassinate_text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_Assassinate_text.gameObject.SetActive(false);
        }
    }
}
