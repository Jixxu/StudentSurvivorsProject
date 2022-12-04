using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    private Bloom bloom;
    private Vignette vignette;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out bloom);

    }

    public void BloomOnOff(bool value)
    {
        bloom.active = value;
    }
}
