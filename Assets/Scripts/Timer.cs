using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float length;
    public float time;
    private float startTime;
    public bool timing;
    
    void Start(){
        timing = false;
        time = 0;
    }
    public void startTimer(){
        time = 0;
        startTime = Time.time;
        timing = true;
    }
    void Update()
    {
        if(timing){
            time = Time.time - startTime;
            if(time >= length){
                GameObject.FindWithTag("GameManager").GetComponent<GameManager>().loseHp("Try to go faster!");
            }
        }
    }
}
