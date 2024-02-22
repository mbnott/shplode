using Microsoft.Xna.Framework;
using shplode.Classes.Pathing;
using shplode.Classes.GameElements.Stats;
using System.Reflection;

namespace shplode.Classes.GameElements
{
    public class Enemy : CombatEntity
    {
        private readonly Path _path;

        public Path Path { get => _path; }

        public Enemy(Sprite sprite, int x, int y, int width, int height, CombatStats stats) : base(sprite, x, y, width, height, stats)
        {
            _path = new Path(x, y);
        }

        public Enemy(Sprite sprite, Path path, int height, int width, CombatStats stats) : base(sprite, (int)path.GetCurrentPosition().X, (int)path.GetCurrentPosition().Y, width, height, stats) 
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
