using System.Collections.Generic;
using UnityEngine;

public class CameraModel
{
    public float DampTime { get; private set; }
    public float ScreenEdgeBuffer { get; private set; }
    public float MinSize { get; private set; } // min. size for zooming in, we don't want camera to really zoomed in 
    public List<Transform> TargetTransforms = new List<Transform>();
    public float ZoomSpeed;
    public Vector3 MoveVelocity;
    public Vector3 DesiredPosition; // position camera is trying to reach 

    public CameraModel(List<Transform> targetTransforms)
    {
        TargetTransforms = targetTransforms;
        DampTime = 0.4f; // 0.2f
        ScreenEdgeBuffer = 4f;
        MinSize = 7f;
    }
}
