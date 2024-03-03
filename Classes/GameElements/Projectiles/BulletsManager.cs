using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Projectiles
{
    public static class BulletsManager
    {
        private static List<Bullet> _bullets;

        public static void Initialize()
        {
             _bullets = new List<Bullet>();
        }

        public static void Update()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.Path.Start();
                bullet.Update();
            }
        }

        public static void CreateBullet(Bullet bullet)
        {
            _bullets.Add(bullet);
        }

        public static List<Bullet> GetBullets() => _bullets;
    }
}
