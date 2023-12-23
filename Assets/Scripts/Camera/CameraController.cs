using System;
using UnityEngine;

public class CameraController
{
    private readonly CameraModel model;
    private readonly CameraView view;

    public CameraController(CameraModel model, CameraView view)
    {
        this.model = model ?? throw new ArgumentNullException(nameof(model));
        this.view = view ?? throw new ArgumentNullException(nameof(view));

        this.view.Controller = this;
    }

    public void Move()
    {
        FindAveragePosition();
        SmoothDampPosition();
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = CalculateAveragePosition();
        model.DesiredPosition = new Vector3(averagePos.x, view.transform.position.y, averagePos.z);
    }

    private void SmoothDampPosition()
    {
        Vector3 tempMoveVelocity = model.MoveVelocity;
        view.transform.position = Vector3.SmoothDamp(view.transform.position, model.DesiredPosition, ref tempMoveVelocity, model.DampTime);
        model.MoveVelocity = tempMoveVelocity;
    }

    private Vector3 CalculateAveragePosition()
    {
        Vector3 averagePos = Vector3.zero;
        int nTargets = 0;

        foreach (var targetTransform in model.TargetTransforms)
        {
            if (targetTransform.gameObject.activeSelf)
            {
                averagePos += targetTransform.position;
                nTargets++;
            }
        }

        return nTargets > 0 ? averagePos / nTargets : Vector3.zero;
    }

    public void Zoom()
    {
        float requiredSize = FindRequiredSize();
        SmoothDampZoom(requiredSize);
    }

    private void SmoothDampZoom(float requiredSize)
    {
        float tempZoomSpeed = model.ZoomSpeed;
        view.Camera.orthographicSize = Mathf.SmoothDamp(view.Camera.orthographicSize, requiredSize, ref tempZoomSpeed, model.DampTime);
        model.ZoomSpeed = tempZoomSpeed;
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocaPos = view.transform.InverseTransformPoint(model.DesiredPosition);

        float size = 0f;

        foreach (var targetTransform in model.TargetTransforms)
        {
            if (targetTransform.gameObject.activeSelf)
            {
                Vector3 targetLocalPos = view.transform.InverseTransformPoint(targetTransform.position);
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocaPos;

                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / view.Camera.aspect);
            }
        }

        size += model.ScreenEdgeBuffer;
        size = Mathf.Max(size, model.MinSize);
        return size;
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();
        view.transform.position = model.DesiredPosition;
        view.Camera.orthographicSize = FindRequiredSize();
    }

    public void AddTarget(Transform transform)
    {
        if (!model.TargetTransforms.Contains(transform))
        {
            model.TargetTransforms.Add(transform);
            UpdateCameraTargets();
        }
    }

    public void RemoveTarget(Transform transform)
    {
        if (model.TargetTransforms.Contains(transform))
        {
            model.TargetTransforms.Remove(transform);
            UpdateCameraTargets();
        }
    }

    private void UpdateCameraTargets()
    {
        // Update view.TargetTransforms 
    }
}
