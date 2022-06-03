using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius;

    private RaycastHit hit;
    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        somethingWasHit = Physics.SphereCast
            (
                origin: transform.position,
                radius: radius,
                direction: transform.forward,
                hitInfo: out hit,
                maxDistance: maxDistance 
            );

        if (somethingWasHit)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * hit.distance);
            Gizmos.DrawSphere(transform.position + transform.forward * hit.distance, radius);
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }
}
