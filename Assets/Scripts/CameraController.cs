using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform target;
    
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    private void FocusOnTarget()
    {
        virtualCamera.Follow = target;
    }


}
