using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRandomObjects : MonoBehaviour
{
    public GameObject[] objsToGen;
    public bool genOnStart;
    public int numObjects;
    public float xUpperBound;
    public float yUpperBound;
    public float zUpperBound;
    public float xLowerBound;
    public float yLowerBound;
    public float zLowerBound;
    // Start is called before the first frame update
    void Start()
    {
        if(genOnStart){
            generate();
        }
    }

    public void generate(){
        for(int i = 0; i < numObjects; i++){
            Instantiate(objsToGen[Random.Range(0, objsToGen.Length)], new Vector3(Random.Range(xUpperBound, xLowerBound), Random.Range(yUpperBound, yLowerBound), Random.Range(zUpperBound, zLowerBound)), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)), transform);
        }
    }
}
