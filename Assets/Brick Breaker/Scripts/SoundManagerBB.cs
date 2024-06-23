using UnityEngine;

public class SoundManagerBB : MonoBehaviour
{
    public static SoundManagerBB Instance;

    public AudioClip paddleHitClip;
    public AudioClip wallHitClip;
    public AudioClip gameOverClip;
    public AudioClip introClip;
    public AudioClip pointLoss;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Convenience methods for playing specific sounds
    public void PlayPaddleHitSound()
    {
        PlaySound(paddleHitClip);
    }

    public void PlayWallHitSound()
    {
        PlaySound(wallHitClip);
    }

    public void PlayGameOverSound()
    {
        PlaySound(gameOverClip);
    }

    public void PlayIntroSound()
    {
        PlaySound(introClip);
    }

    public void PlayPointLoss()
    {
        PlaySound(pointLoss);
    }
}
