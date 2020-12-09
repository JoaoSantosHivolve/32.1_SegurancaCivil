using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RandomSpawnManager : MonoBehaviour
{
    public Player player;
    public List<Transform> spawnPositions;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.GetComponent<MeshRenderer>().enabled = false;
            spawnPositions.Add(child);
        }

        var rnd = Random.Range(0, spawnPositions.Count - 1);
        player.transform.position = spawnPositions[rnd].position;
    }

}
