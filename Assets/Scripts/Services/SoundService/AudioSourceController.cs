using UnityEngine;

namespace Services.SoundService
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : MonoBehaviour
    {
        public AudioSource AudioSource;

        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();

            DontDestroyOnLoad(this);
        }
    }
}