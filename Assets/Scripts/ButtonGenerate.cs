using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGenerate : MonoBehaviour
{
    public GameObject objToGen;
    public GameObject generatedObj;
    public bool genned = false;
    public void generate(){
        genned = true;
        generatedObj = Instantiate(objToGen);
    }
    public void unGenerate(){
        genned = false;
        Destroy(generatedObj);
    }
    public void toggleGen(){
        if(genned){
            unGenerate();
        }else{
            Generate();
        }
    }
}
