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

    private RaycastHit hitinfo;

    public Mesh capsule1;

    private float timeLeft;

    private void OnDrawGizmos()
    {
        //Gizmos.color = greenColor;
        //Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));

        Gizmos.color = Color.cyan;

        //DrawWithSimple();

        var a = new Vector3(radius * 2, sphere2.position.y, radius * 2);
        var ar = Mathf.RoundToInt(sphere2.position.y);

        Gizmos.DrawWireMesh
        (
            mesh: capsule1,
            submeshIndex: 0,
            position: transform.position + transform.forward * maxDistance,
            rotation: transform.rotation,
            scale: a
         );

        PerformCast();

        if (hits.Length > 0)
        {
            //Debug.Log("Hit");

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hitinfo.point, 0.2f);

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

        //else
        //{
        //    Gizmos.color = greenColor;
        //    Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        //}

        CalculateTimeLeftToDistance();

        AddTime();
    }

    private void DrawWithSimple()
    {
        // Unity style draws two circles and completes with a box
        //Staticos
        //Gizmos.DrawWireSphere(sphere1.position, radius);
        //Gizmos.DrawWireSphere(sphere2.position, radius);

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
