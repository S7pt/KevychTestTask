using System;
using UnityEngine;
using Zenject;

namespace Score
{
    public class ScorePresenter : IInitializable, IDisposable
    {
        private ScoreModel model;
        private ScoreView view;

        public ScorePresenter(ScoreModel model, ScoreView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Initialize()
        {
            model.ScoreChanged += UpdateScore;
            UpdateScore(0);
        }

        public void Dispose()
        {
            model.ScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int score)
        {
            view.SetScore(score);
        }
    }
}