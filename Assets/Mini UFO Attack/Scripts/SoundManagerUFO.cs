using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Class that manages the sounds for the game.
/// </summary>
public class SoundManagerUFO : MonoBehaviour
{
    // The audio source component
    public AudioSource audioSource;

    // The 5 sounds
    public AudioClip Joueur_tire;
    public AudioClip Joueur_hit;
    public AudioClip Tire_ennemi_2;
    public AudioClip Tire_ennemi_4;
    public AudioClip Son_laser;
    public AudioClip Explosion_1;
    public AudioClip Explosion_2;
    public AudioClip Explosion_3;
    public AudioClip Explosion_4;
    public AudioClip Explosion_5;
    public AudioClip MegaBomb;
    public AudioClip PowerUp;
    public AudioClip Music;
    public AudioClip GameOverMusic;

    public AudioClip Player_explosion;

    // The current sound
    private AudioClip currentSound;

    /// <summary>
    /// Initializes the audio source.
    /// </summary>
    void Start()
    {
        // Initialize the audio source
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a sound.
    /// </summary>
    /// <param name="soundIndex">The index of the sound to play.</param>
    public void PlaySound(int soundIndex)
    {
        // Get the corresponding sound clip
        switch (soundIndex)
        {
            case 1:
                currentSound = Joueur_tire;
                break;
            case 2:
                currentSound = Joueur_hit;
                break;
            case 3:
                currentSound = Tire_ennemi_2;
                break;
            case 4:
                currentSound = Tire_ennemi_4;
                break;
            case 5:
                currentSound = Son_laser;
                break;
            case 6:
                currentSound = Explosion_1;
                break;
            case 7:
                currentSound = Explosion_2;
                break;
            case 8:
                currentSound = Explosion_3;
                break;
            case 9:
                currentSound = Explosion_4;
                break;
            case 10:
                currentSound = Explosion_5;
                break;
            case 11:
                currentSound = Music;
                break;
            case 12:
                currentSound = MegaBomb;
                break;
            case 13:
                currentSound = PowerUp;
                break;
            case 14:
                currentSound = Player_explosion;
                break;
            case 15:
                currentSound = GameOverMusic;
                break;
            default:
                currentSound = null;
                break;
        }

        // Get the corresponding sound clip
        AudioClip soundClip = currentSound;

        // Play the sound using PlayOneShot
        audioSource.PlayOneShot(soundClip);
    }

    /// <summary>
    /// Stops all audio sources.
    /// </summary>
    public void StopAllAudioSources()
    {
        // Trouver tous les objets de jeu avec des composants AudioSource
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Parcourir chaque AudioSource et arrêter la musique
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }

        Debug.Log("All music stopped.");
    }
}
