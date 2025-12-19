using UnityEngine;
using PuzzleTemplate.Runtime;

namespace Client.Runtime.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Emitters")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Configuration")]
        [SerializeField] private AudioConfig config;

        private AudioSettingsData _settings;
        private IAudioPersistence _persistence;

        private void Awake()
        {
            // Default to PlayerPrefs, but could be injected otherwise
            _persistence = new AudioPersistence();
            LoadAndApply();
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null || musicSource.clip == clip) return;

            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip, float pitchRandomness = 0.1f)
        {
            if (clip == null) return;

            // Production Tip: Add slight pitch variation for better feel in puzzles
            sfxSource.pitch = 1f + Random.Range(-pitchRandomness, pitchRandomness);
            sfxSource.PlayOneShot(clip);
        }

        #region Volume Control

        public void SetMusicVolume(float volume)
        {
            _settings.musicVolume = Mathf.Clamp01(volume);
            UpdateVolumes();
        }

        public void SetSfxVolume(float volume)
        {
            _settings.sfxVolume = Mathf.Clamp01(volume);
            UpdateVolumes();
        }

        private void UpdateVolumes()
        {
            float muteMultiplier = _settings.isMuted ? 0 : 1;
            musicSource.volume = _settings.musicVolume * muteMultiplier;
            sfxSource.volume = _settings.sfxVolume * muteMultiplier;
            _persistence.Save(_settings);
        }

        private void LoadAndApply()
        {
            _settings = _persistence.Load();

            // Fallback to config if first time running
            if (_settings.musicVolume <= 0 && !_settings.isMuted)
            {
                _settings.musicVolume = config.defaultMusicVolume;
                _settings.sfxVolume = config.defaultSfxVolume;
            }

            UpdateVolumes();
        }

        #endregion
    }
}