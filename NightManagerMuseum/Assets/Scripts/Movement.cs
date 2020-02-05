using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{

    public float speed;
    private Rigidbody2D rb;

    private Vector2 moveVelocity;
    
    //private Vector2 moveVelocity;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        walkingSFX = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        

        float runSpeed = Input.GetAxisRaw("Horizontal");
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //moveVelocity = moveInput.normalized * speed;

        animator.SetFloat("PlayerSpeed", Mathf.Abs(runSpeed));

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {

            characterScale.x = 0.1f;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            characterScale.x = -0.1f;
        }
        transform.localScale = characterScale;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            isPlaying = true;
            audioManager.Play("PlayerWalkSFX");
        }

        if (isPlaying == true && (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")))
        {
            //Stop the audio
            walkingSFX.Stop();



            //if (runSpeed == 0.0f)
            //{
            //    animator.SetBool("isMoving", false);
            //}
            //else
            //{
            //    animator.SetBool("isMoving", true);
            //}
        }

        //private void FixedUpdate()
        //{
        //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        //}

    }
}
