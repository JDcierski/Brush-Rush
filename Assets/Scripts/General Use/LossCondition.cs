using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossCondition : MonoBehaviour
{
    public int numToLose;
    private int num;
    public string deathMessage;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }
    public void incNum(int n){
        num += n;
        if(num >= numToLose){
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().loseWithMessage(deathMessage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
