using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCaster : MonoBehaviour
{
    public Transform centerOfSphere;
    public Transform point2;
    public float maxDistance = 5f;
    public float radius;

    private bool somethingWasHit;
    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public Mesh capsule1;

    private void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centerOfSphere.position, radius);
        Gizmos.DrawWireSphere(point2.position, radius);

        somethingWasHit = Physics.CapsuleCast
            (
                point1: centerOfSphere.position,
                point2: point2.position,
                radius: radius,
                direction: transform.forward,
                maxDistance: maxDistance
            );

        //if (somethingWasHit) Debug.Log("BOOM;");

        if (somethingWasHit)
        {
            Gizmos.color = redColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
            Gizmos.DrawWireMesh(capsule1, 0, transform.forward * maxDistance);
            Gizmos.DrawSphere(centerOfSphere.position, radius);
        }

        else
        {
            Gizmos.color = greenColor;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * (maxDistance + transform.lossyScale.z / 2));
        }
    }
}



/*

        MAIN 1

        public static bool CapsuleCast
        (
            Vector3 point1,
            Vector3 point2,
            float radius,
            Vector3 direction,
            [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance,
            [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask,
            [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction
        )
        {
            RaycastHit hitInfo;
            return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask)
        {
            return CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance)
        {
            return CapsuleCast(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
        {
            return CapsuleCast(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
        }



        MAIN 2

        public static bool CapsuleCast
        (
            Vector3 point1,
            Vector3 point2,
            float radius,
            Vector3 direction,
            out RaycastHit hitInfo,
            [UnityEngine.Internal.DefaultValue("Mathf.Infinity")] float maxDistance,
            [UnityEngine.Internal.DefaultValue("DefaultRaycastLayers")] int layerMask,
            [UnityEngine.Internal.DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction
        )
        {
            return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
        {
            return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
        {
            return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
        }

        [ExcludeFromDocs]
        public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo)
        {
            return CapsuleCast(point1, point2, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
        }

*/