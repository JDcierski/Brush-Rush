using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barPiece : MonoBehaviour
{

    public GameObject bar;
    public Image image;

    public float fillAmount;

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = fillAmount;
        bar.transform.rotation = Quaternion.Euler(0, 0, fillAmount * 360);
        
    }

    public void setFillAmount(float fA){
        fillAmount = fA;
    }
}
