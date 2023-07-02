using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class MainGameCameraManager : SingletonMonoBehaviour<MainGameCameraManager>
{
    [SerializeField]
    private List<CinemachineVirtualCamera> cinemachineVirtualCameras
        = new List<CinemachineVirtualCamera>();

    private CinemachineVirtualCamera currentCinemachineVirtualCamera = null;

    private Transform cameraRoot = null;

    public override void Awake()
    {
        isSceneinSingleton = true;
        cameraRoot = this.gameObject.transform;
    }

    public void SetFollowCamera(Transform followTarget, int cameraIndex = 0)
    {
        currentCinemachineVirtualCamera = cinemachineVirtualCameras[cameraIndex];
        cinemachineVirtualCameras[cameraIndex].Follow = followTarget;
        cinemachineVirtualCameras[cameraIndex].LookAt = followTarget;
    }

    public void DetouchFollowCamera(int cameraIndex = 0)
    {
        cinemachineVirtualCameras[cameraIndex].Follow = null;
        cinemachineVirtualCameras[cameraIndex].LookAt = null;
    }

    public void RevertCameraPos()
    {
        currentCinemachineVirtualCamera.transform.localPosition = Vector3.zero;
        currentCinemachineVirtualCamera.transform.localEulerAngles = Vector3.zero;
    }

}
