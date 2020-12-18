using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DamageableObject_OnHit: DamageableObject
{
    [Header("On Hit Properties")]
    private const float MaxBreakingSound = 0.4f;
    private const float HitFloorThreshold = 0.05f;
    private float m_LastVelocity;

    private Rigidbody m_Rigidbody;

    protected override void Start()
    {
        base.Start();

        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_LastVelocity > HitFloorThreshold && m_Rigidbody.velocity.y <= HitFloorThreshold)
        {
            Debug.Log("Object hit");

            Source.volume = Mathf.Clamp(m_LastVelocity, HitFloorThreshold, 4) * MaxBreakingSound;
            DamageObject();
        }

        m_LastVelocity = m_Rigidbody.velocity.y;
    }
}
