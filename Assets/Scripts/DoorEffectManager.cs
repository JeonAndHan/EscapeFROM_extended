using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEffectManager : MonoBehaviour
{
    static public DoorEffectManager instance;
    public AudioClip dooreffectclip;
    private AudioSource source;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    
    public void Play()
    {
        source = GetComponent<AudioSource>();
        source.clip = dooreffectclip;
        source.Play();
    }
}
