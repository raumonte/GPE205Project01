using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public LayerMask tankMask;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public float speed = 1;                //Speed The Shell Flies At
    public float maxDamage = 1f;                 //Damage The Shell Deals
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
            // TODO: Add force to push tank
            //targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            // TODO: Begin to apply damage to the tank player script (in the tutorial has a script by itself for the health of the tank)
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            //if(!targetHealth)
            //continue;
            // TODO: Create damage by seeing how far it is from the explosion.
            //float damage = CalculateDamage (targetRigidbody.position);
            //Updates the amount of health left to the player.
            targetHealth.DamageAmount(10);
            
            Debug.Log("hit has been his");
        }
        // TODO: Spawn the particle affect of the explosion
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.main.duration);
        // TODO: Play the audio file for the explosion.
        explosionAudio.Play();
    }
    /*
     * private float CalculateDamage(Vector3 targetPosition)
    {
        
        //Calculate the amount of damage a target should take based on the position of the player
        Vector3 explosionToTraget = targetPosition - transform.position;
        float explosionDistance = explosionToTraget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        Debug.Log(damage);
        return damage;
        
    }
     */
}
