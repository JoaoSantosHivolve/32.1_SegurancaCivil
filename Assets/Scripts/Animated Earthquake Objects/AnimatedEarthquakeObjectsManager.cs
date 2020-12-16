using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedEarthquakeObjectsManager : Singleton<AnimatedEarthquakeObjectsManager>
{
    [Range(0, 0.25f)] public float speedRange;
    [HideInInspector] public AnimationCurve behaviour;
    public List<AnimatedEarthquakeObject> objects;

    public void AddObject(AnimatedEarthquakeObject obj)
    {
        objects.Add(obj);
    }

    public IEnumerator EarthquakeEffect(float duration)
    {
        var time = 0.0f;

        foreach (var o in objects)
        {
            o.animator.SetBool("Earthquake", true);
        }

        while (time < duration)
        {
            var behaviourTime = time / duration;

            foreach (var o in objects)
            {
                o.animator.SetFloat("Speed", behaviour.Evaluate(behaviourTime) + Random.Range(-speedRange, speedRange));
            }

            time += Time.deltaTime;

            yield return null;
        }

        foreach (var o in objects)
        {
            o.animator.SetBool("Earthquake", false);
            o.animator.SetFloat("Speed", 1);
        }
    }
}