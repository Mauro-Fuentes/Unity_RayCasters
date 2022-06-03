using UnityEngine;

public class LineCaster : MonoBehaviour
{
    private RaycastHit hit;
    private bool somethingWasHit;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        somethingWasHit = Physics.Linecast
            (
                start: transform.position,
                end: transform.forward,
                hitInfo: out hit
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
            Gizmos.DrawRay(from: transform.position, direction: transform.forward);
        }

    }
}
