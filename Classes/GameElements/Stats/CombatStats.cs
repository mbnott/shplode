using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Stats
{
    public class CombatStats
    {
        // Unchanging stats
        private readonly int _maxHealth;
        private readonly int _bodyDamage;
        private readonly int _invulnerability;
        protected int _baseDamage;

        // Dynamic stats
        private int _health;
        private int _invLeft;

        public int MaxHealth { get => _maxHealth; }
        public int Health { get => _health; }
        public int BodyDamage { get => _bodyDamage; }
        public int BaseDamage { get => _baseDamage; }

        public CombatStats(int maxHealth, int baseDamage, int bodyDamage, int invulnerability = 16)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;
            _baseDamage = baseDamage;
            _bodyDamage = bodyDamage;
            _invulnerability = invulnerability;
            _invLeft = 0;
        }

        /// <summary>
        /// Attempts to deal damage to the entity
        /// </summary>
        /// <param name="damage">Amount of health to subtract from the health</param>
        /// <returns>False if the entity is invincible, true otherwise</returns>
        public bool DealDamage(int damage)
        {
            if (_invLeft <= 0)
            {
                _health -= damage;
                _invLeft = _invulnerability;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates stats like invulnerability left and whatnot
        /// </summary>
        public void Update()
        {
            if (_invLeft > 0)
                _invLeft--;
        }
    }
}
