namespace Player
{
    public class PlayerStatsModel
    {
        private float moveSpeed;
        private float size;

        public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
        public float Size { get => size; private set => size = value; }

        public PlayerStatsModel(float moveSpeed, float size)
        {
            this.moveSpeed = moveSpeed;
            this.size = size;
        }

    }
}