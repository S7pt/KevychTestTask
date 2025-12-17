using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text uiScoreText;
        [SerializeField] private TMP_Text playerScoreText;

        public void SetScore(int score)
        {
            uiScoreText.text = score.ToString();
            playerScoreText.text = score.ToString();
        }
    }
}