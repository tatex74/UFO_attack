using UnityEngine;

/// <summary>
/// SoundManagerBB is a singleton class that manages the sound effects for the Brick Breaker game.
/// </summary>
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

    /// <summary>
    /// Plays a sound clip.
    /// </summary>
    /// <param name="clip">The sound clip to play.</param>
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Plays the paddle hit sound clip.
    /// </summary>
    public void PlayPaddleHitSound()
    {
        PlaySound(paddleHitClip);
    }

    /// <summary>
    /// Plays the wall hit sound clip.
    /// </summary>
    public void PlayWallHitSound()
    {
        PlaySound(wallHitClip);
    }

    /// <summary>
    /// Plays the game over sound clip.
    /// </summary>
    public void PlayGameOverSound()
    {
        PlaySound(gameOverClip);
    }

    /// <summary>
    /// Plays the intro sound clip.
    /// </summary>
    public void PlayIntroSound()
    {
        PlaySound(introClip);
    }

    /// <summary>
    /// Plays the point loss sound clip.
    /// </summary>
    public void PlayPointLoss()
    {
        PlaySound(pointLoss);
    }
}
