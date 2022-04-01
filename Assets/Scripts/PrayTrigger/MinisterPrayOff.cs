using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinisterPrayOff : MonoBehaviour
{
    public AudioSource praySound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            praySound.Stop();
        }
    }
}
