using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static public EffectManager instance;
    public AudioClip[] effectclips;
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
    /*
        track number
        0 : zombie (small)
        1 : zombie (big)
        2 : attack(player)
        3 : keypad success
        4 : keypad fail
        5 : keypad button press
        6 : statue screaming
        7 : statue victoria
        8 : trick
        9 : credit screaming
        10 : hit the door
    */
    public void EffectPlay(int track_number){
        source = GetComponent<AudioSource>();
        source.clip = effectclips[track_number];
        source.Play();
    }
    
}
