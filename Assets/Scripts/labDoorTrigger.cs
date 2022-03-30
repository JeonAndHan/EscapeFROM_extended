using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labDoorTrigger : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.normalizedTime < 1.0f)
            {
                return;
                
            }
            else
            {
                animator.SetBool("isOpen", true);
            }
  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player enter");
            animator.SetBool("isOpen", false);
        }
    }
}
