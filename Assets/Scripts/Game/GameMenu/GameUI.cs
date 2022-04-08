using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameMenu
{
    public class GameUI : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public Button BackToMainMenu;

        public event Action OnBackToMainMenuClicked;
        public event Action<TextMeshProUGUI> UpdateScoreText;

        private void Start() => 
            BackToMainMenu.onClick.AddListener(BackToMainMenuClick);

        private void LateUpdate() => 
            UpdateScoreText?.Invoke(ScoreText);

        private void BackToMainMenuClick() => 
            OnBackToMainMenuClicked?.Invoke();
    }
}