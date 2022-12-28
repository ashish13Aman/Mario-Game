using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=6f;
    private AudioSource audioManager;
    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool jumped;

    public float jumpPower= 12f;
    // Start is called before the first frame update
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioManager = GetComponent<AudioSource> ();

    } 

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
        
    }
    void FixedUpdate()
    {
        PlayerWalk();

    }
    void PlayerWalk()
    {
        float h= Input.GetAxisRaw("Horizontal");

        if(h>0){
            myBody.velocity = new Vector2(speed,myBody.velocity.y);
            ChangeDirection(1);
        }
        

        else if(h<0){
            myBody.velocity = new Vector2(-speed,myBody.velocity.y);
            ChangeDirection(-1);
        }
        else{
            myBody.velocity= new Vector2(0f,myBody.velocity.y);
        }

        anim.SetInteger("Speed",Mathf.Abs((int)myBody.velocity.x));

    }

    void ChangeDirection(int direction){
        Vector3 tempScale=transform.localScale;
        tempScale.x=direction;
        transform.localScale=tempScale;
    }
    void CheckIfGrounded(){
        isGrounded= Physics2D.Raycast (groundCheckPosition.position,Vector2.down,0.1f,groundLayer);

        if(isGrounded){
            //we jumped before
            if(jumped){
                jumped=false;
                anim.SetBool("Jump",false);
            }
        }
    }
    void PlayerJump(){
        if(isGrounded){
            if(Input.GetKey (KeyCode.Space)){
                jumped =true;
                audioManager.Play();
                myBody.velocity = new Vector2(myBody.velocity.x,jumpPower );
                anim.SetBool ("Jump",true);
            }
        }
    }
}
