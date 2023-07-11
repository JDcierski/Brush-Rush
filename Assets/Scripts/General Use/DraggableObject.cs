using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public Camera myCam;
    
    private float startXPos;
    private float startYPos;
    public bool isHovered;
    private bool isDragging = false;

    void Start(){
        isHovered = false;
        isDragging = false;
    }
    void Update()
    {
        myCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        if(Input.GetMouseButtonDown(0) && isHovered){
            OnMouseDown();
        }
        if(Input.GetMouseButtonUp(0)){
            OnMouseUp();
        }
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        if(isDragging){
            if(TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2D)){
                rb2D.velocity = new Vector2(0f, 0f);
            }
        }
        isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if(!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, transform.localPosition.z);
    }
    void OnMouseEnter() {
        isHovered = true;
    }

    void OnMouseExit() {
        isHovered = false;
    }

}

