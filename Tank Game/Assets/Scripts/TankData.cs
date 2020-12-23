using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    /// <summary>
    /// This script holds the variables both the AI and the player tank so they can pull from the same area.
    /// So it gets refernced inside of the other scripts.
    /// </summary>
    public int health = 20;
    public TankMover mover;
    public float speed;
    public float rotateSpeed;
    public float damageDone;
    public float shootDelay;
    public GameObject bullet;
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
