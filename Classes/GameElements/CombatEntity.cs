using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public new void Update()
        {
            _stats.Update();
            base.Update();
        }
    }
}
