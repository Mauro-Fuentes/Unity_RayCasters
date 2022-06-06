using UnityEngine;

public class LineCaster : MonoBehaviour
{
    public float distance;

    private RaycastHit hit;
    private bool somethingWasHit;

    public float maxtime = 2f;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        Gizmos.color = greenColor;
        Gizmos.DrawRay(from: transform.position, direction: transform.forward * distance);

        if (somethingWasHit)
        {
            CalculateTimeleftToHit();

            Gizmos.color = redColor;
            Gizmos.DrawSphere(hit.point, .3f);
        }

        CalculateTimeLeftToDistance();

        AddTime();
    }

    private void PerformCast()
    {
        somethingWasHit = Physics.Linecast
        (
            start: transform.position,
            end: transform.position + transform.forward * distance,
            hitInfo: out hit
        );
    }

    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxtime) timeLeft = 0f;
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
