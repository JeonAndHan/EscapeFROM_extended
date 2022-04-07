using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEndingCtrl : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_ending_sound;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = m_ending_sound;
        source.Play();
        source.volume = 0.25f;
    }

}
