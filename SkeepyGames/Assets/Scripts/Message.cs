using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{

    private int WALLS_PER_MESSAGE = 10;

    private int lastScore;
    [SerializeField]
    private Text text;

    // Update is called once per frame
    void Update()
    {
        if (Helper.wallsOpened % WALLS_PER_MESSAGE == 0 && Helper.wallsOpened != lastScore){
            lastScore = Helper.wallsOpened;
            ShowMessage();
            
        }
    }


    void ShowMessage() {
        text.text = "Amazing! You've opened " + lastScore.ToString() + " Walls!";
        StartCoroutine(ColorMessage());

    }

    IEnumerator ColorMessage(){
        for (int i = 0; i < 3 ; i++){
            text.color = Color.blue;
            yield return new WaitForSeconds(0.5f);
            text.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            text.color = Color.yellow;
            yield return new WaitForSeconds(0.5f);
        }
        text.text = "";
    }

}
