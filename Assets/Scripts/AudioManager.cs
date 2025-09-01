using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    public AudioClip background;
    
    public AudioClip beebuzz;


    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        sfxSource.PlayOneShot(beebuzz);
    }
    

    
}




