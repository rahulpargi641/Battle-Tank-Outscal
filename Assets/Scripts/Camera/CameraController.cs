using UnityEngine;

public class CameraController
{
    private CameraModel model;
    private CameraView view;

    public CameraController(CameraModel model, CameraView view)
    {
        this.model = model;
        this.view = view;

        this.view.Controller = this;

        //model.TargetTransforms = view.TargetTransforms;
    }

    public void Move()
    {
         FindAveragePosition();

        //view.transform.position = Vector3.SmoothDamp(view.transform.position, model.m_DesiredPosition, ref model.m_MoveVelocity, model.m_DampTime);
        Vector3 tempMoveVelocity = model.MoveVelocity;
        view.transform.position = Vector3.SmoothDamp(view.transform.position, model.DesiredPosition, ref tempMoveVelocity, model.DampTime);
        model.MoveVelocity = tempMoveVelocity;
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int nTargets = 0;
        
        for(int i = 0; i < model.TargetTransforms.Count; i++)
        {
            if (! model.TargetTransforms[i].gameObject.activeSelf)
                continue;

            averagePos += model.TargetTransforms[i].position;
            nTargets++;
        }

        if (nTargets > 0)
            averagePos /= nTargets;
        averagePos.y = view.transform.position.y; // Update this

        model.DesiredPosition = averagePos;
    }

    public void Zoom()
    {
        float requiredSize = FindRequiredSize();
        float tempZoomSpeed = model.ZoomSpeed;

        view.Camera.orthographicSize = Mathf.SmoothDamp(view.Camera.orthographicSize, requiredSize, ref tempZoomSpeed, model.DampTime);
        model.ZoomSpeed = tempZoomSpeed;
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocaPos = view.transform.InverseTransformPoint(model.DesiredPosition);

        float size = 0f;

        for (int i = 0; i < model.TargetTransforms.Count; i++)
        {
            if (! model.TargetTransforms[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = view.transform.InverseTransformPoint(model.TargetTransforms[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocaPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / view.Camera.aspect);
        }

        size += model.ScreenEdgeBuffer;
        size = Mathf.Max(size, model.MinSize); // to make sure we're not too zoomed in
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
        if(! model.TargetTransforms.Contains(transform))
        {
            model.TargetTransforms.Add(transform);
            //Debug.Log("Target transform added name" + transform.gameObject.name);
            UpdateCameraTargets();
        }
    }
    public void RemoveTarget(Transform transform)
    {
        if (model.TargetTransforms.Contains(transform))
        {
            model.TargetTransforms.Remove(transform);
            //Debug.Log("Target transform removed name: " + transform.gameObject.name);
            UpdateCameraTargets();
        }
    }

    private void UpdateCameraTargets()
    {
      // view.TargetTransforms = model.TargetTransforms;
    }
}
