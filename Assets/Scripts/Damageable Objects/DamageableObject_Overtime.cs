using UnityEngine;

public class DamageableObject_Overtime : DamageableObject
{
    [Header("Overtime Properties")]
    public float timeToDamage;

    protected override void Start()
    {
        base.Start();

        m_Manager.AddObject(this);
    }
}
