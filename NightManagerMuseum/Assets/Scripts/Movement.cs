using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{

    public float speed;
    public GameObject player;
    public Animator animator;
    public AudioManager audioManager;
    public AudioSource walkingSFX;
    public bool isPlaying = false;


    private Rigidbody2D rb;
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

    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
