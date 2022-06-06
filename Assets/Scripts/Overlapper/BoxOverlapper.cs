using UnityEngine;

public class BoxOverlapper : MonoBehaviour
{
    public float maxDistance = 5f;

    public Color colorForNoTarget;
    public Color colorForTargetAquired;

    public Collider[] allColliders;

    private void OnDrawGizmos()
    {
        allColliders = Physics.OverlapBox
            (
                center: transform.position + transform.forward * maxDistance,
                halfExtents: transform.lossyScale / 2
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
        if (targetIsAquired) Gizmos.color = colorForTargetAquired;
        else Gizmos.color = colorForNoTarget;

        Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
    }
}
