using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public float forwardSpeed = 2.0f; // Forward movement speed
    public float waveAmplitude = 1.0f; // Amplitude of the transverse wave
    public float waveFrequency = 1.0f; // Frequency of the transverse wave
    public float waveSpeed = 2.0f; // Speed of the transverse wave

    private float originalY;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        if (!GetComponent<InputMovement>().IsObserved())
        {
            MoveForward();
            ApplyTransverseWave();
        }
    }

    void MoveForward()
    {
        // Move the sphere forward along its local z-axis
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void ApplyTransverseWave()
{
    // Calculate transverse wave motion along the xz-plane
    float waveMotion = waveAmplitude * Mathf.Sin(Time.time * waveFrequency);

    // Calculate the target position with transverse wave motion
    Vector3 targetPosition = new Vector3(transform.position.x, originalY + waveMotion, transform.position.z);

    // Calculate the interpolation factor based on the smoothness you desire
    float smoothness = 0.5f; // Adjust this value to control smoothness
    float interpolation = Mathf.Lerp(transform.position.y, targetPosition.y, smoothness * Time.deltaTime);

    // Move the particles forward along their local z-axis with smooth transverse wave motion
    transform.position = new Vector3(transform.position.x, interpolation, transform.position.z);

    // Move the particles forward along their local z-axis with transverse wave motion
    float modifiedSpeed = waveSpeed * (1.0f + waveMotion);
    transform.Translate(Vector3.forward * modifiedSpeed * Time.deltaTime);
}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchTrigger"))
        {
            InputMovement inputMovement = GetComponent<InputMovement>();
            // Toggle isObserved boolean using the ToggleObserved method from InputMovement
            inputMovement.ToggleObserved();

            // Check if this is the first WaveGenerator object that hit the switch
            if (inputMovement.IsObserved())
            {
                // Get all WaveGenerator objects in the scene
                WaveGenerator[] waveGenerators = FindObjectsOfType<WaveGenerator>();

                // Ensure that at least one WaveGenerator is kept
                if (waveGenerators.Length > 1)
                {
                    // Randomly choose an index to keep
                    int indexToKeep = Random.Range(0, waveGenerators.Length);

                    // Iterate through the WaveGenerators and destroy all except the randomly chosen one
                    for (int i = 0; i < waveGenerators.Length; i++)
                    {
                        if (i != indexToKeep)
                        {
                            Destroy(waveGenerators[i].gameObject);
                        }
                    }
                }
            }
        }
        else if (other.CompareTag("Screen") || other.CompareTag("Wall"))
        {
            // Destroy the sphere immediately upon passing through the wall
            Destroy(gameObject);
        }
    }
}
