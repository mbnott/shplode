using Microsoft.Xna.Framework.Graphics;
using shplode.Classes.GameElements.Projectiles;
using shplode.Classes.GameElements.Stats;
using shplode.Classes.Pathing;
using System.Collections.Generic;
using System.Data;

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

        public void Shoot(Texture2D texture)
        {
            // TODO: CHANGE ASAP! THIS IS FOUL!!!
            Path path = new Path(new List<Waypoint>() { new Waypoint(BoundingBox.Center.X, BoundingBox.Center.Y, 140), new Waypoint((int)_x, (int)_y - 1000) });
            Sprite sprite = new Sprite(texture, 1);
            Bullet bullet = new Bullet(sprite, this, path, new BulletStats(_stats.BaseDamage), 5, 40);
            BulletsManager.CreateBullet(bullet);
        }
    }
}
