#pragma warning disable

using System;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Profiling;

[ExecuteAlways]
public class TESTCASE_BAD_BoxOverlapper : MonoBehaviour
{
    public Vector3 cubeSize;

    public int sizeOfArray;
    public float maxDistance;

    public int collidersFound;

    public Collider[] allColliders;

    private void OnEnable()
    {
        allColliders = new Collider[sizeOfArray];
    }

    private void Update()
    {
        Profiler.BeginSample("TEST THE BAD");

        allColliders = Physics.OverlapBox
        (
            center: transform.position + transform.forward * maxDistance,
            halfExtents: cubeSize / 2
        );

        Profiler.EndSample();

        collidersFound = allColliders.Length;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, cubeSize);
    }
}
