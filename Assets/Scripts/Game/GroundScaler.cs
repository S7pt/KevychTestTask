using UnityEngine;

namespace Game
{
    public class GroundScaler : MonoBehaviour
    {
        [SerializeField] private Transform ground;

        public void SetScale(float scale)
        {
            ground.localScale = new Vector3(scale, 1, scale);
        }
    }
}