using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(AudioSource))]
public class StepSoundBehaviour : MonoBehaviour
{
    private VRController m_Controller;
    private Transform m_CameraTransform;
    private AudioSource m_Source;
    private List<AudioClip> m_Sounds;

    private const float TimeBetweenSteps = 0.45f;
    private const float VolumeMax = 0.10f;
    private const float VolumeMin = 0.05f;

    private void Start()
    {
        m_Controller = transform.parent.GetComponent<VRController>();
        m_CameraTransform = SteamVR_Render.Top().head;
        m_Source = GetComponent<AudioSource>();

        m_Sounds = new List<AudioClip>();
        m_Sounds.Add(Resources.Load<AudioClip>("Sounds/Walking/Step01"));
        m_Sounds.Add(Resources.Load<AudioClip>("Sounds/Walking/Step02"));

        StartCoroutine(StepSounds());
    }

    private IEnumerator StepSounds()
    {
        var time = 0.0f;

        while (true)
        {
            if (m_Controller.isWalking)
            {
                transform.localPosition = new Vector3(m_CameraTransform.localPosition.x, 0, m_CameraTransform.localPosition.z);

                time += Time.deltaTime;

                if(time > TimeBetweenSteps)
                {
                    time = 0;

                    m_Source.clip = GetSound();
                    m_Source.volume = Random.Range(VolumeMin, VolumeMax);
                    m_Source.pitch = Random.Range(0.5f, 0.7f);
                    m_Source.Play();
                }
            }

            yield return null;
        }
    }

    private AudioClip GetSound() => m_Sounds[Random.Range(0, m_Sounds.Count - 1)];
}
