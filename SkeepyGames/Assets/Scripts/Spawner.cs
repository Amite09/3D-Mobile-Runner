using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Material[] colors;
    [SerializeField]
    private Wall wall;
    [SerializeField]
    private Coin coin;
    [SerializeField]
    private Vector3 wall_spawnPosition;
    [SerializeField]
    private Vector3[] coin_spawnPositions;
    public int wallsDeployed;
    public GameObject player;


    // Update is called once per frame
    void Start()
    {
        SpawnWall();
        SpawnCoin();   
    }

    public void SpawnWall(){       
        int i = Random.Range(0, wallsDeployed < 5 ? 3 : colors.Length);
        Wall _wall = Instantiate(wall, wall_spawnPosition, new Quaternion(0,0,0,0));
        _wall.transform.Find("LeftAxis").Find("Left").GetComponent<MeshRenderer>().material = colors[i];
        _wall.transform.Find("RightAxis").Find("Right").GetComponent<MeshRenderer>().material = colors[i];
        _wall.color = colors[i].name;
        wallsDeployed += 1;
    }

    public void SpawnCoin(){
        for (int j = 0; j < 4; j+=1){
            int i = Random.Range(0,coin_spawnPositions.Length);
            Vector3 finalPos = new Vector3(coin_spawnPositions[i].x, coin_spawnPositions[i].y, coin_spawnPositions[i].z + j * 10);
            Instantiate(coin, finalPos, Quaternion.identity);
        }
    }

}
