using System.Collections;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private float targetHeight;        // Randomized height for the balloon's final position
    private float riseDuration;       // Duration for the rise, randomized between 3 and 5 seconds

    private Vector3 initialPosition;  // Fixed x and z coordinates with variable y

    void Start()
    {
        // Set the initial position with y = 0
        initialPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        transform.position = initialPosition;

        // Randomize the target height between 1.3f and 1.5f
        targetHeight = Random.Range(1.3f, 1.5f);

        // Randomize the rise duration between 3 and 5 seconds
        riseDuration = Random.Range(3f, 5f);

        // Start the rise to the target height
        StartCoroutine(RiseToTargetHeight());
    }

    IEnumerator RiseToTargetHeight()
    {
        float elapsedTime = 0f;

        while (elapsedTime < riseDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / riseDuration);
            float newY = Mathf.Lerp(initialPosition.y, targetHeight, t);
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
            yield return null;
        }

        // Ensure the final position is set precisely at the target height
        transform.position = new Vector3(initialPosition.x, targetHeight, initialPosition.z);
    }
}
