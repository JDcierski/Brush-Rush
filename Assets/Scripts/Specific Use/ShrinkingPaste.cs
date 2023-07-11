using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPaste : MonoBehaviour
{
    public HoldInZone hiz;
    private Vector3 startSize;

    // Start is called before the first frame update
    void Start()
    {
        startSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.y > 0){
            transform.localScale = new Vector3(startSize.x, startSize.y * (1 - (hiz.time / hiz.timeInZone)), startSize.z);
        }
        
    }
}
