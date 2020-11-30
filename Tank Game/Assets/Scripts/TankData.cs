using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    /// <summary>
    /// This script holds the variables for the human controller.
    /// So it gets refernced inside of the other scripts.
    /// </summary>
    public TankMover mover;
    public float speed;
    public float rotateSpeed;
    public float damageDone;
    public float shootDelay;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<TankMover>();
    }
    public void Shooter()
    {
        Debug.Log("NOOOOOOO WHYYYYYYY");
    }
}
