using System.Collections.Generic;
using UnityEngine;

public class CameraService : MonoSingletonGeneric<CameraService>
{
    public List<Transform> TargetTransforms = new List<Transform>();

    [SerializeField] private CameraView cameraView;
    private CameraController cameraController;

    void Start()
    {
        CameraModel cameraModel = new CameraModel(TargetTransforms);
        cameraController = new CameraController(cameraModel, cameraView);
    }

    public void AddTarget(Transform targetTransform)
    {
        cameraController.AddTarget(targetTransform);
    }

    public void RemoveTarget(Transform targetTransform)
    {
        cameraController.RemoveTarget(targetTransform);
    }
}
