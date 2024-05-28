using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCutsceneOn = true;
            animator.SetBool("CutScene1", true);
            Invoke(nameof(StopCutScene), 3f);
            
        }
    }

    private void StopCutScene()
    {
        isCutsceneOn = true;
        animator.SetBool("CutScene1", false);
        Destroy(gameObject);
    }

}
