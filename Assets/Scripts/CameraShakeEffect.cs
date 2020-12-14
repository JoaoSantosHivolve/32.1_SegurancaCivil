using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraShakeEffect : MonoBehaviour
{
    [HideInInspector] public AnimationCurve behaviour;

    public IEnumerator EarthquakeEffect(float duration,float intensity, float hapticMagnitude)
    {
        var time = 0.0f;

        while (time < duration)
        {
            var behaviourTime = time / duration;
            var beheviourIntensity = intensity * behaviour.Evaluate(behaviourTime);
            var newHapticMagnitude = hapticMagnitude * behaviour.Evaluate(behaviourTime);

            // ----- Camera Shake
            transform.localPosition = Random.insideUnitSphere * beheviourIntensity;

            // ----- Controller Vibration
            HapticManager.Instance.VibrateController(SteamVR_Input_Sources.LeftHand, newHapticMagnitude);
            HapticManager.Instance.VibrateController(SteamVR_Input_Sources.RightHand, newHapticMagnitude);
            
            time += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = Vector3.zero;
    }
}
