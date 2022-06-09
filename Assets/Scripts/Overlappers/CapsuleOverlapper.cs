using UnityEditor;
using UnityEngine;

public class CapsuleOverlapper : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius = 2f;
    public bool activateDebug;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Collider[] allColliders;

    private void OnDrawGizmos()
    {
        allColliders = Physics.OverlapCapsule
        (
            point0: transform.position,
            point1: transform.position + transform.up * 2,
            radius: radius
        );

        if (allColliders.Length > 0)
        {

            DrawSphere(targetIsAquired: true);

            for (int index = 0; index < allColliders.Length; index++)
            {
                if (activateDebug)
                    Handles.Label(allColliders[index].transform.position + transform.up * 2f, allColliders[index].name);

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: transform.position, direction: transform.forward);
            }
        }

        else
        {
            DrawSphere(targetIsAquired: false);
        }
    }

    private void DrawSphere(bool targetIsAquired)
    {
        if (targetIsAquired) Gizmos.color = redColor;
        else Gizmos.color = greenColor;

        Gizmos.DrawSphere(center: transform.position + transform.forward * maxDistance, radius);
    }

}
