using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    /// <summary>
    /// This script stores the movement of the tank.
    /// </summary>
    private CharacterController cc;
    private TankData data;
    // Start is called before the first frame update
    public override void Start()
    {
        cc = GetComponent<CharacterController>();
        data = GetComponent<TankData>();
        cc.slopeLimit = 90f;
        cc.stepOffset = 0.00f;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    public override void MoveStraight (Vector3 direction)
    {
            cc.SimpleMove(direction * data.speed);
    }
    public override void Rotation(bool isClockwise)
    {
        if (isClockwise)
        {
            transform.Rotate(new Vector3(0, data.rotateSpeed * Time.deltaTime, 0));
        }
        else
        {
           transform.Rotate(new Vector3(0, -data.rotateSpeed * Time.deltaTime, 0));

        }
    }
    public override void MoveTo(Transform targetTransform)
    {
        //TODO:Rotate towards the waypoint
        RotateTowards(targetTransform);
        //Move towards the waypoint aka moving forward
        cc.SimpleMove(transform.forward * data.speed);
    }
    public override void RotateTowards (Transform targetTransform)
    {
        //Rotate towards the object. In this case the waypoint.
        Vector3 targetVector = targetTransform.position - transform.position;
        //Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        //Find a rotatuin that partway closer to the rotation than we are right now
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, data.rotateSpeed * Time.deltaTime );
        //Change to that new rotation
        transform.rotation = newRotation;
    }

}
