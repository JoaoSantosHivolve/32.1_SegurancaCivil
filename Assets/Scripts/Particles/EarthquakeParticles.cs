using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EarthquakeParticles : MonoBehaviour
{
    private ParticleSystem m_System;

    private void Start()
    {
        m_System = GetComponent<ParticleSystem>();
        m_System.playOnAwake = false; 

        EarthquakeParticlesManager.Instance.AddObject(m_System);
    }
}
