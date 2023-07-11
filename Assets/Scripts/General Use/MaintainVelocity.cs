using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainVelocity : MonoBehaviour
{
    Vector3 pos, velocity;
    public float targetVelocity;
    public float time;
    public bool achieved;
    private float lastTime;
    public float timeInVel;
    public goal g;
    private float xVelocity;
    void Awake()
    {
        time = 0;
        pos = transform.position;
    }

    void Update()
    {
        
        velocity = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;
        xVelocity = Mathf.Abs(velocity.x) / 100;

        if(velocity.x >= targetVelocity){
            time += Time.time - lastTime;
        }
        lastTime = Time.time;
        if(time >= timeInVel){
            achieved = true;
            g.achieveGoal();
        }else{
            achieved = false;
        }
    }
}
