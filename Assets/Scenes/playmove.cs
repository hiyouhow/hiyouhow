using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmove : MonoBehaviour
{   
    public float speed;
    public float jumpforce;

    private float moveinput;
    private Rigidbody2D rb;
    private bool isgrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        isgrounded=Physics2D.OverlapCircle(groundcheck.position,checkradius,whatisground);

        moveinput=Input.GetAxis("Horizontal");
        Debug.Log(moveinput);
        rb.velocity= new Vector2(moveinput*speed,rb.velocity.y);
    }
     void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity=Vector2.up*jumpforce;
        }

    }
}
