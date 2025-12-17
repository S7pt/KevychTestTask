using ScriptableObjects;
using Item;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ItemsSpawner : MonoBehaviour
    {
        private const int BORDER_OFFSET = 2;
        [SerializeField] private PickableItemController itemPrefab;

        public void SpawnItems(List<PickableItemData> possibleItems, int count, float groundScale)
        {
            for (int i = 0; i < count; i++)
            {
                int itemIndex = Random.Range(0, possibleItems.Count);
                PickableItemController pickableItem = Instantiate(itemPrefab, GetRandomPointOnGround(groundScale), Quaternion.identity);
                PickableItemData item = possibleItems[itemIndex];
                pickableItem.Init(item.Item, item.ItemColor);
            }
        }

        private Vector3 GetRandomPointOnGround(float scale)
        {
            float halfX = scale / BORDER_OFFSET;
            float halfZ = scale / BORDER_OFFSET;

            float x = Random.Range(-halfX + BORDER_OFFSET, halfX - BORDER_OFFSET);
            float z = Random.Range(-halfZ + BORDER_OFFSET, halfZ - BORDER_OFFSET);

            return new Vector3(x, 0.5f, z);
        }

    }
}