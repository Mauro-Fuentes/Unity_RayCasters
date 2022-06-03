using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public float maxDistance;
    private RaycastHit hit;
    private bool somethingWasHit;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {

        somethingWasHit = Physics.Raycast
            (
                origin: transform.position,
                direction: transform.forward,
                hitInfo: out hit,
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
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }


}
