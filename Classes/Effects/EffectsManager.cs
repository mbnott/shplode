using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using shplode.Classes.Effects;

namespace shplode.Classes
{
    public static class EffectsManager
    {
        private static List<DamageIndicator> _damageIndicators;

        public static void CreateDamageIndicator(int x, int y, string value, int duration, Color color)
        {
            _damageIndicators.Add(new DamageIndicator(x, y, value, duration, color));
        }

        public static void Initialize()
        {
            _damageIndicators = new List<DamageIndicator>();
        }

        public static List<DamageIndicator> GetDamageIndicators() => _damageIndicators;

        public static void Update()
        {
            for (int i = 0; i < _damageIndicators.Count; i++)
            {
                bool isDone = _damageIndicators[i].Update();
                if (isDone)
                {
                    _damageIndicators.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
