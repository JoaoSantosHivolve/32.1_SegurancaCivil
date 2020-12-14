using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class EarthquakeEffectBehaviour : MonoBehaviour
{
    public Hand.AttachmentFlags flags;
    [HideInInspector] public int objectsPerFrame;

    private int m_Index;
    public int Index
    {
        get => m_Index;
        set
        {
            if (value >= m_Objects.Length) m_Index = 0;
            else if (value <= 0) m_Index = 0;
            else m_Index = value;
        }
    }
    [SerializeField] private Rigidbody[] m_Objects;
    [HideInInspector] public AnimationCurve behaviour;

    private void Start()
    {
        m_Objects = transform.GetComponentsInChildren<Rigidbody>();

        foreach (var item in m_Objects)
        {
            if (item.gameObject.GetComponent<Interactable>() == null) 
                item.gameObject.AddComponent<Interactable>();
            item.gameObject.GetComponent<Interactable>().hideHandOnAttach = false;
            item.gameObject.GetComponent<Interactable>().highlightOnHover = false;

            if (item.gameObject.GetComponent<Throwable>() == null) 
                item.gameObject.AddComponent<Throwable>();
            item.gameObject.GetComponent<Throwable>().restoreOriginalParent = true;
            item.gameObject.GetComponent<Throwable>().attachmentFlags = flags;
        }

        objectsPerFrame = (m_Objects.Length < 5 ? 1 : m_Objects.Length / 5);
    }

    public IEnumerator EarthquakeEffect(float duration, float intensity)
    {
        var time = 0.0f;

        while (time < duration)
        {
            var behaviourTime = time / duration;
            var beheviourIntensity = intensity * behaviour.Evaluate(behaviourTime);

            for (int i = 0; i < objectsPerFrame; i++)
            {
                m_Objects[Index].AddForce(Random.insideUnitSphere * beheviourIntensity);
                m_Objects[Index].AddTorque(Random.insideUnitSphere * beheviourIntensity);

                Index++;
            }

            time += Time.deltaTime;

            yield return null;
        }
    }
}
