using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private bool isObserved = false;

    public bool IsObserved()
    {
        return isObserved;
    }

    void Update()
    {
        if (isObserved)
        {
            MoveObserved();
        }
    }

    void MoveObserved()
    {
        Debug.Log("this is activated");
        // Move the sphere forward along the z-axis when observed
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void ToggleObserved()
    {
        isObserved = !isObserved;
    }
}
