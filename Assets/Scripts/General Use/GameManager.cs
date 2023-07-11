using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int hp = 3; 
    public string[] teethGames;
    public static int level;
    public static string deathMessage = "Test Message";
    public Animator transition;
    public static bool loading = false;
    public static bool added;
    private HealthScript bBar;
    private static bool lostLevel = false;
    private static bool playingLevel = false;
    void Start(){
        transition = GameObject.FindWithTag("Transition").GetComponent<Animator>();
        if(lostLevel){
            transition.transform.GetComponent<Image>().color = Color.red;
        }else if(playingLevel){
            transition.transform.GetComponent<Image>().color = Color.green;
        }else{
            transition.transform.GetComponent<Image>().color = Color.black;
        }
        if(GameObject.FindWithTag("BusBar") != null){
            bBar = GameObject.FindWithTag("BusBar").GetComponent<HealthScript>();
            bBar.setHp(hp);
        }
        lostLevel = false;
    }
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
            lostLevel = true;
            playingLevel = false;
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
            playingLevel = true;
            added = true;
            level += 1;
            if(level >= teethGames.Length){
                goStafeSelect();
            }else{
                loadLevel(teethGames[level]);
            }
        }
    }
    public void goStageSelect(){
        loadLevel("Stage Select");
    }
    public void replayLevel(){
        playingLevel = false;
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
            StartCoroutine(transitionLevel(name));
        }
    }
    IEnumerator transitionLevel(string name){
        if(lostLevel){
            transition.transform.GetComponent<Image>().color = Color.red;
        }else if(playingLevel){
            transition.transform.GetComponent<Image>().color = Color.green;
        }else{
            transition.transform.GetComponent<Image>().color = Color.black;
        }
        transition.SetTrigger("LeaveScreen");
        yield return new WaitForSeconds(1.25f);
        loading = false;
        added = false;
        SceneManager.LoadScene(name);
    }
    public void quitGame(){
        Application.Quit();
    }
}
