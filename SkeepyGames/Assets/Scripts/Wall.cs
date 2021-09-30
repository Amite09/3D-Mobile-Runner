using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    Transform left, right, leftAxis, rightAxis;
    private AudioSource clip;
    public string color;
    private Rigidbody rb;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        clip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Helper.move && transform.position.y > 5.5){ //falldown on spawn
            transform.position -= new Vector3(0,2f,0);
        }
        if (open){ 
            Open();
        }

    }

    void Open(){ //open the d
        left.RotateAround(leftAxis.position, Vector3.up, Time.deltaTime * -300f);
        right.RotateAround(rightAxis.position, Vector3.up, Time.deltaTime * 300f);
        if (right.localRotation.y > 0.7 || left.localRotation.y < -0.7){
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider col){
        if (col.transform.TryGetComponent(out Player player)) {
            if (color == player.currentColor){ //if player matches wall color open the door and add points
                clip.Play();
                Helper.score += 10;
                Helper.wallsOpened += 1;
                open = true;
                player.MoveBack();
            } else { // if colors dont match player die
                Helper.move = false;
                player.Die();
            }
        }
    }

}
