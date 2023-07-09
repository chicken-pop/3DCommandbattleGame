using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRenderingManager : MonoBehaviour
{
    [SerializeField] private Material loseFullScreenMaterial;
    [SerializeField] private Material winFullScreenMaterial;

    [SerializeField]
    private FullScreenPassRendererFeature fullScreenPassRendererFeature;

    public FullScreenPassRendererFeature GetFullScreenPassRendererFeature
    {
        get { return fullScreenPassRendererFeature; }
    }

    private void Awake()
    {
        //Material
        fullScreenPassRendererFeature.passMaterial = null;
    }

    public void SetLoseScreenRenderer()
    {
        fullScreenPassRendererFeature.passMaterial = loseFullScreenMaterial;
    }

    public void SetWinScreennRenderer()
    {
        fullScreenPassRendererFeature.passMaterial = winFullScreenMaterial;
    }
}
