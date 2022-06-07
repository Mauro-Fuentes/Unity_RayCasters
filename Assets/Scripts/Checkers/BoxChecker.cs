using UnityEditor;
using UnityEngine;

public class BoxChecker : MonoBehaviour
{
    public Vector3 rotationOfBox;
    public Mesh mesh;
    private bool somethingWasHit;
    public float maxDistance = 5f;

    private Color colorNoTarget = Color.green;
    private Color colorTargetAquired = Color.red;

    private void OnDrawGizmos()
    {
        Quaternion rotation = Quaternion.Euler(rotationOfBox);

        PerformCast(rotation);

        if (somethingWasHit)
        {
            Gizmos.color = colorTargetAquired;
            Gizmos.DrawMesh(mesh, 0, transform.position + transform.forward * maxDistance, rotation);
            Handles.Label(transform.position + transform.up * 1.5f, "YES");
        }

        else
        {
            Gizmos.color = colorNoTarget;
            Gizmos.DrawMesh(mesh, 0, transform.position + transform.forward * maxDistance, rotation);
            Handles.Label(transform.position + transform.up * 1.5f, "NO");
        }
    }

    private void PerformCast(Quaternion rotation)
    {
        somethingWasHit = Physics.CheckBox
        (
            center: transform.position + transform.forward * maxDistance,
            halfExtents: transform.lossyScale / 2,
            orientation: rotation
        );
    }
}
