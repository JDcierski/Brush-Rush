using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int hp; 
    public string[] teethGames;
    public static int level;
    public static string deathMessage = "Test Message";
    public GameObject transition;
    public static bool loading = false;
    public static bool added;
    
    public int getHp(){
        return hp;
    }
    public void setHp(int h){
        hp = h;
        if(hp == 0){
            lose("An Admin set hp to 0");
        }
    }
    public void loseHp(){
        if(!added){
            added = true;
            hp--;
            if(hp == 0){
                lose(GameObject.FindWithTag("GoalManager").GetComponent<GoalManager>().getDeathMessage());
            }else{
                deathMessage = GameObject.FindWithTag("GoalManager").GetComponent<GoalManager>().getDeathMessage();
                loadLevel("Retry");
            }
        }
    }
    public void lose(string dm){
        deathMessage = dm;
        loadLevel("LossScreen");
    }
    public void playLevel(int l){
        level = l;
        replayLevel();
    }
    public void nextLevel(){
        if(!added){
            added = true;
            level += 1;
            if(level >= teethGames.Length){
                loadLevel("Stage Select");
            }
            loadLevel(teethGames[level]);
        }
    }
    public void replayLevel(){
        loadLevel(teethGames[level]);
    }
    public void playScene(string scene){
        loadLevel(scene);
    }

    public string getDeathMessage(){
        return deathMessage;
    }

    public void loadLevel(string name){
        if(!loading){
            loading = true;
            Instantiate(transition);
            StartCoroutine(transitionLevel(name));
        }
    }
    IEnumerator transitionLevel(string name){
        yield return new WaitForSeconds(1.25f);
        loading = false;
        added = false;
        SceneManager.LoadScene(name);
    }
}
