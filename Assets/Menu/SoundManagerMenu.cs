using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SelectGame;
    public AudioClip SpaceTheme;

    void Start()
    {
        // Initialize the audio source
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(SpaceTheme);
    }

    public void SelectGameSound()
    {
        audioSource.PlayOneShot(SelectGame);
    }

}
