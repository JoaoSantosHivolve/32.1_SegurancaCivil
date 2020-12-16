using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedEarthquakeObject : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    private void Start()
    {
        AnimatedEarthquakeObjectsManager.Instance.AddObject(this);

        animator = GetComponent<Animator>();
    }
}