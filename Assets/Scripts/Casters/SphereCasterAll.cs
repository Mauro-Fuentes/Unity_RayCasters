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

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        hits = Physics.SphereCastAll
            (
                origin: transform.position,
                radius: radius,
                direction: transform.forward,
                maxDistance: maxDistance
            );

        if (hits.Length > 1) // remember that the creation of the array is at least [0] (not empty)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);

            foreach (RaycastHit r in hits)
            {
                if (activateDebug)
                    Handles.Label(r.transform.position + transform.up * 1.2f, r.distance.ToString());
                
                Gizmos.DrawSphere(transform.position + transform.forward * maxDistance, radius);
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: r.transform.position, direction: r.normal);
            }

        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance - radius));
        }
    }
}
