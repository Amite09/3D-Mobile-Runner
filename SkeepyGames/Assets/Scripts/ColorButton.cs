using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ColorButton : MonoBehaviour
{
    public string[] colors;
    public Material[] materials;
    public Transform player;
    public ParticleSystem ps;
    private string lastColor;
    [SerializeField]
    private float timeElapsed;

    void Update(){
        timeElapsed -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A)){
            ChangeColor("Red");
        }
        if(Input.GetKeyDown(KeyCode.S)){
            ChangeColor("Blue");
        }
        if(Input.GetKeyDown(KeyCode.D)){
            ChangeColor("Yellow");
        }

    }

    public void ChangeColor(string pressedColor) {

        string finalColor;
        if ((lastColor == "Blue" && pressedColor == "Red" || lastColor == "Red" && pressedColor == "Blue") && timeElapsed > 0)
            finalColor = "Purple";
        else if ((lastColor == "Blue" && pressedColor == "Yellow" || lastColor == "Yellow" && pressedColor == "Blue") && timeElapsed > 0)
            finalColor = "Green";
        else if ((lastColor == "Red" && pressedColor == "Yellow" || lastColor == "Yellow" && pressedColor == "Red") && timeElapsed > 0)
            finalColor = "Orange";
        else 
            finalColor = pressedColor;
        player.GetComponent<SkinnedMeshRenderer>().material = materials[Array.IndexOf(colors, finalColor)];
        player.GetComponent<Player>().currentColor = finalColor;
        lastColor = pressedColor;
        ps.startColor = materials[Array.IndexOf(colors, finalColor)].color;
        ps.GetComponent<ParticleSystem>().Play();
        timeElapsed = 0.1f;
    }


}
