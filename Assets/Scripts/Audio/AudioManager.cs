using UnityEngine;

/// <summary>
/// Central audio controller (music + SFX)
/// Safe to use even when no AudioClips are assigned
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private const string AUDIO_KEY = "AudioSettings";
    private AudioSettingsData settings;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
        ApplySettings();
    }

    public void Initialize()
    {
        Debug.Log("AudioManager initialized (no clips required)");
    }

    #region Music

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null || musicSource == null)
            return;

        if (musicSource.clip == clip && musicSource.isPlaying)
            return;

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
            musicSource.Stop();
    }

    #endregion

    #region SFX

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null)
            return;

        sfxSource.PlayOneShot(clip);
    }

    #endregion

    #region Volume & Mute

    public void SetMusicVolume(float value)
    {
        settings.musicVolume = Mathf.Clamp01(value);
        ApplySettings();
        SaveSettings();
    }

    public void SetSFXVolume(float value)
    {
        settings.sfxVolume = Mathf.Clamp01(value);
        ApplySettings();
        SaveSettings();
    }

    public void ToggleMute(bool mute)
    {
        settings.isMuted = mute;
        ApplySettings();
        SaveSettings();
    }

    #endregion

    #region Persistence

    private void SaveSettings()
    {
        string json = JsonUtility.ToJson(settings);
        PlayerPrefs.SetString(AUDIO_KEY, json);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(AUDIO_KEY))
        {
            settings = JsonUtility.FromJson<AudioSettingsData>(
                PlayerPrefs.GetString(AUDIO_KEY)
            );
        }
        else
        {
            settings = new AudioSettingsData();
        }
    }

    private void ApplySettings()
    {
        if (musicSource != null)
            musicSource.volume = settings.isMuted ? 0f : settings.musicVolume;

        if (sfxSource != null)
            sfxSource.volume = settings.isMuted ? 0f : settings.sfxVolume;
    }

    #endregion
}
