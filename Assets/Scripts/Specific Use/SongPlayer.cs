using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    public void playNormal(){
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
    public void playFast(){
        transform.GetChild(1).GetComponent<AudioSource>().Play();
    }
    public void stopPlaying(){
        transform.GetChild(0).GetComponent<AudioSource>().Stop();
        transform.GetChild(1).GetComponent<AudioSource>().Stop();
    }
}
