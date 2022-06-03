using UnityEngine;

public class Layers : MonoBehaviour
{
    public LayerMask layerMask;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Wall");
    }
}