using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public Button PlayButton;
        
        public event Action OnPlayButtonClick;

        private void Awake()
        {
            PlayButton.onClick.AddListener(() => OnPlayButtonClick?.Invoke());
        }
    }
}