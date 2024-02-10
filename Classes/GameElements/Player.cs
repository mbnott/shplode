namespace shplode.Classes.GameElements
{
    public class Player : GameEntity
    {
        private readonly int _speed;

        public Player(Sprite sprite, int x, int y, int height, int width, int speed = 3) : base(sprite, x, y, height, width)
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
