using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Glass,
    PC
}
public enum ObjectDamageType
{
    None,
    AddTexture,
    ChangeTexture
}

public class DamageableObjectsManager : Singleton<DamageableObjectsManager>
{
    public List<DamageableObject_Overtime> objects;

    [Header("Glass")]
    public List<Material> glassMats;
    public List<AudioClip> glassSounds;
    [Header("PC")]
    public List<Material> pcMats;
    public List<AudioClip> pcSounds;

    public void AddObject(DamageableObject_Overtime obj)
    {
        objects.Add(obj);
    }

    public AudioClip GetSound(ObjectType type)
    {
        switch (type)
        {
            case ObjectType.Glass:
                return glassSounds[Random.Range(0, glassSounds.Count - 1)];
            case ObjectType.PC:
                return pcSounds[Random.Range(0, pcSounds.Count - 1)];
            default:
                break;
        }

        return null;
    }
    public Material GetMaterial(ObjectType type)
    {
        switch (type)
        {
            case ObjectType.Glass:
                return glassMats[Random.Range(0, glassMats.Count - 1)];
            case ObjectType.PC:
                return pcMats[Random.Range(0, pcMats.Count - 1)];
            default:
                break;
        }

        return null;
    }

    public IEnumerator DamageObjects(float duration)
    {
        // Set objects damage time
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].timeToDamage = Random.Range(0, duration);
        }

        var time = 0.0f;

        while(time < duration)
        {
            foreach (var o in objects)
            {
                if(time > o.timeToDamage && !o.damaged)
                {
                    o.damaged = true;
                    o.DamageObject();
                }
            }

            time += Time.deltaTime;

            yield return null;
        }
    }
}
