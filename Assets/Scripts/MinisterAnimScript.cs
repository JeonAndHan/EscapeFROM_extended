using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinisterAnimScript : MonoBehaviour
{
    private Animator m_Anim;
    private bool isTalking = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = m_Anim.GetCurrentAnimatorStateInfo(0);
        isTalking = info.IsName("TALK");

        if (isTalking)
        {
            m_Anim.SetTrigger("TALK");
        }

    }
}
