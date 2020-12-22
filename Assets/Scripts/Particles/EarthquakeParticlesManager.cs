using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeParticlesManager : Singleton<EarthquakeParticlesManager>
{
    public List<ParticleSystem> particles;

    public void AddObject(ParticleSystem obj)
    {
        particles.Add(obj);
    }

    public IEnumerator EarthquakeEffect(float duration)
    {
        var time = 0.0f;

        foreach (var p in particles)
        {
            p.Play();
        }

        while (time < duration)
        {
            //var behaviourTime = time / duration;

            time += Time.deltaTime;

            yield return null;
        }

        foreach (var p in particles)
        {
            p.Stop();
        }
    }
}
