using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDestroyController : MonoBehaviour {
    public void DestructEnemy(float delay) {
        Destroy(gameObject, delay);
    }

    public void DestructBoss(float delay)
    {
        Destroy(gameObject, delay);

        Debug.Log("You win!");
        SceneManager.LoadScene(4);
    }
}