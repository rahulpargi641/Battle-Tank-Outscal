using UnityEngine;

public class CameraView : MonoBehaviour
{
    public CameraController Controller { private get; set; }
    public  Camera Camera { get; private set; }

    private void Awake()
    {
        Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Controller.Move();
        Controller.Zoom();
    }
}
