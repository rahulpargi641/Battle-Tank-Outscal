using System.Collections.Generic;
using UnityEngine;

public class CameraService : MonoSingletonGeneric<CameraService>
{
    [SerializeField] CameraView cameraView;

    public List<Transform> TargetTransforms = new List<Transform>();

    private CameraController cameraController;

    // Start is called before the first frame update
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
