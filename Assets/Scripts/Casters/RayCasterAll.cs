using UnityEditor;
using UnityEngine;

public class RayCasterAll : MonoBehaviour
{
    public float maxDistance;
    private RaycastHit hit;

    public RaycastHit[] hits;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        PerformCast();

        CalculateTimeLeftToDistance();

        Gizmos.color = greenColor;
        Gizmos.DrawRay(from: transform.position, direction: transform.forward * timeLeft);

        if (hits.Length > 0)
        {
            //CalculateTimeleftToHit();

            for (int i = 0; i < hits.Length; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(hits[i].point, 0.2f);

                Handles.Label(hits[i].point + transform.up * 1.5f, hits[i].transform.name.ToString());
            }
        }

        AddTime();
    }

    private void PerformCast()
    {
        hits = Physics.RaycastAll
        (
            origin: transform.position,
            direction: transform.forward,
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
