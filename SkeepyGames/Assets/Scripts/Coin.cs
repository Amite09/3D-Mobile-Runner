using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < player.transform.position.z - 3){ //destroy coin if its behind the player
            Destroy(gameObject);
        }

        if (transform.position.y > 2){ // falldown on spawn
            transform.position -= new Vector3(0,2f,0);
        }

        transform.Rotate(Vector3.up, Space.Self); 
    }


    void OnTriggerEnter(Collider col){
        if (col.transform.TryGetComponent(out Player player)) {
            Helper.coins += 1;
            Destroy(gameObject);
        }
    }

}
