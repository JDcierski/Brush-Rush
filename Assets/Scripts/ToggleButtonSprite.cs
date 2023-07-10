using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonSprite : MonoBehaviour
{
    public bool toggle = false;
    public Sprite trueSprite;
    public Sprite falseSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggleImage(){
        toggle = !toggle;
        if(toggle){
            this.GetComponent<Image>().sprite = trueSprite;
        }else{
            this.GetComponent<Image>().sprite = falseSprite;
        }
    }
}
