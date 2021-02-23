using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerAnimScript : MonoBehaviour
{
    private Animator m_Anim;
    private bool isPraying = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // m_Anim.SetBool("PRAY", true);
        AnimatorStateInfo info = m_Anim.GetCurrentAnimatorStateInfo(0);
        isPraying = info.IsName("PRAY");

        if (isPraying)
        {
            m_Anim.SetTrigger("PRAY");
        }

    }
}
