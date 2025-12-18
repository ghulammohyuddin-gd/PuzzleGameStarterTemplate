using UnityEngine;

namespace Client.Runtime.Audio
{
    [System.Serializable]
    public class AudioSettingsData
    {
        public float musicVolume = 1f;
        public float sfxVolume = 1f;
        public bool isMuted = false;
    }
}
