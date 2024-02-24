using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using shplode.Classes.GameElements.Stats;

namespace shplode.Classes.GameElements
{
    /// <summary>
    /// More specific entities expected to move around on the field, with various stats and able to shoot bullets
    /// </summary>
    public abstract class CombatEntity : GameEntity
    {
        private CombatStats _stats;
        public CombatStats Stats { get => _stats; }

        public CombatEntity(Sprite sprite, float x, float y, int width, int height, CombatStats stats) : base(sprite, x, y, width, height)
        {
            _stats = stats;
        }

        /// <summary>
        /// Damages the entity and displays the value
        /// </summary>
        /// <param name="damage">Amount of health to subtract</param>
        /// <returns>True if the entity is still alive, false otherwise</returns>
        public bool Hurt(int damage)
        {
            bool success = _stats.DealDamage(damage);
            if (success)
                EffectsManager.CreateDamageIndicator((int)_x, (int)_y, damage.ToString(), 45, Color.Blue);
            return _stats.Health > 0;
        }

        public new void Update()
        {
            _stats.Update();
            base.Update();
        }
    }
}
