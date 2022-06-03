using UnityEngine;

public class BoxChecker : MonoBehaviour
{
    public Vector3 q;
    public Mesh mesh;
    private bool somethingWasHit;
    public float maxDistance = 5f;

    public Color color1;
    public Color color2;

    private void OnDrawGizmos()
    {
        Quaternion rotation = Quaternion.Euler(q);

        somethingWasHit = Physics.CheckBox
            (
                center: transform.position + transform.forward * maxDistance,
                halfExtents: transform.lossyScale/2,
                orientation: rotation
            );

        if (somethingWasHit)
        {
            Gizmos.color = color2;
            Gizmos.DrawMesh(mesh, 0, transform.position + transform.forward * maxDistance, rotation);
        }

        else
        {
            Gizmos.color = color1;
            Gizmos.DrawMesh(mesh, 0, transform.position + transform.forward * maxDistance, rotation);
        }
    }
}
