using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Lightning : MonoBehaviour
{
    public float life = 3;
 
    void Awake() {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}