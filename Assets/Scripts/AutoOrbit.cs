using UnityEngine;
using Cinemachine;

public class AutoOrbit : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;
    public float orbitSpeed = 0.1f;

    void Update()
    {
        freeLookCam.m_XAxis.Value += orbitSpeed * Time.deltaTime;
    }
}