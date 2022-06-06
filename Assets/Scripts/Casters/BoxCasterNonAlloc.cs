using UnityEngine;

[ExecuteInEditMode]
public class BoxCasterNonAlloc: MonoBehaviour
{
    public float maxDistance = 5f;

    public int numberOfHits;

    bool somethingWasHit;
    public bool debug;

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    //RaycastHit[] hits = new RaycastHit[5];
    RaycastHit[] hits;

    private float timeLeft;

    private void OnEnable()
    {
        hits = new RaycastHit[5];
    }

    private void OnDrawGizmos()
    {
        PerformCast();

        if (numberOfHits > 0)
        {
            CalculateTimeleftToHit();

            Gizmos.color = redColor;

            //Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.lossyScale);
            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);

            for (int index = 0; index < numberOfHits; index++)
            {
                Gizmos.color = Color.blue;

                if (debug)
                    Debug.Log(hits[index].transform.name);

                //Gizmos.DrawRay(from: hits[index].transform.position, direction: hits[index].normal);
            }
        }

        else
        {
            CalculateTimeLeftToDistance();
            Gizmos.color = greenColor;

            Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, transform.lossyScale);

            //Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }

        AddTime();
    }

    private void PerformCast()
    {
        numberOfHits = Physics.BoxCastNonAlloc
        (
            center: transform.position,
            halfExtents: transform.lossyScale / 2,
            direction: transform.forward,
            results: hits,
            orientation: transform.rotation,
            maxDistance: maxDistance
        );
    }

    private void CalculateTimeleftToHit()
    {
        if (timeLeft >= hits[0].distance) timeLeft = 0f;
    }

    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxDistance) timeLeft = 0f;
    }

    private void AddTime()
    {
        timeLeft += 0.1f;
    }


}
