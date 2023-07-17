using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    private RectTransform rt;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomPos(){
        rt.localPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
    }
}
