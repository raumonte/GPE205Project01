using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : Controller
{
    public enum ControlType { WASD, ArrowKeys };
    public ControlType controlType;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.players.Add(this);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 directionToMove = Vector3.zero;
        if (controlType == ControlType.WASD)
        {
            //When the player presses the W key it begins to move forward.
            if (Input.GetKey(KeyCode.W))
            {
                directionToMove = transform.forward;
            }
            //When the player presses the W key it begins to rotate to the
            if (Input.GetKey(KeyCode.A))
            {
                data.mover.Rotation(false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                directionToMove = -transform.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                data.mover.Rotation(true);
            }
            data.mover.MoveStraight(directionToMove);
            if (Input.GetKey(KeyCode.Space))
            {
                data.mover.Shoot(data.bullet, data.shootOffset, data.fireRateModifier);
            }
        }
        if (controlType == ControlType.ArrowKeys)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionToMove = transform.forward;

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                data.mover.Rotation(false);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                data.mover.Rotation(true);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                directionToMove = -transform.forward;
            }
            if (Input.GetKey(KeyCode.Keypad0))
            {
                data.mover.Shoot(data.bullet, data.shootOffset, data.fireRateModifier);
            }
            data.mover.MoveStraight(directionToMove);

        }

    }
    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this);
    }
}
