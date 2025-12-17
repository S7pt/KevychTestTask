using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObject/GameSettingsModel", order = 0)]
    public class GameSettingsModel : ScriptableObject
    {
        [SerializeField] private int numberOfItems;
        [SerializeField] private float spawnAreaSize;
        [SerializeField] private List<PickableItemData> pickableItems;
        [SerializeField] private float playerMoveSpeed;
        [SerializeField] private float playerSize;

        public int NumberOfItems { get => numberOfItems; set => numberOfItems = value; }
        public float SpawnAreaSize { get => spawnAreaSize; set => spawnAreaSize = value; }
        public List<PickableItemData> PickableItems { get => pickableItems; set => pickableItems = value; }
        public float PlayerMoveSpeed { get => playerMoveSpeed; set => playerMoveSpeed = value; }
        public float PlayerSize { get => playerSize; set => playerSize = value; }
    }

    [Serializable]
    public class PickableItemData
    {
        [SerializeField] private Color itemColor;
        [SerializeField] private ItemConfig item;

        public Color ItemColor => itemColor;
        public ItemConfig Item => item;
    }
}