using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerSizeController : MonoBehaviour
    {
        private const float TWEENING_DURATION = 0.6f;
        [SerializeField] private Transform playerTransform;
        [Inject] private PlayerStatsController statsController;

        private void Start()
        {
            statsController.BuffCountChanged += UpdateSize;
        }

        private void UpdateSize()
        {
            SetSize(statsController.Size);
        }

        public void SetSize(float size)
        {
            transform.DOScale(Vector3.one * size, TWEENING_DURATION).SetEase(Ease.OutBack);
        }

        private void OnDestroy()
        {
            statsController.BuffCountChanged -= UpdateSize;
        }
    }
}