using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float tempSpeed;
    public Transform ttf;
    // Start is called before the first frame update
    void Start()
    {
        //
        ttf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ttf.position = transform.position + (transform.forward * tempSpeed * Time.deltaTime);
    }
}
