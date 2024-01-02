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
    private bool candash=true;
    private bool isdashing;
    public float dashspeed;
    public float dashcd=1f;

    private float dashtime=0.2f;

    private int m;
    // Start is called before the first frame update
    void Start()
    {
        this.rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(isdashing){
            return;
        }
        isgrounded=Physics2D.OverlapCircle(groundcheck.position,checkradius,whatisground);

        moveinput=Input.GetAxis("Horizontal");
        Debug.Log(moveinput);
        this.rb.velocity= new Vector2(moveinput*speed,this.rb.velocity.y);
    }
     void Update() {
        if(Input.GetKeyDown(KeyCode.Space)&&isgrounded==true){
            this.rb.velocity=Vector2.up*jumpforce;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)&&candash==true){
            StartCoroutine(dash());

        }

    }
    private IEnumerator dash(){
        m=0;
        if(moveinput<0){
            m=-1;
        }
        else if(moveinput>0){
            m=1;
        }
        candash=false;
        isdashing=true;
        float origrav=rb.gravityScale;
        rb.gravityScale=0f;
        rb.velocity=new Vector2(transform.localScale.x*dashspeed*m,0f);
        yield return new WaitForSeconds(dashtime);
        rb.gravityScale=origrav;
        isdashing=false;
        yield return new WaitForSeconds(dashcd);
        candash=true;

    }
}
