using UnityEngine;

public class ScreenController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Particle"))
        {
            // Capture the position of the particle on the screen
            Debug.Log("Particle hit screen at position: " + other.transform.position);
        }
    }
}
