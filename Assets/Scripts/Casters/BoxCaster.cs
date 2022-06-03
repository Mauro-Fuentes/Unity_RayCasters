using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    public float maxDistance = 5f;

    private RaycastHit hit;
    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        somethingWasHit = Physics.BoxCast
            (
                center: transform.position,
                halfExtents: transform.lossyScale / 2,
                direction: transform.forward,
                hitInfo: out hit,
                orientation: transform.rotation,
                maxDistance: maxDistance
            );

        if (somethingWasHit)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale); 
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z/2));
        }
    }
}
