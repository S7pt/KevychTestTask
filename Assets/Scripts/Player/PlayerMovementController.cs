using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick joyStick;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float movementDamping = 8f;
        [Inject] private PlayerStatsController playerStatsController;

        private void Update()
        {
            if (joyStick.Direction != Vector2.zero)
            {
                Move(joyStick.Direction);
            }
            else if (rb.linearVelocity != Vector3.zero)
            {
                SlowDown();
            }
        }

        private void Move(Vector2 direction)
        {
            rb.linearDamping = 0;
            Vector3 forceDirection = new Vector3(-direction.x, 0, -direction.y);
            rb.linearVelocity = forceDirection * playerStatsController.MoveSpeed;
        }

        private void SlowDown()
        {
            rb.linearDamping = movementDamping;
        }
    }
}