using UnityEngine;
using UnityEditor;

public class BoxCasterAll : MonoBehaviour
{
    public float maxDistance = 5f;
    public bool activateDebug;

    private RaycastHit[] hits;
    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        hits = Physics.BoxCastAll
            (
                center: transform.position,
                halfExtents: transform.lossyScale / 2,
                direction: transform.forward,
                orientation: transform.rotation,
                maxDistance: maxDistance
            );

        if(hits.Length > 1) // remember that the creation of the array is at least [0] (not empty)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.lossyScale);

            //Debug.Log(hits.Length - 1 + " object/s caught. ");

            foreach (RaycastHit r in hits)
            {
                if(activateDebug)
                Handles.Label(r.transform.position + transform.up * 1.2f, r.distance.ToString());

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: r.transform.position, direction: r.normal);
            }
            
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }
}
