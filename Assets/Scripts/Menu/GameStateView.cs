using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button restartButton;

        public event Action StartGamePressed;
        public event Action RestartButtonPressed;

        private void Start()
        {
            SetStartMenuActive(true);
            SetRestartButtonActive(false);
            startGameButton.onClick.AddListener(StartGameButtonPressed);
            restartButton.onClick.AddListener(RestartGameButtonPressed);
        }

        private void StartGameButtonPressed()
        {
            StartGamePressed?.Invoke();
        }

        private void RestartGameButtonPressed()
        {
            RestartButtonPressed?.Invoke();
        }

        public void SetStartMenuActive(bool active)
        {
            menuScreen.SetActive(active);
        }

        public void SetRestartButtonActive(bool active)
        {
            restartButton.gameObject.SetActive(active);
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(StartGameButtonPressed);
            restartButton.onClick.RemoveListener(RestartGameButtonPressed);
        }
    }
}