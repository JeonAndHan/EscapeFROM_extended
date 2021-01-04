using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    public AudioClip[] clips; //배경음악들
    private AudioSource source;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[0];
        source.Play();

    }
    public void Play()
    {
        source.clip = clips[1];
        source.Play();
    }
    public void EndingPlay(){
        source.clip=clips[2];
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }

    
}
