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

    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = null;

    [SerializeField]
    private List<Cinemachine.NoiseSettings> noiseProfiles = new List<Cinemachine.NoiseSettings>();

    enum ResultCameraMode
    {
        Win = 1,
        Lose
    }

    enum NoiseSettings
    {
        Invalide = -1,
        Normal,
        Shake
    }

    private Transform cameraRoot = null;

    public override void Awake()
    {
        isSceneinSingleton = true;
        cameraRoot = this.gameObject.transform;
    }

    public void SetFollowCamera(Transform followTarget, int cameraIndex = 0)
    {
        currentCinemachineVirtualCamera = cinemachineVirtualCameras[cameraIndex];

        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCameras[cameraIndex]
            .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_NoiseProfile = noiseProfiles[(int)NoiseSettings.Normal];

        cinemachineVirtualCameras[cameraIndex].Follow = followTarget;
        cinemachineVirtualCameras[cameraIndex].LookAt = followTarget;
    }

    public void DetouchFollowCamera(int cameraIndex = 0)
    {
        cinemachineVirtualCameras[cameraIndex].Follow = null;
        cinemachineVirtualCameras[cameraIndex].LookAt = null;
        cinemachineBasicMultiChannelPerlin.m_NoiseProfile = noiseProfiles[(int)NoiseSettings.Normal];
    }

    public void RevertCameraPos()
    {
        currentCinemachineVirtualCamera.transform.localPosition = Vector3.zero;
        currentCinemachineVirtualCamera.transform.localEulerAngles = Vector3.zero;
    }

    public void CameraShake()
    {
        cinemachineBasicMultiChannelPerlin.m_NoiseProfile = noiseProfiles[(int)NoiseSettings.Shake];
    }

    public void WinCameraSetteing()
    {
        DetouchFollowCamera();
        cinemachineVirtualCameras[(int)ResultCameraMode.Win].Priority = 11;
    }

    public void LoseCameraSetteing()
    {
        DetouchFollowCamera();
        cinemachineVirtualCameras[(int)ResultCameraMode.Lose].Priority = 11;
    }

}
