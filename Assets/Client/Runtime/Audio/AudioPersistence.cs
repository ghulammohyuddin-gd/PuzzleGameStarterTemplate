using UnityEngine;

namespace Client.Runtime.Audio
{
    public interface IAudioPersistence
    {
        void Save(AudioSettingsData data);
        AudioSettingsData Load();
    }

    public class AudioPersistence : IAudioPersistence
    {
        private const string Key = "AudioSettings";
        public void Save(AudioSettingsData data) => PlayerPrefs.SetString(Key, JsonUtility.ToJson(data));
        public AudioSettingsData Load() => JsonUtility.FromJson<AudioSettingsData>(PlayerPrefs.GetString(Key, "{}"));
    }
}