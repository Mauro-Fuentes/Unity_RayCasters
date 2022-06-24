using UnityEngine;
using UnityEditor;

public class SphereCasterAll : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius;
    public bool activateDebug;

    private RaycastHit[] hits;
    private bool somethingWasHit;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        if (hits.Length > 0)
        {
            CalculateTimeleftToHit();

            foreach (RaycastHit r in hits)
            {
                if (activateDebug)
                {
                    Handles.Label(r.transform.position + transform.up * 2f, r.transform.name.ToString());
                }

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: r.point , direction: r.normal);
            }

            Gizmos.color = redColor;
            Gizmos.DrawWireSphere(transform.position + transform.forward * timeLeft, radius);
        }

        else
        {
            CalculateTimeLeftToDistance();

            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance));

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position + transform.forward * timeLeft, radius);
        }

        AddTime();
    }

    private void PerformCast()
    {
        hits = Physics.SphereCastAll
        (
            origin: transform.position,
            radius: radius,
            direction: transform.forward,
            maxDistance: maxDistance
        );
    }

    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxDistance) timeLeft = 0f;
    }

    private void CalculateTimeleftToHit()
    {
        if (timeLeft >= hits[0].distance) timeLeft = 0f;
    }

    private void AddTime()
    {
        timeLeft += 0.1f;
    }
}
