using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject MenuUI;
    public Text score;
    public Text bestScore;
    public Transform player;

    public bool menuEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        MenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.gameOver && !menuEnabled){
            EnableMenu();
        }
    }


    public void EnableMenu(){
        menuEnabled = true;
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        score.text = Helper.score.ToString();
        if (Helper.score > PlayerPrefs.GetInt("best_score", 0)){
            PlayerPrefs.SetInt("best_score", Helper.score);
        }
        bestScore.text = PlayerPrefs.GetInt("best_score", 0).ToString();
    }

    void DisableMenu(){
        MenuUI.SetActive(false);
    }

    public void Retry(){      
        DisableMenu();
        StartCoroutine(goToScene("Game"));
    }

    public void Continue(){
        if (PlayerPrefs.GetInt("coins", 0) >= 50){ //pay 50 coins to continue
            Helper.coins -= 50;
            Helper.gameOver = false;
            menuEnabled = false;
            Helper.move = true;
            Time.timeScale = 1;
            player.GetComponent<Player>().Run();
            DisableMenu();
        }


    }


    IEnumerator goToScene(string scene){
        menuEnabled = false;
        yield return new WaitForSeconds(0f);
        SceneManager.LoadSceneAsync(scene);
    }
}
