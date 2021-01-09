using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    /// <summary>
    /// This script holds the variables both the AI and the player tank so they can pull from the same area.
    /// So it gets refernced inside of the other scripts.
    /// </summary>
    public int health = 20; //This variable will set the amount of default health for both the AI and Player
    public TankMover mover; //Whenever the Tank Data script is called it will be able to call the mover script.
    public float speed;     //This sets the speed of the moving tanks.
    public float rotateSpeed;   //Sets the rotate speed of the tanks
    public float damageDone;    //Sets the amount of damage done to the player or AI.
    public float shootDelay;    //This will have a cooldown to each shot done by either the AI or Player
    public GameObject bullet;   //This will be able to connect the GameObject to the bullet.
    public Vector2 shootOffset = new Vector2(0.8f, 0.25f);
    public float fireRateModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        fireRateModifier = Mathf.Max(fireRateModifier, 1);
        mover = GetComponent<TankMover>();
    }
    public void Shoot()
    {

    }
}
