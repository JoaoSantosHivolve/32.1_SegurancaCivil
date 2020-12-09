using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeManager : MonoBehaviour
{
    public float duration;

    public EarthquakeEffectBehaviour effectBehaviour;
    public float earthquakeIntensity;

    public CameraShakeEffect cameraEffect;
    public float cameraEffectIntensity;
    [Range(0.0f, 1.0f)] public float hapticMagnitude;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(effectBehaviour.EarthquakeEffect(duration, earthquakeIntensity));
            StartCoroutine(cameraEffect.EarthquakeEffect(duration, cameraEffectIntensity, hapticMagnitude));
        }
    }
}
