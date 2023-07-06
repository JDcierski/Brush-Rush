using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveOnTimer : MonoBehaviour
{
    public float time;
    public bool beginOnStart;
    private float endTime = 999999999999999f;
    // Start is called before the first frame update
    void Start()
    {
        if(beginOnStart){
            startTimer();
        }
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
    }
}
