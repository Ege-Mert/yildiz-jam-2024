using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AntonBold : MonoBehaviour
{
    public int clickThreshold = 10; // Number of clicks required to play the video
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public GameObject videoPanel; // Reference to the panel containing the video
    public GameObject clickArea;

    private int clickCount = 0;

    void Start()
    {
        // Add a click listener to the clickArea GameObject
        clickArea.GetComponent<Button>().onClick.AddListener(IncrementClickCount);

        // Set up video player
        if (videoPlayer != null)
        {
            videoPlayer.skipOnDrop = false; // Ensure video starts over
        }
        else
        {
            Debug.LogError("VideoPlayer component is not assigned.");
        }
    }

    void IncrementClickCount()
    {
        clickCount++; // Increase the click count
        if (clickCount >= clickThreshold)
        {
            PlayVideo(); // Play the video if the threshold is reached
        }
    }

    void PlayVideo()
    {
        // Play the video
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            // Show video panel
            if (videoPanel != null)
            {
                videoPanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("VideoPlayer component is not assigned.");
        }
    }

    void OnDisable()
    {
        // Stop video playback and hide video panel when exiting the main menu
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            // Hide video panel
            if (videoPanel != null)
            {
                videoPanel.SetActive(false);
            }
        }
    }
}
