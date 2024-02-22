using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.GameElements.Stats
{
    /// <summary>
    /// Basic stats for enemies, bullets or players
    /// </summary>
    public abstract class Stats
    {
        protected int _baseDamage;
        public int BaseDamage { get => _baseDamage; }

        public Stats(int baseDamage)
        {
            _baseDamage = baseDamage;        
        }
    }
}
