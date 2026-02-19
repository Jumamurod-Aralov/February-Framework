using UnityEngine;
using UnityEngine.Playables;

public class IdleCinematicController : MonoBehaviour
{
    [Header("References")]
    public PlayableDirector cinematicTimeline;

    public GameObject starshipCamera;
    public GameObject interiorCamera;

    public GameObject starshipObject;
    public GameObject interiorObject;

    public GameObject cinematicCameraHolder; // parent of 5 cameras

    [Header("Idle Settings")]
    public float idleTime = 5f;

    private float timer;
    private bool cinematicActive = false;

    void Update()
    {
        bool inputDetected =
            Input.anyKey ||
            Mathf.Abs(Input.GetAxis("Mouse X")) > 0.01f ||
            Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.01f;

        if (inputDetected)
        {
            timer = 0f;

            if (cinematicActive)
                ReturnToGameplay();
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= idleTime && !cinematicActive)
                StartCinematic();
        }
    }

    void StartCinematic()
    {
        cinematicActive = true;

        starshipCamera.SetActive(false);
        cinematicCameraHolder.SetActive(true);

        starshipObject.SetActive(true);
        interiorObject.SetActive(false);

        cinematicTimeline.Play();
    }

    void ReturnToGameplay()
    {
        cinematicActive = false;

        cinematicTimeline.Stop();

        cinematicCameraHolder.SetActive(false);
        starshipCamera.SetActive(true);

        starshipObject.SetActive(true);
        interiorObject.SetActive(false);
    }
}
