using UnityEngine;
using Valve.VR;

public class HeadCollisionFadeoutBehaviour : MonoBehaviour
{
    private Transform m_Head;

    private const float MaxDistanceFromRaycastPoint = 0.12f;
    public bool isColliding;
    public float collidingHeight;
    private float m_FadeValue;

    private void Start()
    {
        m_Head = SteamVR_Render.Top().head;
        SteamVR_Fade.Start(Color.clear, 0);
    }

    private void Update()
    {
        var basePos = new Vector3(m_Head.position.x, transform.position.y , m_Head.transform.position.z);
        //Debug.DrawLine(basePos, basePos + (Vector3.up * (m_Head.transform.position.y - transform.position.y + MaxDistanceFromRaycastPoint)), Color.red);

        var height = m_Head.transform.position.y - transform.position.y;
        var fadeValue = 0.0f;

        if (Physics.Raycast(basePos, Vector3.up,out var hit, height + MaxDistanceFromRaycastPoint, 1 << 10))
        {
            var topPoint = m_Head.transform.position.y + MaxDistanceFromRaycastPoint;
            var bottomPoint = hit.point.y;
            fadeValue = Mathf.Clamp((topPoint - bottomPoint) / ((bottomPoint + MaxDistanceFromRaycastPoint) - bottomPoint), 0.0f ,1.0f);

            collidingHeight = bottomPoint - basePos.y;
            isColliding = true;
        }
        else
        {
            fadeValue = 0;
            isColliding = false;
        }

        m_FadeValue = Mathf.Lerp(m_FadeValue, fadeValue, 6f * Time.deltaTime);
        SteamVR_Fade.View(new Color(0, 0, 0,m_FadeValue), 0f);
    }
}