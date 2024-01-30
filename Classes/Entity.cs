using shplode.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode
{
    public abstract class Entity
    {
        protected Sprite _sprite;
        protected int _x;
        protected int _y;
        protected int _height;
        protected int _width;

        public Entity(Sprite sprite, int x, int y, int height, int width) { 
            _sprite = sprite;
            _x = x;
            _y = y;
            _height = height;
            _width = width;
        }

        public Rectangle GetPosition()
        {

        }

        public bool Collides(Rectangle target)
        {
            return false;
        }
    }
}
