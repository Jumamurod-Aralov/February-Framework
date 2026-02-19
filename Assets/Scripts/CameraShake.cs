using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [Header("References")]
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineBasicMultiChannelPerlin noise;

    [Header("Shake Settings")]
    public float shakeDuration = 1f;
    public float amplitude = 0.3f;
    public float frequency = 2f;

    private float timer;

    void OnEnable()
    {
        if (noise == null)
        {
            Debug.LogWarning("Noise component not assigned!");
            return;
        }

        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        timer = shakeDuration;
    }

    void Update()
    {
        if (noise == null) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                noise.m_AmplitudeGain = 0f;
            }
        }
    }
}
