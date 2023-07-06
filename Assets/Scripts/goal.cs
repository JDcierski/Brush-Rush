using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    
    public bool achieved;
    public void achieveGoal(){
        achieved = true;
    }
    public void toggleGoal(){
        achieved = !achieved;
    }
}
