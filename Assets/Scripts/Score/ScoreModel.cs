using System;

namespace Score
{
    public class ScoreModel
    {
        private int score;

        public int Score { get => score; private set => score = value; }

        public event Action<int> ScoreChanged;

        public void Add(int value)
        {
            Score += value;
            ScoreChanged?.Invoke(Score);
        }
    }
}