using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake(){
        Helper.gameOver = false;
        Helper.move = true;
        Helper.score = 0;
        Helper.wallsOpened = 0;
        Time.timeScale = 1;
        Helper.coins = PlayerPrefs.GetInt("coins", 0);
    }

}
