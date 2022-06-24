using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SphereOverlapperNonAlloc : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius = .5f;
    public bool activateDebug;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Collider[] allColliders;

    private void OnEnable()
    {
        allColliders = new Collider[5];
    }

    private void OnDrawGizmos()
    {
        int numberOfColliderEncounter = Physics.OverlapSphereNonAlloc
            (
                position: transform.position + transform.forward * maxDistance,
                radius: radius,
                results: allColliders
            );

        if (numberOfColliderEncounter > 0)
        {
            DrawSphere(targetIsAquired: true);

            for (int index = 0; index < allColliders.Length; index++)
            {
                if (activateDebug)
                    Handles.Label(allColliders[index].transform.position + transform.up * 2f, allColliders[index].transform.name.ToString());

                DrawSphere(targetIsAquired: true);
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

        Gizmos.DrawSphere(transform.position + transform.forward * maxDistance, radius);
    }
}
