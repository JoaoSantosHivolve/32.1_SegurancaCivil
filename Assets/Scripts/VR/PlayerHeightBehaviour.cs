using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeightBehaviour : MonoBehaviour
{
    private CharacterController m_Collider;
    public Transform cameraPosition;

    public bool debugMode;
    public GameObject debugCollider;

    // Start is called before the first frame update
    void Awake()
    {
        m_Collider = GetComponent<CharacterController>();
        debugCollider.SetActive(debugMode);
    }

    // Update is called once per frame
    void Update()
    {
        m_Collider.height = cameraPosition.localPosition.y;
        m_Collider.center = new Vector3(cameraPosition.localPosition.x, m_Collider.height / 2f, cameraPosition.localPosition.z);

        if (debugMode)
        {
            var position = cameraPosition.localPosition;
            debugCollider.transform.localPosition = new Vector3(position.x, position.y / 2, position.z);
            var scale = debugCollider.transform.localScale;
            debugCollider.transform.localScale = new Vector3(scale.x, m_Collider.height / 2, scale.z);
        }
    }
}
