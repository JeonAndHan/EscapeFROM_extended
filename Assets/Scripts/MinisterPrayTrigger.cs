using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinisterPrayTrigger : MonoBehaviour
{

    public AudioSource ministerPraySound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!ministerPraySound.isPlaying)
            {
                ministerPraySound.Play();
            }
        }
    }
}
