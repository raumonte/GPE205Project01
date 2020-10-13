using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    /// <summary>
    /// This script stores the movement of the tank.
    /// </summary>
    private CharacterController cc;
    private TankData tankData;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        tankData = GetComponent<TankData>();
        cc.slopeLimit = 90f;
        cc.stepOffset = 0.00f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveStraight (Vector3 direction)
    {
            cc.SimpleMove(direction * tankData.speed);
    }
    public void Rotation(bool isClockwise)
    {
        if (isClockwise)
        {
            transform.Rotate(new Vector3(0, tankData.rotateSpeed * Time.deltaTime, 0));
        }
        else
        {
           transform.Rotate(new Vector3(0, -tankData.rotateSpeed * Time.deltaTime, 0));

        }
    }
}
