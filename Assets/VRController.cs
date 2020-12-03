using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{
    public float m_Gravity;
    public float m_Sensitivity;
    public float m_MaxSpeed;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;

    public CharacterController m_CharacterController;
    private Transform m_CameraRig;
    private Transform m_Head;

    private void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
    }

    private void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMovement();
    }

    private void HandleHead()
    {
        var oldPosition = m_CameraRig.position;
        var oldRotation = m_CameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }

    private void CalculateMovement()
    {
        var orientation = CalculateOrientation();
        var movement = Vector3.zero;

        if (m_MoveValue.axis.magnitude == 0)
            m_Speed = 0f;

        if (m_MovePress.state)
        {
            m_Speed += m_MoveValue.axis.magnitude * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);
        }

        movement += orientation * (m_Speed * Vector3.forward);
        movement.y -= m_Gravity * Time.deltaTime;

        m_CharacterController.Move(movement * Time.deltaTime);
    }
    private Quaternion CalculateOrientation()
    {
        var rotation = Mathf.Atan2(m_MoveValue.axis.x, m_MoveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        var orientationEuler = new Vector3(0, m_Head.eulerAngles.y + rotation , 0);
        return Quaternion.Euler(orientationEuler);
    }


    private void HandleHeight()
    {
        var headHeight = Mathf.Clamp(m_Head.localPosition.y, 0.5f, 2);
        m_CharacterController.height = headHeight;

        var newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2f;
        newCenter.y += m_CharacterController.skinWidth;
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        m_CharacterController.center = newCenter;
    }
}
