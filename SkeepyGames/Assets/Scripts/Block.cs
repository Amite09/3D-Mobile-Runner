using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Helper.move){
            Move();
        }

        if(transform.position.z < 0){
            Destroy(gameObject);
        }
    }

    void Move(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (Time.deltaTime * speed));
    }

    void OnTriggerEnter(Collider col){
        if (col.transform.TryGetComponent(out Player player)) {
            Helper.move = false;
                player.Die();
            }
    }

}
