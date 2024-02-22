using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements
{
    /// <summary>
    /// Basic stats for enemies and players
    /// </summary>
    public class Stats
    {
        private int _maxHealth;
        private int _health;
        private int _baseDamage;
        private int _bodyDamage;

        public int MaxHealth { get => _maxHealth; }
        public int Health { get => _health; }
        public int BaseDamage { get => _baseDamage; }
        public int BodyDamage { get => _bodyDamage; }

        public Stats(int maxHealth, int baseDamage, int bodyDamage) {
            _maxHealth = maxHealth;
            _health = maxHealth;
            _baseDamage = baseDamage;
            _bodyDamage = bodyDamage;
        }

        /// <summary>
        /// Damages the entity
        /// </summary>
        /// <param name="damage">Amount of health to subtract from the health</param>
        /// <returns>False if the health is still over 0, true otherwise</returns>
        public bool Hurt(int damage)
        {
            _health -= damage;
            return _health <= 0;
        }
    }
}
