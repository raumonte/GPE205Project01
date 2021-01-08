using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public LayerMask tankMask;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public float speed = 1;                //Speed The Shell Flies At
    public int damage = 1;                 //Damage The Shell Deals
    public float fireRate = 1.0f;          //Time Between Shots
    public float timeTillDestroy = 3;      //Time The Object Stays Before Being Destroyed
    public float explosionRadius = 5f;     //The Radius of how far the explosion will affect the players.
    public float explosionForce = 1000f;   //The amount of force that pushes the player.
    private void Start()
    {
        //once it instantiates if it is alive after tha set amount of time it would delete the object.
        Destroy(gameObject, timeTillDestroy);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Find all the tanks in the area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);
        //Having it to check them 
        for (int i = 0; i < colliders.Length; i++)
        {
            //Check the rigid body of the object
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            //Has it found a rigid body
            if (!targetRigidbody)
                continue;
            //Add force to push it
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            //
            //[Tank Health instance of the script]
        }
    }
}
