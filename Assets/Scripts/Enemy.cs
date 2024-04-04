using UnityEngine;
using System.Collections;

//The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class.
public abstract class Enemy : MonoBehaviour
{
    public LayerMask blockingLayer;         //Layer on which collision will be checked.

    protected CircleCollider2D boxCollider;      //The CircleCollider2D component attached to this object.
    protected Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.

    public float speed;
    public int playerDamage;                            //The amount of food points to subtract from the player when attacking.
    public int sightDistance;                        // how far can it see?
    public int attackInterval;                      // how many cycle between each attack

    protected int interval;
    //private Animator animator;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    protected Transform target;                           //Transform to attempt to move toward each turn.

    protected Animator anim;

    protected bool pauseMovement;

    //Protected, virtual functions can be overridden by inheriting classes.
    protected virtual void Start()
    {
        //Get a component reference to this object's CircleCollider2D
        boxCollider = GetComponent<CircleCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();

        pauseMovement = false;

        interval = 0;
    }

    protected void Update()
    {
        // determine which side to look
        int direction;
        // move towards player
        if (target.position.x > transform.position.x)
            direction = 1;
        else
            direction = -1;

        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;

        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2(direction * sightDistance, 0);

        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        boxCollider.enabled = false;

        //Cast a line from start point to end point checking collision on blockingLayer.
        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);

        //Re-enable boxCollider after linecast
        boxCollider.enabled = true;

        //Check if anything was hit
        if (hit.transform == null || pauseMovement)
        {
            EnemyIdleAnimation();
            return;
        }

        if (hit.transform.gameObject.CompareTag("Player"))
        {
            // if distance between player and enemy is very close, then player starts to lose health
            if (hit.distance < 1.5f)
            {
                if (interval > attackInterval)
                {
                    Player p = target.GetComponent<Player>();

                    p.LoseHealth(playerDamage);

                    // play sound
                    AudioSource aud = GetComponent<AudioSource>();
                    aud.enabled = true;

                    // do enemy attack animation
                    EnemyAttackAnimation();

                    // reset interval
                    interval = 0;
                }
                else
                    interval++;
            }
            else // otherwise start moving towards the player
            {
                rb2D.velocity = new Vector2(direction * speed, rb2D.velocity.y);

                //do enemy move animation
                EnemyMoveAnimation(direction * speed, rb2D.velocity.y);
            }
        }
    }

    protected abstract void EnemyAttackAnimation();


    protected abstract void EnemyIdleAnimation();

    protected abstract void EnemyMoveAnimation(float x, float y);

}