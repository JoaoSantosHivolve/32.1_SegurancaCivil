using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeManager : MonoBehaviour
{
    public float duration;
    public float timeToHideAfterEarthQuake;
    public AnimationCurve earthquakeBehaviour;
    [Header("Get Ready Watch Components")]
    public float preparationTime;
    public ReadyUIController uiController;
    [Header("Camera Effect Components")]
    public CameraShakeEffect cameraEffect;
    public float cameraEffectIntensity;
    [Range(0.0f, 1.0f)] public float hapticMagnitude;
    [Header("Earth Quake Objects Components")]
    public float earthquakeIntensity;
    public EarthquakeEffectBehaviour effectBehaviour;
    [Header("Safe Zone Components")]
    public SafeZoneBehaviour safeZoneBehaviour;

    private void Awake()
    {
        uiController.UpdateBar(1f, (int)duration);
        StartCoroutine(PrepareExperience());

        effectBehaviour.behaviour = earthquakeBehaviour;
        cameraEffect.behaviour = earthquakeBehaviour;
    }

    public IEnumerator PrepareExperience()
    {
        var time = preparationTime;

        while (time >= 0)
        {
            var clockValue = time / preparationTime;
            uiController.UpdateBar(clockValue, (int)time);
            time -= Time.deltaTime;

            yield return null;
        }

        uiController.UpdateBar(0, 0);

        StartCoroutine(effectBehaviour.EarthquakeEffect(duration, earthquakeIntensity));
        StartCoroutine(cameraEffect.EarthquakeEffect(duration, cameraEffectIntensity, hapticMagnitude));
        StartCoroutine(CheckPlayerSurvival());
    }

    public IEnumerator CheckPlayerSurvival()
    {
        var time = 0.0f;

        while (time <= duration)
        {
            if(time > timeToHideAfterEarthQuake)
            {
                if(!safeZoneBehaviour.isSafe)
                {
                    Debug.Log("Lost");
                    yield break;
                }
            }

            time += Time.deltaTime;

            yield return null;
        }

        Debug.Log("Won");
    }
}
