using UnityEngine;

namespace Player
{
    public class PlayerFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Camera cameraToFollow;
        [SerializeField] private Vector3 offset;
        private float baseFOV;

        private void Start()
        {
            baseFOV = cameraToFollow.fieldOfView;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            if (target.localScale.x != 1)
            {
                cameraToFollow.fieldOfView = baseFOV + Mathf.Pow(target.localScale.x, 2) * 5;
            }
            else
            {
                cameraToFollow.fieldOfView = baseFOV;
            }
            transform.position = desiredPosition;
        }
    }
}