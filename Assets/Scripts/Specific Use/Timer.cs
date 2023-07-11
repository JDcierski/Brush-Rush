using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float length;
    public float time;
    private float startTime;
    public bool timing;
    private barPiece bp;    
    void Start(){
        bp = GetComponent<barPiece>();
        timing = false;
        time = 0;
        bp.setFillAmount(1);
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
                GameObject.FindWithTag("GameManager").GetComponent<GameManager>().loseHp();
            }else{
                bp.setFillAmount(1 - time/length);
            }
        }
    }
}
