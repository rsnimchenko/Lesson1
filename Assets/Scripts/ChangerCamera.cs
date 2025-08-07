using Cinemachine;
using UnityEngine;

public class ChangerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera[] _allCameras;

    void Start()
    {
        SwitchToCamera(_playerCamera);
    }

    public void SelectTargetCamera(Collider other)
    {
        CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
        SwitchToCamera(targetCamera);
    }
    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in _allCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}

