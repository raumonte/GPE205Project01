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
    public float shotCoolDown; //This float will be used as a cool down for how long they are able to shoot again.
    public float bulletSpeed = 1.0f; //This float will be used to edit the speed of the bullet and see how far it travel
    public Transform spawnpointTransform;
    // Start is called before the first frame update
    public override void Start()
    {
        cc = GetComponent<CharacterController>();
        data = GetComponent<TankData>();
        cc.slopeLimit = 90f;
        cc.stepOffset = 0.00f;
        shotCoolDown = Time.time;
        
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
    public virtual void Shoot(GameObject bullet,Vector3 offset, float fireRateModifier)        //Shoot A Shell
    {
        if (Time.time >= shotCoolDown)                         //If You Waited The Reload Time
        {
            Debug.Log("Shoot successful");
                        
            //Instantiate shell
            GameObject shell = GameObject.Instantiate(bullet, spawnpointTransform.position + (spawnpointTransform.forward * offset.x) + (spawnpointTransform.up * offset.y), spawnpointTransform.rotation);
            //Add force
            shell.GetComponent<Rigidbody>().AddForce(shell.transform.forward * bulletSpeed);

            shotCoolDown = Time.time + (bullet.GetComponent<Bullet>().fireRate * (1 / fireRateModifier));
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
