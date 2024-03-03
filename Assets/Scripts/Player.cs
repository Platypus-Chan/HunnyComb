
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1f;             //Floating point variable to store the player's movement speed.
    private bool facingRight = true;
    public float jumpForce = 500f;

    public Transform groundcheck;
    public LayerMask whatIsGround;
    private bool grounded = true;
    float groundRadius = 0.2f;

    public Text healthText;
    public Text coinText;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private int health = 3;
    private int coin = 0;

    private Animator leo;
    private Rigidbody2D mara;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Animator heartAnimator1;
    private Animator heartAnimator2;
    private Animator heartAnimator3;

    // Start is called before the first frame update
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        mara = GetComponent<Rigidbody2D>();
        leo = GetComponent<Animator>();
        heartAnimator1 = heart1.GetComponent<Animator>();
        heartAnimator2 = heart2.GetComponent<Animator>();
        heartAnimator3 = heart3.GetComponent<Animator>();
        SetCountText();
    }

    // Update is called on one frame at a time
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
         //Call the AddForce function of our Rigidbody2D mara supplying movement multiplied by speed to move our player.
        mara.velocity = new Vector2(moveHorizontal * speed, mara.velocity.y);

        if (mara.velocity.magnitude < 0.001f) {
            leo.SetBool("move" , false);
            leo.SetBool("idle" , true);
            leo.SetBool("jump", false);
        }
        else {
            leo.SetBool("move" , true);
            leo.SetBool("idle" , false);
            leo.SetBool("jump", false);
        }

        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();

        // grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            mara.AddForce(new Vector2(0, jumpForce));
            leo.SetBool("jump" , true);
            leo.SetBool("idle", false);
            leo.SetBool("move", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            System.Random r = new System.Random();
            int i = r.Next(1,4);
            switch (i) {
                case 1: 
                    leo.SetBool("attack1" , true);
                    leo.SetBool("attack2" , false);
                    leo.SetBool("attack3" , false);
                    break;
                case 2:
                    leo.SetBool("attack2" , true);
                    leo.SetBool("attack1" , false);
                    leo.SetBool("attack3" , false);
                    break;
                case 3:
                    leo.SetBool("attack3" , true);
                    leo.SetBool("attack1" , false);
                    leo.SetBool("attack2" , false);
                    break;
            }
            
            
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            leo.SetBool("attack3" , false);
            leo.SetBool("attack1" , false);
            leo.SetBool("attack2" , false);

        }

        // if the player goes below surface, his health will decrease
        if (transform.position.y < -10)
            LoseHealth(1);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Thorns"))
        {
            LoseHealth(1);
        }
        /*
        if (other.gameObject.CompareTag("Souls"))
        {
            coin++;
            other.gameObject.SetActive(false);
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Banana"))
        {
            // enable the inner circle collider
            CircleCollider2D cc2D = other.gameObject.GetComponent<CircleCollider2D>();
            cc2D.enabled = true;

            LoseHealth(5);
        }
        else if (other.gameObject.CompareTag("Level1Exit"))
        {
            SceneManager.LoadScene("Scene2");
            CurrentScene = "Scene2";
        }
        else if (other.gameObject.CompareTag("Level2Exit"))
        {
            SceneManager.LoadScene("Win");
        }
        */
    }

    public void LoseHealth(int damage)
    {
        health-=damage;
        switch (health)
        {
            case 0: heart1.SetActive(false); break;
            case 1: heart2.SetActive(false); ; break;
            case 2: heart3.SetActive(false); ; break;
        }

        if (health <= 0)
        {
            // SceneManager.LoadScene("GameOver");
            Debug.Log("You died!");
            SceneManager.LoadScene(0);
        }
    }

    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        healthText.text = "Lives: " + health.ToString();

        //Check to see if player died
        if (health <= 0)
        {
            // SceneManager.LoadScene("GameOver");
            Debug.Log("You died!");
            Application.Quit();
        }

        coinText.text = "Souls: " + coin.ToString();
    }
}
