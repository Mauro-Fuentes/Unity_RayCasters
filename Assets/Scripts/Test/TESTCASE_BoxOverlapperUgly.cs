using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[ExecuteAlways]
public class TESTCASE_BoxOverlapperUgly : MonoBehaviour
{
    public int sizeOfArray;
    public float maxDistance;

    private void Update()
    {
        Profiler.BeginSample("TEST DOS");

        Collider[] allColliders = new Collider[sizeOfArray];

        allColliders = Physics.OverlapBox
        (
            center: transform.position + transform.forward * maxDistance,
            halfExtents: transform.lossyScale / 2
        );

        Profiler.EndSample();
    }

    private void OnDrawGizmos()
    {

    }
}
