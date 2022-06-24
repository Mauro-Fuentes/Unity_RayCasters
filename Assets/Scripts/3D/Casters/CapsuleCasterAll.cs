using UnityEngine;

public class CapsuleCasterAll : MonoBehaviour
{
    public Transform sphere1;
    public Transform sphere2;
    public float maxDistance = 5f;
    public float radius;

    public RaycastHit[] hits;

    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Mesh capsule1;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        var a = new Vector3(radius * 2, sphere2.position.y, radius * 2);
        var ar = Mathf.RoundToInt(sphere2.position.y);

        Gizmos.color = Color.green;
        Gizmos.DrawWireMesh
        (
            mesh: capsule1,
            submeshIndex: 0,
            position: transform.position + transform.forward * timeLeft,
            rotation: transform.rotation,
            scale: a
         );

        PerformCast();

        for (int i = 0; i < hits.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hits[i].point, 0.15f);
        }

        CalculateTimeLeftToDistance();

        AddTime();
    }

    private void DrawWithSimple()
    {
        //Movables
        Gizmos.DrawWireSphere(sphere1.position + transform.forward * timeLeft, radius);
        Gizmos.DrawWireSphere(sphere2.position + transform.forward * timeLeft, radius);

        var a = new Vector3(radius * 2, sphere2.position.y, radius * 2);
        var ar = Mathf.RoundToInt(sphere2.position.y);

        Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, a);
    }

    private void PerformCast()
    {
        hits = Physics.CapsuleCastAll
        (
            point1: sphere1.position,
            point2: sphere2.position,
            radius: radius,
            direction: transform.forward,
            maxDistance: maxDistance
        );
    }

    private void AddTime()
    {
        timeLeft += 0.05f;
    }

    private void CalculateTimeLeftToDistance()
    {
        if (timeLeft >= maxDistance) timeLeft = 0f;
    }
}
