using Infrastructure.AssetProvider;
using UnityEngine;

namespace Services.SoundService
{
    public class SoundService : ISoundService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly AudioSource _audioSource;
        
        private AudioClip _mouseSound;

        public SoundService(IAssetProvider assetProvider, AudioSource audioSource)
        {
            _assetProvider = assetProvider;
            _audioSource = audioSource;
            _mouseSound = _assetProvider.MouseSound();
        }
        
        public void PlayMouseSound()
        {
            _audioSource.PlayOneShot(_mouseSound);
        }
    }
}