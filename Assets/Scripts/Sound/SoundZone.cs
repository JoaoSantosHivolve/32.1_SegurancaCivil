using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    public ZoneSpatial spatial;
    [Range(0.0f, 1.0f)]
    public float maxVolume;
    public List<AudioClip> sounds;

    [HideInInspector] public List<AudioSource> audioSources;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;

        if (sounds.Count == 0) return;

        foreach (var s in sounds)
        {
            if (s == null)
                continue;

            var audioPlayer = new GameObject();
            audioPlayer.transform.parent = transform;
            audioPlayer.transform.name = s.name;
            audioPlayer.AddComponent<AudioSource>();
            audioPlayer.GetComponent<AudioSource>().clip = s;
            audioPlayer.GetComponent<AudioSource>().volume = 0;
            audioPlayer.GetComponent<AudioSource>().spatialBlend = spatial == ZoneSpatial.Spatial2D ? 0 : 1;
            audioPlayer.GetComponent<AudioSource>().playOnAwake = false;
            audioPlayer.GetComponent<AudioSource>().loop = true;

            audioSources.Add(audioPlayer.GetComponent<AudioSource>());
        }
    }

    public void SetPlay(bool state)
    {
        if (sounds.Count == 0) return;

        foreach (var aS in audioSources)
        {
            if (state) aS.Play();
            else aS.Stop();
        }
    }

    public void UpdateVolume(float volume)
    {
        foreach (var aS in audioSources) aS.volume = volume * maxVolume;
    }
}
