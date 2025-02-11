using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class Slime : Enemy
{
    public bool isBoss = false;
    public GameObject slimePrefab;
    private float lastSpawnAt = -9999f;
    private float spawnInterval = 5f;

    protected override void EnemyAttackAnimation()
    {

        return;
    }

    protected override void EnemyMoveAnimation(float x, float y)
    {

        return;
    }

    protected override void EnemyIdleAnimation()
    {
        //anim.SetBool("Running", false);
        return;
    }

    protected override void EnemyUpdate()
    {
        if (isBoss)
        {
            // spawn more slimes on a timer
            if (Time.time > lastSpawnAt + spawnInterval)
            {
                //do the attack
                lastSpawnAt = Time.time;

                System.Random rand = new System.Random();
                int num = rand.Next(1, 5);
                int direction;
                if (target.position.x > transform.position.x)
                    direction = 1;
                else
                    direction = -1;
                for (int i = 0; i < num; i++)
                {
                    Vector3 randomPos = new Vector3(direction * UnityEngine.Random.Range(5, 25), UnityEngine.Random.Range(0, 10), 0);
                    Instantiate(slimePrefab, transform.position + randomPos, Quaternion.identity);
                }

            }

        }
        
    }


}
