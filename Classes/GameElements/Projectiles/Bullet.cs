using shplode.Classes.GameElements.Stats;
using shplode.Classes.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Projectiles
{
    public class Bullet : GameEntity
    {
        Path _path;
        GameEntity _owner;
        BulletStats _stats;

        GameEntity Owner { get => _owner; }
        BulletStats Stats { get => _stats; }

        public Bullet(Sprite sprite, GameEntity owner, Path path, BulletStats stats, int x, int y, int width, int height) : base(sprite, x, y, width, height)
        {
            _path = path;
            _owner = owner;
            _stats = stats;
        }

        /// <summary>
        /// Updates the bullet
        /// </summary>
        /// <returns></returns>
        public new void Update()
        {
            _path.Move();
            base.Update();
        }
    }
}
