using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldInVelocityZone : MonoBehaviour
{
    public string zoneTag;
    public bool inZone;
    public float time;
    public bool achieved;
    private float lastTime;
    public float timeInZone;
    public goal g;

    Vector3 pos, velocity;
    public float targetVelocity;
    public float xVelocity;
    public float yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        pos = transform.position;
        g = GetComponent<goal>();
        inZone = false;
        achieved = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;
        xVelocity = Mathf.Abs(velocity.x) / 100;
        yVelocity = Mathf.Abs(velocity.y) / 100;

        if(inZone && (velocity.x >= targetVelocity || velocity.y >= targetVelocity)){
            time += Time.time - lastTime;
        }
        lastTime = Time.time;
        if(time >= timeInZone){
            achieved = true;
            g.achieveGoal();
        }else{
            achieved = false;
        }

    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == zoneTag){
            inZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == zoneTag){
            inZone = false;
        }
    }
}
