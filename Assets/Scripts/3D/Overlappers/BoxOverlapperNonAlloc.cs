using UnityEngine;

public class BoxOverlapperNonAlloc : MonoBehaviour
{
    public float maxDistance = 5f;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Collider[] allColliders;

    private void OnDrawGizmos()
    {
        var asa = Physics.OverlapBoxNonAlloc
            (
                center: transform.position + transform.forward * maxDistance,
                halfExtents: transform.lossyScale / 2,
                results: allColliders
            );

        if (allColliders.Length > 0)
        {
            DrawLineForTarget(targetIsAquired: true);

            for (int index = 0; index < allColliders.Length; index++)
            {
                //if (activateDebug)
                //    Handles.Label(r.transform.position + transform.up * 1.2f, r.distance.ToString());

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
