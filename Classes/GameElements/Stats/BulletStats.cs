using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Stats
{
    public class BulletStats
    {
        private int _damage;
        private int _piercing; // Amount of frames the bullet can stay alive while in collision with something, unused for now

        public int Damage { get => _damage; }

        public BulletStats(int damage) {
            _damage = damage;
        }
    }
}
