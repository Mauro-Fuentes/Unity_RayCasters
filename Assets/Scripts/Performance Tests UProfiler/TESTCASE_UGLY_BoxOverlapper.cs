using UnityEngine;
using UnityEngine.Profiling;

[ExecuteAlways]
public class TESTCASE_UGLY_BoxOverlapper : MonoBehaviour
{
    public Vector3 cubeSize;

    public int sizeOfArray;
    public float maxDistance;

    public int collidersFound;

    private void Update()
    {
        Profiler.BeginSample("TEST THE UGLY");

        Collider[] allColliders = new Collider[sizeOfArray];

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
