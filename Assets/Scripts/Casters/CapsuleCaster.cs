using UnityEngine;

public class CapsuleCaster : MonoBehaviour
{
    public Transform centerOfSphere;
    public Transform point2;
    public float maxDistance = 5f;
    public float radius;

    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Mesh capsule1;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = greenColor;
        Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));

        Gizmos.color = Color.cyan;
        //Gizmos.DrawWireMesh
        //(
        //    mesh: capsule1,
        //    submeshIndex: -1,
        //    position: centerOfSphere.position,
        //    rotation: transform.rotation,
        //    scale: transform.lossyScale
        // );

        somethingWasHit = Physics.CapsuleCast
        (
            point1: centerOfSphere.position,
            point2: point2.position,
            radius: radius,
            direction: transform.forward,
            maxDistance: maxDistance
        );

        if (somethingWasHit)
        {
            //Debug.Log("Hit");

            //Gizmos.color = redColor;
            //Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
            //Gizmos.DrawWireMesh
            //(
            //    mesh: capsule1,
            //    submeshIndex: -1,
            //    position: transform.position + transform.forward * maxDistance,
            //    rotation: transform.rotation,
            //    scale: transform.lossyScale / 2
            // );
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }
}