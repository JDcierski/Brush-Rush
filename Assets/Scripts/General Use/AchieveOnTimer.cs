using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveOnTimer : MonoBehaviour
{
    public float time;
    public bool beginOnStart;
    private float endTime = 999999999999999f;
    public Timer timer;
    private bool time1 = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
    }
    public void startTimer(){
        endTime = Time.time + time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= endTime){
            this.GetComponent<goal>().achieveGoal();
        }
        if(timer.timing && time1){
            time1 =false; 
            startTimer();
        }
    }
}
