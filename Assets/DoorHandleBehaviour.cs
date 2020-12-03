using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DoorHandleBehaviour : MonoBehaviour
{
    public Transform handler;
    public List<Hand> hands;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void OnDetachFromHand()
    {
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;

        handler.GetComponent<Rigidbody>().velocity = Vector3.zero;
        handler.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void OnHeldUpdate()
    {
        if(Vector3.Distance(transform.position, handler.transform.position) > 0.4f)
        {
            foreach (var hand in hands)
            {
                hand.DetachObject(gameObject);
            }
        }
    }


}
