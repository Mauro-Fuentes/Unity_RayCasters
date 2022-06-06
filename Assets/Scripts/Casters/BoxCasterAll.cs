using UnityEngine;
using UnityEditor;

public class BoxCasterAll : MonoBehaviour
{
    public float maxDistance = 5f;
    
    public bool activateDebug;

    public RaycastHit[] hits;

    private Color colorNoTarget = Color.green;
    private Color colorTargetAquired = Color.red;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        if (hits.Length > 0)
        {
            Bounds b = new Bounds(hits[0].transform.position, hits[0].transform.localScale);

            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);

            Gizmos.color = colorTargetAquired;
            Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.lossyScale);

            foreach (RaycastHit r in hits)
            {
                if (activateDebug)
                {
                    Handles.color = colorTargetAquired;
                    Handles.Label(r.point + transform.up * 1.5f, r.transform.name.ToString());
                }

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: r.transform.position, direction: r.normal);

                b.Encapsulate(r.transform.position);
            }

            Handles.DrawWireCube(b.center, b.size);
        }

        else
        {
            Gizmos.color = colorNoTarget;
            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);
        }

        CalculateTimeLeftToDistance();

        AddTime();
    }

    private void PerformCast()
    {
        hits = Physics.BoxCastAll
        (
            center: transform.position,
            halfExtents: transform.lossyScale / 2,
            direction: transform.forward,
            orientation: transform.rotation,
            maxDistance: maxDistance
        );
    }

    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxDistance) timeLeft = 0f;
    }

    private void AddTime()
    {
        timeLeft += 0.1f;
    }
}
