using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public Texture2D grabTexture;
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Cursor.SetCursor(grabTexture, Vector2.zero, CursorMode.Auto);
        }
        if(Input.GetMouseButtonUp(0)){
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
        
    }
}
