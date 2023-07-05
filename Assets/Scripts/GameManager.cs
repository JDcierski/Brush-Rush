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
    
    public int getHp(){
        return hp;
    }
    public void setHp(int h){
        hp = h;
        if(hp == 0){
            lose("An Admin set hp to 0");
        }
    }
    public void loseHp(string dm){
        hp--;
        if(hp == 0){
            lose(dm);
        }else{
            deathMessage = dm;
            SceneManager.LoadScene("Retry");
        }
    }
    public void lose(string dm){
        deathMessage = dm;
        SceneManager.LoadScene("LossScreen");
    }
    public void playLevel(int l){
        level = l;
        replayLevel();
    }
    public void nextLevel(){
        level += 1;
        SceneManager.LoadScene(teethGames[level]);
    }
    public void replayLevel(){
        SceneManager.LoadScene(teethGames[level]);
    }
    public void playScene(string scene){
        SceneManager.LoadScene(scene);
    }
    public string getDeathMessage(){
        return deathMessage;
    }
}
