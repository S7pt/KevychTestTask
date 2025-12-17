using ScriptableObjects;
using Interfaces;
using Menu;
using Score;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerCollectingHandler : MonoBehaviour, ICollecting
    {
        [Inject] PlayerStatsController statsController;
        [Inject] ScoreModel scoreModel;
        [Inject] GameStateModel gameStateModel;

        public void Collect(ItemConfig config)
        {
            statsController.AddBuff(config);
            scoreModel.Add(config.ScoreValue);
            gameStateModel.CollectItem();
        }
    }
}