using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //public TankData data; //The Tank that is controlled by the AI
    public List<Waypoint> waypoints; //This gives the designer control of the amount of set waypoints.
    public int currentWaypointIndex = 0; //This keeps in track the ampunt of Waypoints hit.
    public float closeEnoughForWaypoints = 0.1f;

    public enum PatrolType { Stop, Loop, PingPong, Random }
    public PatrolType patrolType;
    public bool isPatrolling = true;
    public bool isPatrolForward = true;

    public enum AIStates { Idle, Spin , Attack }
    public AIStates currentState = AIStates.Idle;
    public enum AIAvoidanceState {Normal, TurnToAvoid, MoveToAvoid }
    public AIAvoidanceState currentAvoidanceState;
    public float lastStateChangeTime;
    public float lastAvoidanceStateChangeTime;
    //targeting
    public GameObject target;

    public float fieldOfView = 60.0f;
    public float viewDistance = 10.0f;
    public float hearingSensitivity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isPatrolling)
        {
            DoPatrol();
        }
    }
    public void ChangeState (AIStates newState)
    {
        //Set current state.
        currentState = newState;
        //Keep track of the time when in the state
        lastStateChangeTime = Time.time;
    }
    public void ChangeAvoidenceState (AIAvoidanceState newState)
    {
        //setting a state
        currentAvoidanceState = newState;
        //Keep track of the time when in the state.
        lastAvoidanceStateChangeTime = Time.time;
    }
    //this would try to go past a wall by continuosly checking if the wall is pasable after a bit of time.
    public bool CanMoveForward (float distance)
    {
        return !Physics.Raycast(data.transform.position, data.transform.forward, distance);
    }
    public void DoPatrol()
    {
        if (currentAvoidanceState == AIAvoidanceState.Normal) { 
        //TODO: Turn towards our waypoint
        data.mover.MoveTo(waypoints[currentWaypointIndex].transform);
        
        //TODO: Move Forward
        
        //If we are "close enough" to the waypoint, BEgin to tansit to the next waypoint.
        if (Vector3.Distance(data.transform.position, waypoints[currentWaypointIndex].transform.position) < closeEnoughForWaypoints)
        {

            //If Patrol forward is true it will make the tank move to the next point and follow the other states.
            if (isPatrolForward)
            {
                currentWaypointIndex++;
            }

            //If it is set to false it should go back to the previous number until it would reach to the 1st waypoint from the beginning.
            else
            {
                currentWaypointIndex--;
            }

            // Loop End
            if (currentWaypointIndex > waypoints.Count - 1 || currentWaypointIndex < 0)
            {

                //Begins the loop where once the AI reaches the last waypoint it would go back to the first waypoint and be in an indefinite loop.
                if (patrolType == PatrolType.Loop)
                {
                    currentWaypointIndex = 0;
                }

                //Has the AI choose a rondom set of numbers from 0 to the amount of waypoints listed.
                else if (patrolType == PatrolType.Random)
                {
                    currentWaypointIndex = Random.Range(0, waypoints.Count);
                }

                //This would have the AI stop what they're doing and not look or do anything.
                else if (patrolType == PatrolType.Stop)
                {
                    isPatrolling = false;
                }

                //TODO: Have a pingpong ball effect where the AI would reach the final waypoint and go backwards from where they came from.
                else if (patrolType == PatrolType.PingPong)
                {
                    isPatrolForward = !isPatrolForward;
                    //Make sure our waypoints are within range
                    currentWaypointIndex = Mathf.Clamp(currentWaypointIndex, 1, waypoints.Count - 1);
                  
                }

            }
        }
      }
    }
    public void DoTargetPlayer()
    {
        //sets target as the first player that is added to the list in the game manager
        target = GameManager.instance.players[0].data.gameObject;
    }
    public void DoAttackPlayer()
    {
        //Set Player as target
        DoTargetPlayer();
        //Attack Target
        DoAttackTarget();
    }
    public void DoLeadAttackTarget()
    {
        //If our target is not null
        if (target != null)
        {
            //move to target
            data.mover.MoveTo(target.transform);
        }
        //Move to 1 unit In Front of target
        //Shoot
        //data.Shoot();

    }
    public void DoAttackTarget()
    {
        //If our target is not null
        if (target != null)
        {
            //move to target
            data.mover.MoveTo(target.transform);
        }
        //Shoot
        //data.Shoot();

    }
    public void DoSpin()
    {
        //just rotate
        data.mover.Rotation(true);
    }
    //This is a state where once the AI finds the player to begin to attack them as soon as they see them on sight.
    public void AttackPlayer() { }
    //This is an Idle state where it will not do anything or have an Idle animation until the AI hears the player around them.
    public void Idle() { }
    ///Once the AI hears the player run around it would go to the last area that the AI had heard the sound.
    public void TurnToFindPlayer()
    {
        //TODO: Set target as nearest player
        //TODO: Turn towards target's set position.
    }
    //Once the AI finds the player it will use this state to shoot at said player.
    public void DoShoot() 
    {
        //Just shooting from the Tank itself.
        //data.Shoot();
    }
    public bool CanSee(GameObject target)
    {
        // TODO: Line of sight
        //Get Vector to target
        Vector3 vectorToTarget = target.transform.position - data.transform.position;
        //Get angle between forward and vectorToTarget
        float angle = Vector3.Angle(data.transform.forward, vectorToTarget);
        //if that > my field of view, they are out of view
        if (angle > fieldOfView)
        {
            return false;
        }
        // TODO: Field of View Checks
        //Raycast forward for the distance
        RaycastHit hitInfo;
        // if it hits something within viewDistance
        if ( Physics.Raycast(data.transform.position, data.transform.forward, out hitInfo, viewDistance))
        {
            //if it hits something, and it is not my target , i can't see my target
            if (hitInfo.collider !=target)
            {
                //I can't see my target
                return false;
            }
        }
        return true;
    }
    public bool CanHear(GameObject target)
    {
        //TODO: Distance Check and 
        if (Vector3.Distance(target.transform.position, data.transform.position) < hearingSensitivity)
        {
            //TODO: Soundmaker level check

            //then i can hear you
            return true;
        }
        return false;
    }
}
