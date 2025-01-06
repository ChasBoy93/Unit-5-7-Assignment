using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class AudioManager : MonoBehaviour
{
    //Audio Mixer
    public static AudioManager instance;
    public AudioSource soundFXObject;
    public AudioSource soundMusicObject;
    public AudioMixer audioMixer;

    //Sliders
    public Slider musicSlider;
    public Slider soundFXSlider;
    public Slider masterSlider;
    public Toggle muteToggle;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {
        //Get saved Music volume
        float music = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume(music);


        //Get saved SoundFX volume
        float soundFX = PlayerPrefs.GetFloat("SoundFXVolume");
        SetSoundFXVolume(soundFX);


        //Get saved Master volume
        float master = PlayerPrefs.GetFloat("MasterVolume");
        SetMasterVolume(master);



    }

    public void PlaySoundMusicClip(int clipNumber)
    {
        soundMusicObject.Play();
    }

    public void StopSoundMusicClip()
    {
        soundMusicObject.Stop();
    }

    //Play SFX
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign the audioClip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //Play sound
        audioSource.Play();

        //Get Length of sound FX clip
        float clipLength = audioSource.clip.length;

        //Destroy the clip after it has been played
        Destroy(audioSource.gameObject, clipLength);

    }

    public void SetMasterVolume(float level)
    {
        //Update Audio Mixer
        audioMixer.SetFloat("masterVolume", Mathf.Log10 (level) * 20);

        //Update PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", level);

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        //Save
        PlayerPrefs.Save();
    }

    public void SetSoundFXVolume(float level)
    {
        //Update Audio Mixer
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20);

        //Update PlayerPrefs
        PlayerPrefs.SetFloat("SoundFXVolume", level);

        soundFXSlider.value = PlayerPrefs.GetFloat("SoundFXVolume");

        //Save
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float level)
    {
        //Update Audio Mixer
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);

        //Update PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", level);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        //Save
        PlayerPrefs.Save();
    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            musicSlider.value = 0f;
            muteToggle.isOn = true;

            PlayerPrefs.SetFloat("MusicMute", muteToggle.isOn ? 1 : 0);

            float music = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume(music);

            PlayerPrefs.Save();

        }
        else
        {
            musicSlider.value = 1f;
            muteToggle.isOn= false;


            PlayerPrefs.SetInt("MusicMute", muteToggle.isOn ? 1 : 0);
            float music = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume(music);

            PlayerPrefs.Save();

        }
    }
}
