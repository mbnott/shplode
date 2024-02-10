using Microsoft.Xna.Framework;
using shplode.Classes.Pathing;

namespace shplode.Classes.GameElements
{
    public class Enemy : GameEntity
    {
        private readonly Path _path;

        public Path Path { get => _path; }

        public Enemy(Sprite sprite, int x, int y, int width, int height) : base(sprite, x, y, width, height)
        {
            _path = new Path(x, y);
        }

        public Enemy(Sprite sprite, Path path, int height, int width) : base(sprite, (int)path.GetCurrentPosition().X, (int)path.GetCurrentPosition().Y, height, width) 
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
