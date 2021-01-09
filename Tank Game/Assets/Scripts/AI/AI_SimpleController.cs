using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SimpleController : AIController
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                //Do our "update"
                DoTargetPlayer();
                Idle();
                if (CanSee(target))
                {
                    currentState = AIStates.Attack;
                }
                if (CanHear(target))
                {
                    currentState = AIStates.Spin;
                }
                break;
            case AIStates.Spin:
                //TODO: "Update equivalent for this state
                DoSpin();
                //TODO: Check for state changes.
                if (CanSee(target))
                {
                    DoAttackPlayer();
                }
                //TODO: Exit Time
                break;
            case AIStates.Attack:
                //TODO: "Update equivalent for this state
                DoAttackPlayer();
                //TODO: Check for state changes.
                if (!CanSee(target))
                {
                    currentState = AIStates.Spin;
                }
                break;
            default:
                //IF we get here, something went wrong within the code
                currentState = AIStates.Idle;
                break;
        }
    }
}
