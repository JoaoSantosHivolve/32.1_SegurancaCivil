using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraShakeEffect : MonoBehaviour
{
    public IEnumerator EarthquakeEffect(float duration,float intensity, float hapticMagnitude)
    {
        var time = 0.0f;

        while (time < duration)
        {
            transform.localPosition = Random.insideUnitSphere * intensity;

            time += Time.deltaTime;

            HapticManager.Instance.VibrateController(SteamVR_Input_Sources.LeftHand, hapticMagnitude);
            HapticManager.Instance.VibrateController(SteamVR_Input_Sources.RightHand, hapticMagnitude);

            yield return null;
        }

        transform.localPosition = Vector3.zero;
    }
}
