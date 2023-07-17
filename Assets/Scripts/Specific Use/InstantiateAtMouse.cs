using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAtMouse : MonoBehaviour
{
    public GameObject go;
    public Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeObject(){
        Vector3 mousePos = Input.mousePosition;
        mousePos = myCam.ScreenToWorldPoint(mousePos);
        GameObject thing = Instantiate(go);
        thing.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -9.5f);
    }
}
