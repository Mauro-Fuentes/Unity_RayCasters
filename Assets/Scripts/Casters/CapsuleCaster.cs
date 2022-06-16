using UnityEngine;

public class CapsuleCaster : MonoBehaviour
{
    public Transform sphere1;
    public Transform sphere2;
    public float maxDistance = 5f;
    public float radius;

    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    private RaycastHit hitinfo;

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

        if (somethingWasHit)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hitinfo.point, 0.2f);
        }


        CalculateTimeLeftToDistance();

        AddTime();
    }

    private void DrawWithSimple()
    {

        Gizmos.DrawWireSphere(sphere1.position + transform.forward * timeLeft, radius);
        Gizmos.DrawWireSphere(sphere2.position + transform.forward * timeLeft, radius);

        var a = new Vector3(radius*2, sphere2.position.y, radius*2 );
        var ar = Mathf.RoundToInt(sphere2.position.y);

        Gizmos.DrawWireCube(transform.position + transform.forward * timeLeft, a );
    }

    private void PerformCast()
    {
        somethingWasHit = Physics.CapsuleCast
        (
            point1: sphere1.position,
            point2: sphere2.position,
            radius: radius,
            direction: transform.forward,
            maxDistance: maxDistance,
            hitInfo: out hitinfo
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