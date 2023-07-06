using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathMessage : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        this.gameObject.GetComponent<TMP_Text>().text = gm.getDeathMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
