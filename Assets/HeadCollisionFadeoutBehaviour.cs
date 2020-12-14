using UnityEngine;
using Valve.VR;

public class HeadCollisionFadeoutBehaviour : MonoBehaviour
{
    public Animator fadeout;
    private Transform m_Head;
    private CharacterController m_Controller;

    private void Start()
    {
        m_Head = SteamVR_Render.Top().head;
        m_Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var basePos = new Vector3(m_Head.position.x, transform.position.y , m_Head.transform.position.z);
        Debug.DrawLine(basePos, basePos + (Vector3.up * m_Controller.height), Color.red);

        if(Physics.Raycast(basePos, Vector3.up, m_Controller.height + 0.06f, 1 << 10))
        {
            fadeout.SetBool("Head Collided", true);
        }
        else
        {
            fadeout.SetBool("Head Collided", false);
        }
    }
}