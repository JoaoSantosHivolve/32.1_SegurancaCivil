using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class StepSoundBehaviour : MonoBehaviour
{
    private VRController m_Controller;
    private Transform m_CameraTransform;
    private AudioSource m_Source;

    private const float TimeBetweenStepsMin = 0.60f;
    private const float TimeBetweenStepsMax = 0.75f;

    private void Start()
    {
        m_Controller = transform.parent.GetComponent<VRController>();
        m_CameraTransform = SteamVR_Render.Top().head;
        m_Source = GetComponent<AudioSource>();

        StartCoroutine(StepSounds());
    }

    private IEnumerator StepSounds()
    {
        var time = 0.0f;
        var waitTime = GetNextWaitTime();

        while (true)
        {
            if (m_Controller.isWalking)
            {
                transform.localPosition = new Vector3(m_CameraTransform.localPosition.x, 0, m_CameraTransform.localPosition.z);

                time += Time.deltaTime;

                if(time > waitTime)
                {

                }
            }

            yield return null;
        }
    }

    private float GetNextWaitTime() => Random.Range(TimeBetweenStepsMin, TimeBetweenStepsMax);
}
