using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public TankData data;
    public enum ControlType { WASD, ArrowKeys };
    public ControlType controlType;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = Vector3.zero;
        if (controlType == ControlType.WASD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                directionToMove = transform.forward;
            }

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
            data.mover.MoveStraight(directionToMove);
        }

    }
}
