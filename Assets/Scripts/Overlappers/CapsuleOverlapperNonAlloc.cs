using UnityEngine;

public class CapsuleOverlapperNonAlloc : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Collider[] allColliders;

    private void OnDrawGizmos()
    {
        var asa = Physics.OverlapCapsuleNonAlloc
        (
            point0: transform.position,
            point1: transform.position + transform.up *2,
            radius: radius,
            results: allColliders
        );

        if (allColliders.Length > 0)
        {
            DrawLineForTarget(targetIsAquired: true);

            for (int index = 0; index < allColliders.Length; index++)
            {
                Gizmos.DrawCube(transform.position + transform.forward * maxDistance, transform.lossyScale);

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: transform.position, direction: transform.forward);
            }
        }

        else
        {
            DrawLineForTarget(targetIsAquired: false);
        }
    }

    private void DrawLineForTarget(bool targetIsAquired)
    {
        if (targetIsAquired) Gizmos.color = redColor;
        else Gizmos.color = greenColor;

        Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
    }
}
