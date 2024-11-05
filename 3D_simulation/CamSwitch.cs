using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera thirdCamera;

    private int currentCameraIndex = 0;

    void Start()
    {
        // Ensure only the first camera is initially active
        SwitchCamera(currentCameraIndex);
    }

    void Update()
    {
        // Check for user input or any condition to switch between cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Increment the camera index and loop back to 0 if it exceeds the number of cameras
            currentCameraIndex = (currentCameraIndex + 1) % 3;

            // Switch to the new camera
            SwitchCamera(currentCameraIndex);
        }
    }

    void SwitchCamera(int cameraIndex)
    {
        // Disable all cameras
        firstCamera.enabled = false;
        secondCamera.enabled = false;
        thirdCamera.enabled = false;

        // Enable the selected camera
        switch (cameraIndex)
        {
            case 0:
                firstCamera.enabled = true;
                break;
            case 1:
                secondCamera.enabled = true;
                break;
            case 2:
                thirdCamera.enabled = true;
                break;
            // Add more cases if you have more cameras
        }
    }
}
