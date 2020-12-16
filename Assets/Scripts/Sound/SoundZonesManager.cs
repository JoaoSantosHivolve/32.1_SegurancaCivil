using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneSpatial
{
    Spatial2D,
    Spatial3D
}

public class SoundZonesManager : MonoBehaviour
{
    [HideInInspector] public AnimationCurve behaviour;

    [Header("Set on Start")]
    public List<SoundZone> soundZones;


    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            soundZones.Add(transform.GetChild(i).GetComponent<SoundZone>());
    }

    public void SetPlay(bool state)
    {
        foreach (var sZ in soundZones)
            sZ.SetPlay(state);
    }

    public IEnumerator EarthquakeEffect(float duration)
    {
        var time = 0.0f;
        SetPlay(true);

        while (time < duration)
        {
            var behaviourTime = time / duration;

            UpdateVolume(behaviour.Evaluate(behaviourTime));

            time += Time.deltaTime;

            yield return null;
        }

        SetPlay(false);
    }

    public void UpdateVolume(float volume)
    {
        foreach (var sZ in soundZones)
            sZ.UpdateVolume(volume);
    }
}
