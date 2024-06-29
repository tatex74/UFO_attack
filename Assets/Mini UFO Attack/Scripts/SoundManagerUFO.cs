using UnityEngine;
using UnityEngine.Audio;

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
    public AudioClip Music;

    // The current sound
    private AudioClip currentSound;

    void Start()
    {
        // Initialize the audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Play a sound
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
            default:
                currentSound = null;
                break;
        }

        // Get the corresponding sound clip
        AudioClip soundClip = currentSound;

        // Play the sound using PlayOneShot
        audioSource.PlayOneShot(soundClip);
    }
}