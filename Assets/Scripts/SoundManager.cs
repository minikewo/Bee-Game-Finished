using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{ 
    [SerializeField] Slider sfxSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = sfxSlider.value;
        Save();
    }

    private void Load()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", sfxSlider.value);
    }
    
}
