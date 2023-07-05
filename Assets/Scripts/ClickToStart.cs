using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    public Timer timer;
    private void start(){
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
    }
    public void goAway(){
        this.gameObject.SetActive(false);
        timer.startTimer();
    }
}
