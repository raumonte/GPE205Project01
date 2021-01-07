using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public float tempSpeed;
    public Transform ttf;
    public float setTime;
    public float countdown;
    // Start is called before the first frame update
    public virtual void Start()
    {
        countdown = setTime;
        //
        ttf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ///if (countdown <= 0)
        ///{
        ///    Debug.Log("reset");
        /// countdown = setTime;
        ///}
        ///ttf.position = transform.position + (transform.forward * tempSpeed * Time.deltaTime);
        /// 
        /// countdown -= Time.deltaTime;
    }
    public virtual void MoveStraight(Vector3 direction) { }
    public virtual void MoveTo(Transform targetTransform){}
    public virtual void Rotation(bool isClockwise) { }
    public virtual void RotateTowards(Transform targetTransform) { }
}
