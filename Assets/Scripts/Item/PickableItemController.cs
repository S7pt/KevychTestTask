using ScriptableObjects;
using Interfaces;
using UnityEngine;

namespace Item
{
    public class PickableItemController : MonoBehaviour
    {
        [SerializeField] private PickableItemVisual itemVisual;
        [SerializeField] private ItemConfig currentBuff;

        public void Init(ItemConfig buff, Color itemColor)
        {
            currentBuff = buff;
            itemVisual.SetItemColor(itemColor);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollecting collecting))
            {
                collecting.Collect(currentBuff);
                Destroy(gameObject);
            }
        }

    }
}