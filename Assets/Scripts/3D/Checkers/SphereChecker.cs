using UnityEditor;
using UnityEngine;

public class SphereChecker : MonoBehaviour
{
    public float radius;

    private bool somethingWasHit;
    public float maxDistance;

    private Color colorNoTarget = Color.green;
    private Color colorTargetAquired = Color.red;

    private void OnDrawGizmos()
    {
        PerfomCast();

        if (somethingWasHit)
        {
            Gizmos.color = colorTargetAquired;
            Gizmos.DrawSphere(transform.position + transform.forward * maxDistance, radius);
            Handles.Label(transform.position + transform.up * 1.5f, "YES");
        }

        else
        {
            Gizmos.color = colorNoTarget;
            Gizmos.DrawSphere(transform.position + transform.forward * maxDistance, radius);
            Handles.Label(transform.position + transform.up * 1.5f, "NO");
        }
    }

    private void PerfomCast()
    {
        somethingWasHit = Physics.CheckSphere
        (
            position: transform.position + transform.forward * maxDistance,
            radius: radius
        );
    }
}
