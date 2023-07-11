using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    
    public GameObject easyStar;
    public GameObject mediumStar;
    public GameObject hardStar;
    public GameObject remix;
    public GameObject remixStar;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        easyStar.SetActive(gm.getEasyComplete());
        mediumStar.SetActive(gm.getMediumComplete());
        hardStar.SetActive(gm.getHardComplete());
        remix.SetActive(gm.getEasyComplete() && gm.getMediumComplete() && gm.getHardComplete());
        remixStar.SetActive(gm.getRemixComplete());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
