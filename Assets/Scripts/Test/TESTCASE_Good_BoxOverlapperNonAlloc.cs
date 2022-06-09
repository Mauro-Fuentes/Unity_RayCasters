#pragma warning disable

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;

[ExecuteAlways]
public class TESTCASE_Good_BoxOverlapperNonAlloc : MonoBehaviour
{
    public float maxDistance = 5f;
    private Vector3 centerOfCube;

    public Vector3 cubeSize = new Vector3(.3f, .3f, .3f);

    private Color greenColor = Color.green;
    private Color redColor = Color.red;

    public int sizeOfArray = 2;

    public Collider[] allColliders;

    private System.Diagnostics.Stopwatch stopWatch;

    private void Start() { }

    private void OnEnable()
    {
        allColliders = new Collider[sizeOfArray];
    }

    private void OnDisable()
    {

    }
     
    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        CalculateCenterOfCube();

        DrawCube(centerOfCube, Color.cyan);

        CreateStopWatch();

        stopWatch.Start();

        Profiler.BeginSample("TEST THE GOOD");

        int collidersFound = Cast();

        Profiler.EndSample();

        if (collidersFound > 0)
        {
            //DrawLineForTarget(targetIsAquired: true);

            for (int index = 0; index <= allColliders.Length; index++)
            {
                //Gizmos.DrawCube(transform.position + transform.forward * maxDistance, cubeSize / 2);

                //Gizmos.color = Color.blue;
                //Gizmos.DrawRay(from: transform.position, direction: transform.forward);
            }
        }

        else
        {
            Array.Clear(allColliders, 0, allColliders.Length);

            DrawLineForTarget(targetIsAquired: false);
        }

        stopWatch.Stop();

        DebugInfoTest();
    }

    private void CalculateCenterOfCube()
    {
        centerOfCube = transform.position + transform.forward * maxDistance;
    }

    private int Cast()
    {
        return Physics.OverlapBoxNonAlloc
        (
            center: centerOfCube,
            halfExtents: cubeSize / 2,
            results: allColliders
        );
    }

    private void CreateStopWatch()
    {
        stopWatch = new System.Diagnostics.Stopwatch();
    }

    private void DrawCube(Vector3 place, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube(place, cubeSize);
    }

    private void DrawLineForTarget(bool targetIsAquired)
    {
        if (targetIsAquired) Gizmos.color = redColor;
        else Gizmos.color = greenColor;

        Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
    }

    #region Debug

    private void DebugInfoTest()
    {
        TimeSpan ts = stopWatch.Elapsed;
        long ticksThisTime = stopWatch.ElapsedTicks;
        var b = ts.TotalMilliseconds;
        var c = TimeSpan.TicksPerMillisecond;
        var a = stopWatch.ElapsedTicks;

        long frequency = System.Diagnostics.Stopwatch.Frequency;
        long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;

        //UnityEngine.Debug.Log( nanosecPerTick + " nanoseconds per tick" );
        //UnityEngine.Debug.Log(nanosecPerTick * ticksThisTime + " is the amount of nanoseconds");
        //UnityEngine.Debug.Log(b + " milisecons");
        //UnityEngine.Debug.Log(a + " ticks");
    }

    private void WrapperDebug()
    {
        
        //var asdf = GC.GetTotalMemory(false);

        //UnityEngine.Debug.Log(asdf / 1024 / 1024 + " total memory");

        //UnityEngine.Debug.Log(sizeof(allColliders));
    }

    #endregion
}
