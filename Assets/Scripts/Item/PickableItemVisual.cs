using UnityEngine;

namespace Item
{
    public class PickableItemVisual : MonoBehaviour
    {
        private const string COLOR_PROPERTY_NAME = "_Color";
        [SerializeField] private Renderer itemRenderer;
        private MaterialPropertyBlock propertyBlock;

        public void SetItemColor(Color color)
        {
            propertyBlock = new MaterialPropertyBlock();
            itemRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(COLOR_PROPERTY_NAME, color);
            itemRenderer.SetPropertyBlock(propertyBlock);
        }
    }
}