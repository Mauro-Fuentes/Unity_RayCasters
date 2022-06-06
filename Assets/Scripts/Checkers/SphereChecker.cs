using UnityEngine;

public class SphereChecker : MonoBehaviour
{
    public float radius;

    private bool somethingWasHit;
    public float maxDistance;

    public Color color1;
    public Color color2;

    private void OnDrawGizmos()
    {
        somethingWasHit = Physics.CheckSphere
            (
                position: transform.position + transform.forward * maxDistance,
                radius: radius
            );

        if (somethingWasHit)
        {
            Gizmos.color = color2;
            Gizmos.DrawWireSphere(transform.position + transform.forward * maxDistance, radius);
        }

        else
        {
            Gizmos.color = color1;
            Gizmos.DrawWireSphere(transform.position + transform.forward * maxDistance, radius);
        }
    }
}
