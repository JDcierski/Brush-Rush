using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{

    public Image image;

    public float tempFilledAmount;

    public barPiece currBar;

    public float getFillAmount(){
        return image.fillAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempFilledAmount = image.fillAmount;
        image.fillAmount = currBar.getTime() / currBar.getMaxTime();
        if(image.fillAmount != tempFilledAmount){
            currBar.setChanged(true);
        }
    }
}
