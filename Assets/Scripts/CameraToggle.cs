using UnityEngine;
using Cinemachine;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cockpitCam;      // Priority 20
    [SerializeField] private CinemachineVirtualCamera _thirdPersonCam;  // Priority 10

    [SerializeField] private GameObject _spaceshipExterior;             // Starsparrow
    [SerializeField] private GameObject _cockpitInterior;               // CockpitHeli

    private bool isCockpitActive = false;

    void Start()
    {
        // Start with 3rd person
        SetThirdPerson();
    }

    void Update()
    {
        // Toggle on C key
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isCockpitActive)
                SetThirdPerson();
            else
                SetCockpit();
        }
    }

    void SetCockpit()
    {
        _cockpitCam.Priority = 20;
        _thirdPersonCam.Priority = 10;

        _spaceshipExterior.SetActive(false);
        _cockpitInterior.SetActive(true);

        isCockpitActive = true;
    }

    void SetThirdPerson()
    {
        _cockpitCam.Priority = 10;
        _thirdPersonCam.Priority = 20;

        _spaceshipExterior.SetActive(true);
        _cockpitInterior.SetActive(false);

        isCockpitActive = false;
    }
}
