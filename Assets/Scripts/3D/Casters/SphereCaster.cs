using System;
using UnityEngine;

public class SphereCaster : MonoBehaviour
{
    public float maxDistance = 5f;
    public float radius;

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
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, radius);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position + transform.forward * timeLeft, radius);
        }

        else
        {
            CalculateTimeLeftToDistance();

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position + transform.forward * timeLeft, radius);
        }

        AddTime();
    }

    private void PerformCast()
    {
        somethingWasHit = Physics.SphereCast
        (
            origin: transform.position,
            radius: radius,
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
