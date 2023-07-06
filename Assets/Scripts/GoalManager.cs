using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    private GameObject[] goalObjects;
    private goal[] goals;
    private bool obtained;
    private GameManager gManage;
    // Start is called before the first frame update
    void Start()
    {
        gManage = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        obtained = false;
        obtainGoals();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkGoals()){
            gManage.nextLevel();
        }
    }
    public void obtainGoals(){
        goalObjects = GameObject.FindGameObjectsWithTag("Goal");
        goals = new goal[goalObjects.Length];
        for(int i = 0; i < goalObjects.Length; i++){
            goals[i] = goalObjects[i].GetComponent<goal>();
        }
        obtained = true;
    }
    public bool checkGoals(){
        if(!obtained || goals.Length == 0){
            obtainGoals();
        }
        foreach(goal g in goals){
            if(g.achieved == false){
                return false;
            }
        }
        obtainGoals();
        return doubleCheck();
    }
    public bool doubleCheck(){
        foreach(goal g in goals){
            if(g.achieved == false){
                return false;
            }
        }
        return true;
    }
    public string getDeathMessage(){
        foreach(goal g in goals){
            if(g.achieved == false){
                return g.deathMessage;
            }
        }
        return "There were no goals in the scene. This is a bug";
    }
}
