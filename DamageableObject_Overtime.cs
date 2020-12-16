using System.Collections.Generic;
using UnityEngine;

public class DamageableObject_Overtime : DamageableObject
{
    private void Start()
    {
        base.Start();

        m_Manager = DamageableObjectsManager.Instance;
        m_Manager.AddObject(this);
    }

    public void DamageObject()
    {
        foreach (var r in renderersToChange)
        {
            r.materials = new Material[] { m_Manager.GetMaterial(type), r.material };
        }

        source.clip = m_Manager.GetSound(type);
        source.spatialBlend = 1;
        source.Play();
    }
}
