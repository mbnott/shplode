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
        protected float _x;
        protected float _y;
        protected int _height;
        protected int _width;

        public Sprite Sprite { get => _sprite; }

        public Entity(Sprite sprite, int x, int y, int height, int width) { 
            _sprite = sprite;
            _x = x;
            _y = y;
            _height = height;
            _width = width;
        }

        public void Update()
        {
            Sprite.Update();
        }

        public Rectangle GetPosition()
        {
            return new Rectangle((int)_x, (int)_y, _width, _height);
        }

        public bool Collides(Rectangle target)
        {
            return false; // TODO
        }
    }
}
