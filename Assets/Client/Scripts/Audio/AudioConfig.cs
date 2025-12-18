using UnityEngine;

namespace Client.Runtime.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Template/Audio/Config")]
    public class AudioConfig : ScriptableObject
    {
        [Range(0, 1)] public float defaultMusicVolume = 0.8f;
        [Range(0, 1)] public float defaultSfxVolume = 1.0f;
    }
}