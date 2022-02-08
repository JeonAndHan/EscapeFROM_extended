using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_ctrl : MonoBehaviour
{
    [SerializeField]
    private Transform playerCtrl;

    [SerializeField]
    private GetGun GetGun_Ctrl;

    private Animator m_Anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetGun_Ctrl.player_die_2ndfloor)
        {
            m_Anim.SetBool("LookAt", true);
        }
    }
}
