using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInitializer : MonoBehaviour
    {
        [Inject] private GameSettingsModel settings;
        [SerializeField] private GroundScaler scaler;
        [SerializeField] private ItemsSpawner spawner;

        public void Initialize()
        {
            scaler.SetScale(settings.SpawnAreaSize);
            spawner.SpawnItems(settings.PickableItems, settings.NumberOfItems, settings.SpawnAreaSize);
        }
    }
}