using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrushInjury : MonoBehaviour
{
    public GameObject injury;
    public GameObject injury2;
    
    public string zoneTag;
    public bool inZone;
    public float time;
    private float lastTime;
    public float timeInZone;

    Vector3 pos, velocity;
    public float targetVelocity;
    public float xVelocity;
    public float yVelocity;
    public bool foam;
    private float lastY;
    public bool infront;
    private int n;
    private int nRow = 10;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        pos = transform.position;
        inZone = false;
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
            n = 0;
        }else{
            if(foam){
                n++;
                if(n >= nRow){
                    time = 0;
                }
            }
        }
        lastTime = Time.time;
        if(time >= timeInZone){
            if(Random.Range(0, 2) == 1){
                if(infront){
                    Instantiate(injury2, transform.position + new Vector3(0f, 0f, -1f), Quaternion.Euler(90f, 0f, 0f));
                }else{
                    Instantiate(injury2, transform.position + new Vector3(0f, 0f, 3f), transform.rotation);
                }
            }else{
                if(infront){
                    Instantiate(injury, transform.position + new Vector3(0f, 0f, -1f), Quaternion.Euler(90f, 0f, 0f));
                }else{
                    Instantiate(injury, transform.position + new Vector3(0f, 0f, 3f), transform.rotation);
                }
            }
            time = 0;
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
            time = 0;
        }
    }
}
