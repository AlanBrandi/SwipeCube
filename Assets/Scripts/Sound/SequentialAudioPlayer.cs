using UnityEngine;

public class SequentialAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float delayBetweenClips = 1f;

    private AudioSource audioSource;
    private int currentClipIndex = 0;

    [SerializeField] private GameObject newDialogue;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlaySequentialAudioClips();
    }

    private void PlaySequentialAudioClips()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned.");
            return;
        }

        if (currentClipIndex >= audioClips.Length)
        {
           newDialogue.SetActive(true);
        }

        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();

        // Invoke next clip after current clip finishes playing
        float delay = audioSource.clip.length + delayBetweenClips;
        Invoke("PlaySequentialAudioClips", delay);

        currentClipIndex++;
    }
}
