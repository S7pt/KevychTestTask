using Game;
using Score;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Menu
{
    public class GameStatePresenter : IInitializable, IDisposable
    {
        [Inject] GameInitializer gameInitializer;
        [Inject] ScoreModel scoreModel;
        private GameStateView view;
        private GameStateModel model;

        public GameStatePresenter(GameStateView view, GameStateModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Initialize()
        {
            view.StartGamePressed += OnStartGameButtonPressed;
            view.RestartButtonPressed += OnRestartGameButtonPressed;
            model.AllItemsCollected += OnAllItemsCollected;
        }

        private void OnStartGameButtonPressed()
        {
            gameInitializer.Initialize();
            model.StartTime = Time.time;
            view.SetStartMenuActive(false);
        }

        private void OnRestartGameButtonPressed()
        {
            SceneManager.LoadScene(0);
        }

        private void OnAllItemsCollected()
        {
            view.SetRestartButtonActive(true);
            Debug.Log($"Game ended in {Time.time - model.StartTime} seconds with the score of {scoreModel.Score} ");
        }

        public void Dispose()
        {
            view.StartGamePressed -= OnStartGameButtonPressed;
            view.RestartButtonPressed -= OnRestartGameButtonPressed;
        }
    }
}