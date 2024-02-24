using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes.Effects
{
    /// <summary>
    /// Small numbers/letters that are shown after a hit, to be used by EffectsManager
    /// </summary>
    public class DamageIndicator
    {
        private float _x, _y;
        private string _value;
        private int _duration;
        private Color _color;

        public string Value { get => _value; }
        public int Duration { get => _duration; }

        public DamageIndicator(int x, int y, string value, int duration, Color color)
        {
            _x = x;
            _y = y;
            _value = value;
            _duration = duration;
            _color = color;
        }

        public bool Update()
        {
            _y -= 3;
            _duration--;
            return _duration <= 0;
        }

        public Vector2 GetLocation() => new Vector2(_x, _y);

        public Color GetColor() => _color;
    }
}
