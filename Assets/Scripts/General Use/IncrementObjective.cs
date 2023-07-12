using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementObjective : MonoBehaviour
{
    public int targetNum;
    private int num;
    private goal g;
    private Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        g = GetComponent<goal>();
        if(TryGetComponent<Slider>(out Slider s)){
            bar = GetComponent<Slider>();
        }
    }
    public void setValue(int n){
        num = n;
    }
    public void increment(int n){
        num += n;
    }

    // Update is called once per frame
    void Update()
    {
        if(num >= targetNum){
            g.achieveGoal();
        }
        if(bar != null){
            bar.value = 1f - ((float)num / (float)targetNum);
        }
    }
}
