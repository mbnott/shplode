using shplode.Classes.GameElements.Stats;
using shplode.Classes.Pathing;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Projectiles
{
    public class Bullet : GameEntity
    {
        private readonly Path _path;
        private readonly GameEntity _owner;
        private readonly BulletStats _stats;

        public Path Path { get => _path; }
        public GameEntity Owner { get => _owner; }
        public BulletStats Stats { get => _stats; }

        public Bullet(Sprite sprite, GameEntity owner, Path path, BulletStats stats, int width, int height) : base(sprite, path.GetCurrentPosition().X, path.GetCurrentPosition().Y, width, height)
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
            Vector2 coords = _path.GetCurrentPosition();
            _x = coords.X;
            _y = coords.Y;
            base.Update();
        }
    }
}
