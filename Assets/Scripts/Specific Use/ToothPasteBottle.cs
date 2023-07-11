using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToothPasteBottle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject paste;
    private bool pressed;
    public float rate;
    public float targetSize;
    public float range;

    void FixedUpdate()
    {
        if(pressed){
            paste.transform.localScale = new Vector3(paste.transform.localScale.x + rate, paste.transform.localScale.y + rate, paste.transform.localScale.z);
        }
        if(Mathf.Abs(paste.transform.localScale.x - targetSize) <= range){
            paste.GetComponent<goal>().achieveGoal();
        }else{
            paste.GetComponent<goal>().failGoal();
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        pressed = false;
    }
}
