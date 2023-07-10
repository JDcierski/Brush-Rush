using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barPiece : MonoBehaviour
{

    public GameObject bar;

    public bool changed;

    public float time;

    public float maxTime;

    // Start is called before the first frame update

    public void setTime(float newTime)
    {
        this.time = newTime;
    }
    
    public void setMaxTime(float newMaxTime)
    {
        this.maxTime = newMaxTime;
    }

    public void setChanged(bool newChanged)
    {
        this.changed = newChanged;
    }

    public float getTime()
    {
        return this.time;
    }

    public float getMaxTime()
    {
        return this.maxTime;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(changed)
        {
            bar.transform.rotation = Quaternion.Euler(0, 0, time / maxTime * 360);
            changed = !changed;
        }
    }
}
