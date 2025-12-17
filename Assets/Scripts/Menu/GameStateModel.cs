using System;

namespace Menu
{
    public class GameStateModel
    {
        private int itemsCount;
        private float startTime;
        private int itemsCollected;

        public float StartTime { get => startTime; set => startTime = value; }

        public event Action AllItemsCollected;

        public GameStateModel(int itemsCount)
        {
            this.itemsCount = itemsCount;
            itemsCollected = 0;
        }

        public void CollectItem()
        {
            itemsCollected++;
            if (itemsCollected >= itemsCount)
            {
                AllItemsCollected?.Invoke();
            }
        }
    }
}