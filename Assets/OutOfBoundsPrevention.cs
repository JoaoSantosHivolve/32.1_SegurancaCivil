using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsPrevention : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y <= 0)
        {
            Debug.Log("Transform Pos = " + transform.position);
            var pos = transform.position;
            transform.position = new Vector3(pos.x, 0.5f, pos.z);
            Debug.Log("Transform New Pos = " + transform.position);
        }
    }
}
