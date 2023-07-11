using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private Vector3 offset;
    public float amp;
    public float frequency;
    private bool dropped = false;
    private Rigidbody2D rb2d;
    private bool clickDelay = false;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if(clickDelay == false){
                clickDelay = true;
            }else{
                dropped = true;
                rb2d.gravityScale = 1f;
            }
        }
        if(!dropped){
            transform.position = new Vector3(Mathf.Sin(Time.time * frequency) * amp, 0f, 0f) + offset;
        }
    }
}