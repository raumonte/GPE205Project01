using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDirectionControl : MonoBehaviour
{
    public bool useRelativeRotation = true;
    private Quaternion relativeRotation;
    // Start is called before the first frame update
    private void Start()
    {
        relativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (useRelativeRotation)
        {
            transform.rotation = relativeRotation;
        }
    }
}
