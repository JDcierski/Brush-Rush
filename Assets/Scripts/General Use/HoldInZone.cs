using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldInZone : MonoBehaviour
{
    public string zoneTag;
    public bool inZone;
    public float time;
    public bool achieved;
    private float lastTime;
    public float timeInZone;
    public goal g;

    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<goal>();
        inZone = false;
        achieved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inZone){
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
