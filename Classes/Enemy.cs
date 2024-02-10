using Microsoft.Xna.Framework;

namespace shplode.Classes
{
    public class Enemy : Entity
    {
        private readonly EnemyPath _path;

        public EnemyPath Path { get => _path; }

        public Enemy(Sprite sprite, int x, int y, int height, int width) : base(sprite, x, y, height, width)
        {
            _path = new EnemyPath(x, y);
        }

        public Enemy(Sprite sprite, EnemyPath path, int height, int width) : base(sprite, (int)path.GetCurrentPosition().X, (int)path.GetCurrentPosition().Y, height, width) 
        { 
            _path = path;
        }

        public new void Update()
        {
            _path.Move();
            Vector2 coords = _path.GetCurrentPosition();
            _x = coords.X;
            _y = coords.Y;
            
            base.Update();
        }
    }
}
