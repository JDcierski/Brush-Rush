using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    
    public bool achieved;
    public string deathMessage;
    public void achieveGoal(){
        achieved = true;
    }
    public void failGoal(){
        achieved = false;
    }
    public void toggleGoal(){
        achieved = !achieved;
    }
}
