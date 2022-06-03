using System.Collections;
using System.Collections.Generic;
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
        Gizmos.DrawSphere(centerOfSphere.position, radius);

        somethingWasHit = Physics.CapsuleCast
            (
                point1: centerOfSphere.position,
                point2: point2.position,
                radius: radius,
                direction: transform.right,
                maxDistance: maxDistance
            );

        if (somethingWasHit) Debug.Log("BOOM;");

        //if (somethingWasHit)
        //{
        //    Gizmos.color = redColor;
        //    Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
        //    //Gizmos.DrawWireMesh(capsule1, 0, transform.forward * maxDistance);
        //    Gizmos.DrawSphere(centerOfSphere.localPosition, radius);
        //}

        //else
        //{
        //    Gizmos.color = greenColor;
        //    Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        //}
    }
}
