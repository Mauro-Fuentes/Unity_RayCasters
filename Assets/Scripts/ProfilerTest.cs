using UnityEngine;
using UnityEngine.Profiling;
using Unity.Profiling;
using Unity.Profiling.LowLevel.Unsafe;

public class ProfilerTest : MonoBehaviour
{
    public TMPro.TextMeshProUGUI myCanvas;
    public TMPro.TextMeshProUGUI myTest;

    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder gcMySample;
    ProfilerRecorder gcSample;  

    public static ProfilerMarker proMarkMySample = new ProfilerMarker("MySample");

    //CustomSampler mySampler;

    public float maxDistance = 5f;
    public RaycastHit[] hits;

    private void Update()
    {
        proMarkMySample.Begin();

        //Profiler.BeginSample("MyPieceOfCode");

        hits = Physics.BoxCastAll
        (
            center: transform.position,
            halfExtents: transform.lossyScale / 2,
            direction: transform.forward,
            orientation: transform.rotation,
            maxDistance: maxDistance
        );

        proMarkMySample.End();
        //Profiler.EndSample();

        var asd = gcMemoryRecorder.LastValue / (1024 * 1024);

        myCanvas.text = asd + " MB";

        myTest.text = gcMySample.LastValue.ToString();
    }

    private void OnEnable()
    {
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        gcMySample = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "MyPieceOfCode");
        gcSample = ProfilerRecorder.StartNew(proMarkMySample);
    }

    private void OnDisable()
    {
        gcMemoryRecorder.Dispose();
        gcSample.Dispose();
    }

    private void OnDrawGizmos()
    {
        ////mySampler.Begin();
        ////// do something that takes a lot of time
        
        ////mySampler.End();

        ////gcMemor = Profiler.BeginSample();

        //Profiler.BeginSample("MyPieceOfCode");

        ////RaycastHit[] hits;



        //Profiler.EndSample();

    }
}
