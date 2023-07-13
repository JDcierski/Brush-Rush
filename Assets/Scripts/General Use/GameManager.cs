using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int hp = 3; 
    public string[] easyGames;
    public string[] mediumGames;
    public string[] hardGames;
    public static string[] activeGames;
    private static bool easy = false;
    private static bool medium = false;
    private static bool hard = false;
    private static bool remix = false;
    public static bool easyComplete = false;
    public static bool mediumComplete = false;
    public static bool hardComplete = false;
    public static bool remixComplete = false;
    public static int level;
    public static string deathMessage = "Test Message";
    public Animator transition;
    public static bool loading = false;
    public static bool added;
    private HealthScript bBar;
    private static bool lostLevel = false;
    private static bool playingLevel = false;
    private float remixCount;
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
    public bool getEasyComplete(){
        return easyComplete;
    }
    public bool getMediumComplete(){
        return mediumComplete;
    }
    public bool getHardComplete(){
        return hardComplete;
    }
    public bool getRemixComplete(){
        return remixComplete;
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
    public void equalStringArray(string[] tis, string[] that){
        tis = new string[that.Length];
        for(int i = 0; i < that.Length; i++){
            tis[i] = that[i];
        }
    }
    public void loadEasy(){
        easy = true;
        activeGames = easyGames;
        playLevel(0);
    }
    public void loadMedium(){
        medium = true;
        activeGames = mediumGames;
        playLevel(0);
    }
    public void loadHard(){
        hard = true;
        activeGames = hardGames;
        playLevel(0);
    }
    public void loadRemix(){
        remixCount = 0;
        remix = true;
        activeGames = hardGames;
        playLevel(0);
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
            if(remix){
                remixCount++;
                if(remixCount >= 15){
                    remixComplete = true;
                }
                level = Random.Range(0, activeGames.Length);
                loadLevel(activeGames[level]);
            }else if(level >= activeGames.Length){
                if(easy){
                    easyComplete = true;
                }else if(medium){
                    mediumComplete = true;
                }else if(hard){
                    hardComplete = true;
                }
                easy = false;
                medium = false;
                hard = false;
                remix = false;
                hp = 3;
                loadLevel("WinScreen");
            }else{
                loadLevel(activeGames[level]);
            }
        }
    }
    public void goStageSelect(){
        easy = false;
        medium = false;
        hard = false;
        remix = false;
        hp = 3;
        loadLevel("Stage Select");
    }
    public void replayLevel(){
        playingLevel = false;
        loadLevel(activeGames[level]);
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
            transition.transform.parent.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
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
