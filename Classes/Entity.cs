using Microsoft.Xna.Framework;

namespace shplode.Classes
{
    public abstract class Entity
    {
        private readonly Sprite _sprite;
        protected float _x, _y;
        protected int _width, _height;

        public Sprite Sprite { get => _sprite; }

        protected Entity(Sprite sprite, float x, float y, int width, int height) { 
            _sprite = sprite;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        
        public Rectangle GetRectangle()
        {
            return new Rectangle((int)_x, (int)_y, _width, _height);
        }

        public void Update()
        {
            Sprite.Update();
        }
    }
}
