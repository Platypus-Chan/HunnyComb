using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class Slime : Enemy
{
    /*
    private ModalPanel modalPanel;

    private UnityAction myYesAction;

    private bool messageDisplayed;

    void Awake()
    {
        messageDisplayed = false;

        modalPanel = ModalPanel.Instance();

        myYesAction = new UnityAction(TestYesFunction);


    }

    void TestYesFunction()
    {
        messageDisplayed = true;
        pauseMovement = false;
    }
    */

    protected override void EnemyAttackAnimation()
    {


        return;
    }

    protected override void EnemyMoveAnimation(float x, float y)
    {
        /*
        if ( ! messageDisplayed )
        {
            pauseMovement = true;
            modalPanel.Choice("What is that? Is that a ... WOLF? ", TestYesFunction);
        }
        */
       // anim.SetBool("Running", true);

        return;
    }

    protected override void EnemyIdleAnimation()
    {
        //anim.SetBool("Running", false);
        return;
    }



}
