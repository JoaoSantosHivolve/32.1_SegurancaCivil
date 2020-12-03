using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningLimiter : MonoBehaviour
{
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        var rot = transform.eulerAngles;
        var rotY = rot.y;
        if (rotY <= -80) rotY = -80;
        if (rotY >= 80) rotY = 80;

        transform.localEulerAngles = new Vector3(rot.x, rotY, rot.z);
        transform.localPosition = new Vector3(0.4f, 0, 0);
    }
}
