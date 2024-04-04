using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour {
    public void DestructEnemy(float delay) {
        Destroy(gameObject, delay);
    }
}