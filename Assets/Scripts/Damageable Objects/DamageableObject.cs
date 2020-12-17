using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DamageableObject : MonoBehaviour
{
    public bool damaged;
    public ObjectType type;
    public ObjectDamageType damageType;

    [Header("Renderers")]
    public List<MeshRenderer> renderersToChange;

    protected DamageableObjectsManager m_Manager;
    private AudioSource source;
    [HideInInspector] public Material[] defaultMats;

    protected void Start()
    {
        m_Manager = DamageableObjectsManager.Instance;

        source = GetComponent<AudioSource>();
        defaultMats = renderersToChange[0].materials;
    }

    public void DamageObject()
    {
        foreach (var r in renderersToChange)
        {
            switch (damageType)
            {
                case ObjectDamageType.None:
                    break;
                case ObjectDamageType.AddTexture:
                    r.materials = new Material[] { m_Manager.GetMaterial(type), r.material };
                    break;
                case ObjectDamageType.ChangeTexture:
                    r.materials = new Material[] { m_Manager.GetMaterial(type)};
                    break;
            }
        }

        source.clip = m_Manager.GetSound(type);
        source.spatialBlend = 1;
        source.Play();
    }
}
