using UnityEngine;
using UnityEditor;

public class BoxCasterAllNonAlloc: MonoBehaviour
{
    public float maxDistance = 5f;

    public int maxReadHits;
    public int numberOfHits;

    bool somethingWasHit;
    public bool debug;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        RaycastHit[] hits = new RaycastHit[maxReadHits]; // remember that the creation of the array is at least [0] (not empty)

        numberOfHits = Physics.BoxCastNonAlloc
        (
            center: transform.position,
            halfExtents: transform.lossyScale / 2,
            direction: transform.forward,
            results: hits,
            orientation: transform.rotation,
            maxDistance: maxDistance
        );


        if (numberOfHits > 0)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.lossyScale);

            for (int index = 0; index < numberOfHits; index++)
            {
                Gizmos.color = Color.blue;

                if (debug)
                    Debug.Log(hits[index].transform.name);

                Gizmos.DrawRay(from: hits[index].transform.position, direction: hits[index].normal);
            }
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }
}
