using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float minDelay = 1f;
    public float maxDelay = 5f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayRandomAudioClip();
    }

    private void PlayRandomAudioClip()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned.");
            return;
        }

        // Generate random delay
        float delay = Random.Range(minDelay, maxDelay);
        Invoke("PlayRandomAudioClip", delay);

        // Play random audio clip
        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(randomClip);
    }
}
