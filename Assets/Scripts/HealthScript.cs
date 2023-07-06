using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public GameObject healthBar;

    public int health = 3;

    public void SetHP(int newHP)
    {
        health = newHP;

        if(health == 3)
        {
            healthBar.transform.position = new Vector3 (-9.3f, 4.3f, -1);
        }
        else if(health == 2)
        {
            healthBar.transform.position = new Vector3 (-9.3f, 0, -1);
        }
        else if(health == 1)
        {
            healthBar.transform.position = new Vector3 (-9.3f, -4.3f, -1);
        }
        else
        {
            healthBar.transform.position = new Vector3 (-40, 0, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(health == 3)
        {
            healthBar.transform.position = new Vector3 (-9.3f, 4.3f, -1);
        }
        else if(health == 2)
        {
            healthBar.transform.position = new Vector3 (-9.3f, 0, -1);
        }
        else if(health == 1)
        {
            healthBar.transform.position = new Vector3 (-9.3f, -4.3f, -1);
        }
        else
        {
            healthBar.transform.position = new Vector3 (-40, 0, 0);
        }
    }
}
