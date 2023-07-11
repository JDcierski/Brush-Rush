using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonGenerate : MonoBehaviour
{
    public GameObject objToGen;
    public GameObject generatedObj;
    public bool genned = false;
    public bool genOnPos;
    public Camera cam;
    void Start(){
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    public void generate(){
        if(genOnPos){
            Vector3 pos = Camera.main.ScreenToWorldPoint(gameObject.GetComponent<RectTransform>().localPosition);
            genned = true;
            generatedObj = Instantiate(objToGen, new Vector3 (pos.x + 17.78f, pos.y + 10f, -9.5f), Quaternion.Euler(0f, 0f, 0f));
        }else{
            genned = true;
            generatedObj = Instantiate(objToGen);
        }
    }
    public void unGenerate(){
        genned = false;
        Destroy(generatedObj);
    }
    public void toggleGen(){
        if(genned){
            unGenerate();
        }else{
            generate();
        }
    }
}
