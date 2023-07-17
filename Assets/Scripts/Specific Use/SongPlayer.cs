using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    public void playNormal(){
        stopPlaying();
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
    public void playFast(){
        stopPlaying();
        transform.GetChild(1).GetComponent<AudioSource>().Play();
    }
    public void playTitle(){
        stopPlaying();
        transform.GetChild(2).GetComponent<AudioSource>().Play();
    }
    public void stopPlaying(){
        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        transform.GetChild(1).GetComponent<AudioSource>().Stop();
        transform.GetChild(2).GetComponent<AudioSource>().Stop();
    }
}
