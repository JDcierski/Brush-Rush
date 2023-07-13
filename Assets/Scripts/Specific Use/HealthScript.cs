using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public RectTransform healthBar;

    public int health = 3;

    public void setHp(int newHP)
    {
        health = newHP;

        if(health == 3)
        {
            healthBar.localPosition = new Vector3(0f, 250f, 0f);
        }
        else if(health == 2)
        {
            healthBar.localPosition = new Vector3(0f, 50f, 0f);
        }
        else if(health == 1)
        {
            healthBar.localPosition = new Vector3(0f, -125f, 0f);
        }
        else
        {
            healthBar.localPosition = new Vector3(0f, -225f, 0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
