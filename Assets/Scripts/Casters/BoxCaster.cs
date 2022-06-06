using UnityEngine;

public class BoxCaster : MonoBehaviour
{
    public float maxDistance = 5f;

    private RaycastHit hit;
    private bool somethingWasHit;

    private Color colorNoTarget = Color.green;
    private Color colorTargetAquired = Color.red;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        if (somethingWasHit)
        {
            CalculateTimeleftToHit();

            Gizmos.color = colorTargetAquired;
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);

            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);
        }

        else
        {
            CalculateTimeLeftToDistance();

            Gizmos.color = colorNoTarget;
            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);
        }

        AddTime();
    }

    private void PerformCast()
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
