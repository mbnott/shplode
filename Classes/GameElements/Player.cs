using shplode.Classes.GameElements.Stats;

namespace shplode.Classes.GameElements
{
    public class Player : CombatEntity
    {
        private readonly int _speed;

        public Player(Sprite sprite, int x, int y, int height, int width, CombatStats stats, int speed) : base(sprite, x, y, height, width, stats)
        {
            _speed = speed;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _x -= _speed;
                    break;
                case Direction.Right:
                    _x += _speed;
                    break;
                case Direction.Up:
                    _y -= _speed;
                    break;
                case Direction.Down:
                    _y += _speed;
                    break;
            }
        }
    }
}
