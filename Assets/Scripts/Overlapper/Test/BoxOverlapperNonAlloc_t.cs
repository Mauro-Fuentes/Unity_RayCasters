#pragma warning disable

using System;
using System.Diagnostics;
using UnityEngine;

[ExecuteAlways]
public class BoxOverlapperNonAlloc_t : MonoBehaviour
{
    public float maxDistance = 5f;

    public Color colorForNoTarget;
    public Color colorForTargetAquired;

    public Collider[] allColliders;

    private void Start()
    {
        allColliders = new Collider[3];
    }

    private void OnDrawGizmos()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        //var asdf = GC.GetTotalMemory(false);

        //UnityEngine.Debug.Log(asdf / 1024 / 1024 + " total memory");

        var asa = Physics.OverlapBoxNonAlloc
            (
                center: transform.position + transform.forward * maxDistance,
                halfExtents: transform.lossyScale / 2,
                results: allColliders
            );

        if (asa > 0)
        {
            DrawLineForTarget(targetIsAquired: true);

            for (int index = 0; index <= allColliders.Length; index++)
            {
                //if (activateDebug)
                //    Handles.Label(r.transform.position + transform.up * 1.2f, r.distance.ToString());

                Gizmos.DrawCube(transform.position + transform.forward * maxDistance, transform.lossyScale);

                Gizmos.color = Color.blue;
                Gizmos.DrawRay(from: transform.position, direction: transform.forward);
            }
        }

        else
        {
            DrawLineForTarget(targetIsAquired: false);
        }

        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        long ticksThisTime = stopWatch.ElapsedTicks;
        var b = ts.TotalMilliseconds;
        var c = TimeSpan.TicksPerMillisecond;
        var a = stopWatch.ElapsedTicks;

        long frequency = Stopwatch.Frequency;
        long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
        //UnityEngine.Debug.Log( nanosecPerTick + " nanoseconds per tick" );
        //UnityEngine.Debug.Log(nanosecPerTick * ticksThisTime + " is the amount of nanoseconds");
        //UnityEngine.Debug.Log(b + " milisecons");
        //UnityEngine.Debug.Log(a + " ticks");
    }

    private void DrawLineForTarget(bool targetIsAquired)
    {
        if (targetIsAquired) Gizmos.color = colorForTargetAquired;
        else Gizmos.color = colorForNoTarget;

        Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
    }
}
