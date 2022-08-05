//////////////////////////////////////////////////////////////////////////

class CapsuleCast
{
    // NO RETREVING HIT INFO

    public static bool CapsuleCast 
    (
        Vector3 point1,
        Vector3 point2,
        float radius,
        Vector3 direction,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        RaycastHit hitInfo;
        return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask)
    {
        return CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance)
    {
        return CapsuleCast(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    {
        return CapsuleCast(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETREVING HIT INFO

    public static bool CapsuleCast
    (
        Vector3 point1,
        Vector3 point2,
        float radius,
        Vector3 direction,
        out RaycastHit hitInfo,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
    {
        return CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo)
    {
        return CapsuleCast(point1, point2, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class CapsuleCastAll
{
    private static RaycastHit[] Query_CapsuleCastAll
    (
        PhysicsScene physicsScene,
        Vector3 p0,
        Vector3 p1,
        float radius,
        Vector3 direction,
        float maxDistance,
        int mask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return Query_CapsuleCastAll_Injected(ref physicsScene, ref p0, ref p1, radius, ref direction, maxDistance, mask, queryTriggerInteraction);
    }

    public static RaycastHit[] CapsuleCastAll
    (
        Vector3 point1,
        Vector3 point2, 
        float radius,
        Vector3 direction,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        float magnitude = direction.magnitude;
        if (magnitude > float.Epsilon)
        {
            Vector3 direction2 = direction / magnitude;
            return Query_CapsuleCastAll(defaultPhysicsScene, point1, point2, radius, direction2, maxDistance, layerMask, queryTriggerInteraction);
        }

        return new RaycastHit[0];
    }

    public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask)
    {
        return CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance)
    {
        return CapsuleCastAll(point1, point2, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction)
    {
        return CapsuleCastAll(point1, point2, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class CapsuleCastNonAlloc
{
    public static int CapsuleCastNonAlloc
    (
        Vector3 point1,
        Vector3 point2, 
        float radius, 
        Vector3 direction, 
        RaycastHit[] results, 
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.CapsuleCast(point1, point2, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
    {
        return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results, float maxDistance)
    {
        return CapsuleCastNonAlloc(point1, point2, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int CapsuleCastNonAlloc(Vector3 point1, Vector3 point2, float radius, Vector3 direction, RaycastHit[] results)
    {
        return CapsuleCastNonAlloc(point1, point2, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class SphereCast
{
    // NO RETREVING HIT INFO

    public static bool SphereCast
    (
        Ray ray,
        float radius,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        RaycastHit hitInfo;
        return SphereCast(ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool SphereCast(Ray ray, float radius, float maxDistance, int layerMask)
    {
        return SphereCast(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Ray ray, float radius, float maxDistance)
    {
        return SphereCast(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Ray ray, float radius)
    {
        return SphereCast(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETREIVING HIT INFO Ray

    public static bool SphereCast
    (
        Ray ray,
        float radius,
        out RaycastHit hitInfo,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return SphereCast(ray.origin, radius, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float maxDistance)
    {
        return SphereCast(ray, radius, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo)
    {
        return SphereCast(ray, radius, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    
    // RETREIVING HIT INFO Vector3

    public static bool SphereCast
    (
        Vector3 origin,
        float radius,
        Vector3 direction,
        out RaycastHit hitInfo,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
    {
        return SphereCast(origin, radius, direction, out hitInfo, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo)
    {
        return SphereCast(origin, radius, direction, out hitInfo, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class SphereCastAll
{
    public static RaycastHit[] SphereCastAll
    (
        Vector3 origin,
        float radius, 
        Vector3 direction,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        float magnitude = direction.magnitude;
        if (magnitude > float.Epsilon)
        {
            Vector3 direction2 = direction / magnitude;
            return Query_SphereCastAll(defaultPhysicsScene, origin, radius, direction2, maxDistance, layerMask, queryTriggerInteraction);
        }

        return new RaycastHit[0];
    }

    public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask)
    {
        return SphereCastAll(origin, radius, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance)
    {
        return SphereCastAll(origin, radius, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction)
    {
        return SphereCastAll(origin, radius, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    public static RaycastHit[] SphereCastAll
    (
        Ray ray,
        float radius,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return SphereCastAll(ray.origin, radius, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance, int layerMask)
    {
        return SphereCastAll(ray, radius, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] SphereCastAll(Ray ray, float radius, float maxDistance)
    {
        return SphereCastAll(ray, radius, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] SphereCastAll(Ray ray, float radius)
    {
        return SphereCastAll(ray, radius, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class SphereCastNonAlloc
{
    public static int SphereCastNonAlloc
    (
        Vector3 origin,
        float radius, 
        Vector3 direction, 
        RaycastHit[] results,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.SphereCast(origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
    {
        return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance)
    {
        return SphereCastNonAlloc(origin, radius, direction, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results)
    {
        return SphereCastNonAlloc(origin, radius, direction, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    public static int SphereCastNonAlloc
    (
        Ray ray,
        float radius,
        RaycastHit[] results,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return SphereCastNonAlloc(ray.origin, radius, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance, int layerMask)
    {
        return SphereCastNonAlloc(ray, radius, results, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results, float maxDistance)
    {
        return SphereCastNonAlloc(ray, radius, results, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int SphereCastNonAlloc(Ray ray, float radius, RaycastHit[] results)
    {
        return SphereCastNonAlloc(ray, radius, results, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class CheckBox
{
    private static bool CheckBox_Internal
        (
            PhysicsScene physicsScene, 
            Vector3 center, Vector3 halfExtents, 
            Quaternion orientation, int layermask, 
            QueryTriggerInteraction queryTriggerInteraction
        )
    {
        return CheckBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layermask, queryTriggerInteraction);
    }

    public static bool CheckBox
        (
            Vector3 center, 
            ector3 halfExtents, 
            Quaternion orientation,
            int layermask,
            QueryTriggerInteraction queryTriggerInteraction
        )
    {
        return CheckBox_Internal(defaultPhysicsScene, center, halfExtents, orientation, layermask, queryTriggerInteraction);
    }

    public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask)
    {
        return CheckBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
    {
        return CheckBox(center, halfExtents, orientation, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CheckBox(Vector3 center, Vector3 halfExtents)
    {
        return CheckBox(center, halfExtents, Quaternion.identity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class CheckSphere
{
    private static bool CheckSphere_Internal
    (
        PhysicsScene physicsScene, 
        Vector3 position, 
        float radius, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return CheckSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
    }

    public static bool CheckSphere
    (
        Vector3 position,
        float radius,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return CheckSphere_Internal(defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
    }

    public static bool CheckSphere(Vector3 position, float radius, int layerMask)
    {
        return CheckSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CheckSphere(Vector3 position, float radius)
    {
        return CheckSphere(position, radius, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class CheckCapsule
{
    private static bool CheckCapsule_Internal
    (
        PhysicsScene physicsScene,
        Vector3 start,
        Vector3 end,
        float radius,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return CheckCapsule_Internal_Injected(ref physicsScene, ref start, ref end, radius, layerMask, queryTriggerInteraction);
    }

    public static bool CheckCapsule
    (
        Vector3 start,
        Vector3 end,
        float radius,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return CheckCapsule_Internal(defaultPhysicsScene, start, end, radius, layerMask, queryTriggerInteraction);
    }
    public static bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask)
    {
        return CheckCapsule(start, end, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool CheckCapsule(Vector3 start, Vector3 end, float radius)
    {
        return CheckCapsule(start, end, radius, -5, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class BoxOverlap
{
    private static Collider[] OverlapBox_Internal
    (
        PhysicsScene physicsScene,
        Vector3 center, 
        Vector3 halfExtents, 
        Quaternion orientation, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapBox_Internal_Injected(ref physicsScene, ref center, ref halfExtents, ref orientation, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapBox
    (
        Vector3 center, Vector3 halfExtents, 
        Quaternion orientation, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapBox_Internal(defaultPhysicsScene, center, halfExtents, orientation, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask)
    {
        return OverlapBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation)
    {
        return OverlapBox(center, halfExtents, orientation, -1, QueryTriggerInteraction.UseGlobal);
    }
    public static Collider[] OverlapBox(Vector3 center, Vector3 halfExtents)
    {
        return OverlapBox(center, halfExtents, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    public static int OverlapBoxNonAlloc
    (
        Vector3 center,
        Vector3 halfExtents,
        Collider[] results,
        Quaternion orientation,
        int mask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.OverlapBox(center, halfExtents, results, orientation, mask, queryTriggerInteraction);
    }

    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int mask)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, orientation, mask, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, orientation, -1, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
    }

}

class BoxOverlapNonAlloc
{
    public static int OverlapBoxNonAlloc
    (
        Vector3 center,
        Vector3 halfExtents, Collider[] results, 
        Quaternion orientation, 
        int mask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.OverlapBox(center, halfExtents, results, orientation, mask, queryTriggerInteraction);
    }

    [ExcludeFromDocs]
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int mask)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, orientation, mask, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, orientation, -1, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapBoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results)
    {
        return OverlapBoxNonAlloc(center, halfExtents, results, Quaternion.identity, -1, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class SphereOverlap
{
    private static Collider[] OverlapSphere_Internal
    (
        PhysicsScene physicsScene,
        Vector3 position, 
        float radius, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapSphere_Internal_Injected(ref physicsScene, ref position, radius, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapSphere
    (
        Vector3 position,
        float radius, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapSphere_Internal(defaultPhysicsScene, position, radius, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask)
    {
        return OverlapSphere(position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static Collider[] OverlapSphere(Vector3 position, float radius)
    {
        return OverlapSphere(position, radius, -1, QueryTriggerInteraction.UseGlobal);
    }

}

class SphereOverlapNonAlloc
{
    public static int OverlapSphereNonAlloc
    (
        Vector3 position, 
        float radius, 
        Collider[] results, 
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.OverlapSphere(position, radius, results, layerMask, queryTriggerInteraction);
    }

    public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask)
    {
        return OverlapSphereNonAlloc(position, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results)
    {
        return OverlapSphereNonAlloc(position, radius, results, -1, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class CapsuleOverlap
{
    private static Collider[] OverlapCapsule_Internal
    (
        PhysicsScene physicsScene,
        Vector3 point0,
        Vector3 point1,
        float radius,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapCapsule_Internal_Injected(ref physicsScene, ref point0, ref point1, radius, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapCapsule
    (
        Vector3 point0,
        Vector3 point1,
        float radius,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return OverlapCapsule_Internal(defaultPhysicsScene, point0, point1, radius, layerMask, queryTriggerInteraction);
    }

    public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask)
    {
        return OverlapCapsule(point0, point1, radius, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static Collider[] OverlapCapsule(Vector3 point0, Vector3 point1, float radius)
    {
        return OverlapCapsule(point0, point1, radius, -1, QueryTriggerInteraction.UseGlobal);
    }

}

class CapsuleOverlapNonAlloc
{
    public static int OverlapCapsuleNonAlloc
    (
        Vector3 point0,
        Vector3 point1, 
        float radius, 
        Collider[] results,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.OverlapCapsule(point0, point1, radius, results, layerMask, queryTriggerInteraction);
    }

    public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask)
    {
        return OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results)
    {
        return OverlapCapsuleNonAlloc(point0, point1, radius, results, -1, QueryTriggerInteraction.UseGlobal);
    }

}

//////////////////////////////////////////////////////////////////////////

class BoxCast
{
    // NO RETREVING HIT INFO

    public static bool BoxCast
    (
        Vector3 center,
        Vector3 halfExtents,
        Vector3 direction,
        Quaternion orientation,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        RaycastHit hitInfo;
        return defaultPhysicsScene.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask)
    {
        return BoxCast(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance)
    {
        return BoxCast(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation)
    {
        return BoxCast(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction)
    {
        return BoxCast(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETREVING HIT INFO
    public static bool BoxCast
    (
        Vector3 center,
        Vector3 halfExtents,
        Vector3 direction, 
        out RaycastHit hitInfo,
        Quaternion orientation,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask)
    {
        return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance)
    {
        return BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation)
    {
        return BoxCast(center, halfExtents, direction, out hitInfo, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo)
    {
        return BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class BoxCastAll
{
    private static RaycastHit[] Internal_BoxCastAll
    (
        PhysicsScene physicsScene,
        Vector3 center,
        Vector3 halfExtents,
        Vector3 direction, 
        Quaternion orientation, 
        float maxDistance, 
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return Internal_BoxCastAll_Injected(ref physicsScene, ref center, ref halfExtents, ref direction, ref orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static RaycastHit[] BoxCastAll
    (
        Vector3 center,
        Vector3 halfExtents,
        Vector3 direction,
        Quaternion orientation,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        float magnitude = direction.magnitude;
        if (magnitude > float.Epsilon)
        {
            Vector3 direction2 = direction / magnitude;
            return Internal_BoxCastAll(defaultPhysicsScene, center, halfExtents, direction2, orientation, maxDistance, layerMask, queryTriggerInteraction);
        }

        return new RaycastHit[0];
    }

    public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask)
    {
        return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance)
    {
        return BoxCastAll(center, halfExtents, direction, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation)
    {
        return BoxCastAll(center, halfExtents, direction, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] BoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 direction)
    {
        return BoxCastAll(center, halfExtents, direction, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
}

class BoxCastAllNonAlloc
{
    public static int BoxCastNonAlloc
    (
        Vector3 center,
        Vector3 halfExtents,
        Vector3 direction,
        RaycastHit[] results,
        Quaternion orientation,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.BoxCast(center, halfExtents, direction, results, orientation, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results)
    {
        return BoxCastNonAlloc(center, halfExtents, direction, results, Quaternion.identity, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation)
    {
        return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance)
    {
        return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static int BoxCastNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 direction, RaycastHit[] results, Quaternion orientation, float maxDistance, int layerMask)
    {
        return BoxCastNonAlloc(center, halfExtents, direction, results, orientation, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }



}

//////////////////////////////////////////////////////////////////////////

class RayCast
{
    // NO RETRIEVING HIT INFO

    public static bool Raycast
    (
        Vector3 origin,
        Vector3 direction,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
    {
        return defaultPhysicsScene.Raycast(origin, direction, maxDistance, layerMask);
    }
    public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(origin, direction, maxDistance);
    }
    public static bool Raycast(Vector3 origin, Vector3 direction)
    {
        return defaultPhysicsScene.Raycast(origin, direction);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // NO RETRIEVING HIT INFO RAY

    public static bool Raycast
    (
        Ray ray,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool Raycast(Ray ray, float maxDistance, int layerMask)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance, layerMask);
    }
    public static bool Raycast(Ray ray, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, maxDistance);
    }
    public static bool Raycast(Ray ray)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETRIEVING HIT INFO 

    public static bool Raycast
    (
        Vector3 origin,
        Vector3 direction,
        out RaycastHit hitInfo,
        float maxDistance,
        int layerMask, 
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance, layerMask);
    }
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(origin, direction, out hitInfo, maxDistance);
    }
    public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo)
    {
        return defaultPhysicsScene.Raycast(origin, direction, out hitInfo);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETRIEVING HIT INFO RAY

    public static bool Raycast
    (
        Ray ray,
        out RaycastHit hitInfo,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
    {
        return Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance);
    }
    public static bool Raycast(Ray ray, out RaycastHit hitInfo)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, out hitInfo);
    }

}

class RaycastAll
{
    private static RaycastHit[] Internal_RaycastAll
    (
        PhysicsScene physicsScene,
        Ray ray,
        float maxDistance,
        int mask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return Internal_RaycastAll_Injected(ref physicsScene, ref ray, maxDistance, mask, queryTriggerInteraction);
    }

    public static RaycastHit[] RaycastAll
    (
        Vector3 origin,
        Vector3 direction,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        float magnitude = direction.magnitude;
        if (magnitude > float.Epsilon)
        {
            Vector3 direction2 = direction / magnitude;
            return Internal_RaycastAll(ray: new Ray(origin, direction2), physicsScene: defaultPhysicsScene, maxDistance: maxDistance, mask: layerMask, queryTriggerInteraction: queryTriggerInteraction);
        }

        return new RaycastHit[0];
    }

    public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
    {
        return RaycastAll(origin, direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance)
    {
        return RaycastAll(origin, direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction)
    {
        return RaycastAll(origin, direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

    public static RaycastHit[] RaycastAll
    (
        Ray ray,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask)
    {
        return RaycastAll(ray.origin, ray.direction, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] RaycastAll(Ray ray, float maxDistance)
    {
        return RaycastAll(ray.origin, ray.direction, maxDistance, -5, QueryTriggerInteraction.UseGlobal);
    }
    public static RaycastHit[] RaycastAll(Ray ray)
    {
        return RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, -5, QueryTriggerInteraction.UseGlobal);
    }

}

class RayCastNonAlloc
{
    public static int RaycastNonAlloc
    (
        Ray ray,
        RaycastHit[] results,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, int layerMask)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance, layerMask);
    }
    public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results, maxDistance);
    }
    public static int RaycastNonAlloc(Ray ray, RaycastHit[] results)
    {
        return defaultPhysicsScene.Raycast(ray.origin, ray.direction, results);
    }

    public static int RaycastNonAlloc
    (
        Vector3 origin,
        Vector3 direction,
        RaycastHit[] results,
        float maxDistance,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask, queryTriggerInteraction);
    }

    public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
    {
        return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance, layerMask);
    }
    public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance)
    {
        return defaultPhysicsScene.Raycast(origin, direction, results, maxDistance);
    }
    public static int RaycastNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results)
    {
        return defaultPhysicsScene.Raycast(origin, direction, results);
    }

}

class LineCast
{
    // NO RETRIEVING HIT INFO

    public static bool Linecast
    (
        Vector3 start,
        Vector3 end,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        Vector3 direction = end - start;
        return defaultPhysicsScene.Raycast(start, direction, direction.magnitude, layerMask, queryTriggerInteraction);
    }

    public static bool Linecast(Vector3 start, Vector3 end, int layerMask)
    {
        return Linecast(start, end, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool Linecast(Vector3 start, Vector3 end)
    {
        return Linecast(start, end, -5, QueryTriggerInteraction.UseGlobal);
    }

    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    // RETRIEVING HIT INFO

    public static bool Linecast
    (
        Vector3 start,
        Vector3 end, 
        out RaycastHit hitInfo,
        int layerMask,
        QueryTriggerInteraction queryTriggerInteraction
    )
    {
        Vector3 direction = end - start;
        return defaultPhysicsScene.Raycast(start, direction, out hitInfo, direction.magnitude, layerMask, queryTriggerInteraction);
    }

    public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask)
    {
        return Linecast(start, end, out hitInfo, layerMask, QueryTriggerInteraction.UseGlobal);
    }
    public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo)
    {
        return Linecast(start, end, out hitInfo, -5, QueryTriggerInteraction.UseGlobal);
    }
    ghjghjgh
}

//////////////////////////////////////////////////////////////////////////
