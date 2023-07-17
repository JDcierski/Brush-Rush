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
    public float timeUnPress;
    private float goalTime;
    void FixedUpdate()
    {
        if(pressed){
            paste.transform.localScale = new Vector3(paste.transform.localScale.x + rate, paste.transform.localScale.y + rate, paste.transform.localScale.z);
        }
        if(Mathf.Abs(paste.transform.localScale.x - targetSize) <= range && Time.time >= goalTime){
            paste.GetComponent<goal>().achieveGoal();
        }else{
            paste.GetComponent<goal>().failGoal();
            if(paste.transform.localScale.x > targetSize){
                paste.GetComponent<goal>().deathMessage = "Uh Oh! That's way too much toothpaste! I guess you could brush an elephant's teeth with that.";
            }else{
                paste.GetComponent<goal>().deathMessage = "Uh Oh! That's not enough toothpaste! I guess you could brush a hamster's teeth with that.";
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        pressed = true;
        goalTime = 999999999999999;
    }
    public void OnPointerUp(PointerEventData eventData){
        pressed = false;
        goalTime = Time.time + timeUnPress;
    }
}
