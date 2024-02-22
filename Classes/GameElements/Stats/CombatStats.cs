using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Stats
{
    public class CombatStats : Stats
    {
        // Unchanging stats
        private int _maxHealth;
        private int _bodyDamage;
        private int _invulnerability;

        // Dynamic stats
        private int _health;
        private int _invLeft;

        public int MaxHealth { get => _maxHealth; }
        public int Health { get => _health; }
        public int BodyDamage { get => _bodyDamage; }

        public CombatStats(int maxHealth, int baseDamage, int bodyDamage, int invulnerability = 4) : base(baseDamage)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;
            _bodyDamage = bodyDamage;
            _invulnerability = invulnerability;
            _invLeft = 0;
        }

        /// <summary>
        /// Damages the entity
        /// </summary>
        /// <param name="damage">Amount of health to subtract from the health</param>
        /// <returns>False if the health is still over 0, true otherwise</returns>
        public bool Hurt(int damage)
        {
            if (_invLeft <= 0)
            {
                _health -= damage;
                _invLeft = _invulnerability;
            }
            return _health <= 0;
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
