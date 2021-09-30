using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public string currentColor;
    public string currentLane;
    public int factor;
    public bool turning;
    public float step;
    public float completeTurn;
    public Animator anim;
    public Spawner spawner;
    private AudioSource clip;
    public ParticleSystem ps;


    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(turning){
            Turn();
        } 

        if(Helper.move){
            transform.root.position += Vector3.forward * Time.deltaTime * speed;
        }

    }

    public void SwitchLane(string direction){
        if (direction != currentLane && !turning){
            factor = direction == "Right" ? 1 : -1;
            turning = true;
        }
    }

    public void Turn(){
        transform.root.position += new Vector3(step * factor,0,0);
        completeTurn += step;
        if (completeTurn >= 2f) {
            turning = false;
            factor = 0;
            completeTurn = 0;
            if (transform.root.position.x >= 2) currentLane = "Right";
            else if (transform.root.position.x <= -2) currentLane = "Left";
            else currentLane = "Center";
            
        }

    }

    public void Run(){
        transform.root.position -= new Vector3(0,0,30);
        anim.Play("run");
    }

    public void Die(){
        clip.Play();
        anim.Play("falling");
        StartCoroutine(GameOver());
        
    }

    public void MoveBack() {
        StartCoroutine(MoveBackDelay());
    }

    IEnumerator GameOver(){
        yield return new WaitForSeconds(1.5f);
        Helper.gameOver = true;
    }

    public IEnumerator MoveBackDelay() {
        yield return new WaitForSeconds(0.5f);
        transform.root.position = new Vector3(transform.root.position.x, transform.root.position.y, 10);
        spawner.SpawnCoin();
        spawner.SpawnWall();

    }


}
