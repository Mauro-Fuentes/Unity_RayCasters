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

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        if (somethingWasHit)
        {
            CalculateTimeleftToHit();

            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * timeLeft);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }

        else
        {
            CalculateTimeLeftToDistance();

            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * timeLeft);
        }

        AddTime();
    }

    private void PerformCast()
    {
        somethingWasHit = Physics.Raycast
        (
            origin: transform.position,
            direction: transform.forward,
            hitInfo: out hit,
            maxDistance: maxDistance
        );
    }


    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxDistance) timeLeft = 0f;
    }

    private void CalculateTimeleftToHit()
    {
        if (timeLeft >= hit.distance) timeLeft = 0f;
    }

    private void AddTime()
    {
        timeLeft += 0.1f;
    }

}
