using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioClip firstClip; // First audio clip
    public AudioClip secondClip; // Second audio clip
    public float secondClipVolume = 0.5f; // Volume for second clip

    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Play the first audio clip
        if (firstClip != null)
        {
            audioSource.clip = firstClip;
            audioSource.Play();

            // Start coroutine to play the second clip
            StartCoroutine(PlaySecondClipAfterFirst());
        }
        else
        {
            Debug.LogError("First audio clip is not assigned!");
        }
    }

    private IEnumerator PlaySecondClipAfterFirst()
    {
        // Wait for the first clip to finish
        yield return new WaitForSeconds(firstClip.length);

        // Play the second clip if assigned
        if (secondClip != null)
        {
            audioSource.clip = secondClip;
            audioSource.loop = true;
            audioSource.volume = secondClipVolume; // Set the second clip's volume
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Second audio clip is not assigned!");
        }
    }
}
