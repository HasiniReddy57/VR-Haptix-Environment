using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    private Color originalColor;
    private Renderer cubeRenderer;
    private bool isBursting = false; 
    private AudioSource audioSource; 

    public AudioClip burstSound; 

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>();
        originalColor = cubeRenderer.material.color;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = burstSound;
        audioSource.playOnAwake = false; 
    }

    public void SetColor(Color color)
    {
        if (!isBursting) 
        {
            cubeRenderer.material.color = color;
            StartCoroutine(BurstAnimation()); 
        }
    }

    private IEnumerator BurstAnimation()
    {
        isBursting = true;

        // Animation duration and scaling factors
        float duration = 0.2f; // Total duration of the burst animation
        float maxScale = 1.0f; // More dramatic scaling
        Vector3 originalScale = transform.localScale;

        Debug.Log("Starting Burst Animation");

        // Scale up over time
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float scaleFactor = Mathf.Lerp(1.0f, maxScale, elapsedTime / duration);
            transform.localScale = originalScale * scaleFactor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Final burst effect
        transform.localScale = originalScale * maxScale * 1.2f;

        // Play sound
        if (audioSource && burstSound != null)
        {
            Debug.Log("Playing Burst Sound");
            audioSource.Play();
        }

        // Wait for sound to finish or a short delay
        float soundDuration = burstSound != null ? burstSound.length : 0.5f;
        yield return new WaitForSeconds(soundDuration);

        Debug.Log("Destroying Cube");
        Destroy(gameObject);
    }

    public void ResetColor()
    {
        if (!isBursting) 
        {
            cubeRenderer.material.color = originalColor;
        }
    }
}
