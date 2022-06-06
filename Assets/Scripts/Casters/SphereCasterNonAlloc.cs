using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SphereCasterNonAlloc : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius;
    public bool activateDebug;

    private RaycastHit[] hits;
    private bool somethingWasHit;

    public int numberOfHits;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private float timeLeft;

    private void OnEnable()
    {
        hits = new RaycastHit[5];
    }

    private void OnDrawGizmos()
    {
        PerformCast();

        if (hits.Length > 0)
        {
            CalculateTimeleftToHit();

            for (int index = 0; index < numberOfHits; index++)
            {
                Gizmos.color = Color.blue;

                if (activateDebug)
                     Handles.Label(hits[index].transform.position + transform.up * 2f, hits[index].transform.name.ToString());
            }

            foreach (RaycastHit r in hits)
            {
                if (activateDebug)
                {
                    //Handles.Label(r.transform.position + transform.up * 2f, r.transform.name.ToString());
                }

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: r.point, direction: r.normal);
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
        numberOfHits = Physics.SphereCastNonAlloc
        (
            origin: transform.position,
            radius: radius,
            direction: transform.forward,
            maxDistance: maxDistance,
            results: hits
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
