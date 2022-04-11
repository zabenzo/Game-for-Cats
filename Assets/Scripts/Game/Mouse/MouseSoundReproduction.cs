using System.Collections;
using Infrastructure.ServiceLocator;
using Services.SoundService;
using UnityEngine;

namespace Game.Mouse
{
    public class MouseSoundReproduction : MonoBehaviour
    {
        private ISoundService _soundService;
        private bool _isActive;
        private float _delay;

        public void Construct(float delay)
        {
            _delay = delay;
        }

        private void OnEnable()
        {
            _isActive = true;
        }

        private void Awake()
        {
            _soundService = ServiceLocator.Container.Single<ISoundService>();
        }

        private void Start()
        {
            StartCoroutine(MakeMouseSoundRoutine());
        }

        private void OnDisable()
        {
            _isActive = false;
        }

        private IEnumerator MakeMouseSoundRoutine()
        {
            while (_isActive)
            {
                yield return new WaitForSeconds(_delay);
                _soundService.PlayMouseSound();
            }
        }
    }
}