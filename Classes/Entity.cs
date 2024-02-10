using Microsoft.Xna.Framework;

namespace shplode.Classes
{
    public abstract class Entity
    {
        private readonly Sprite _sprite;
        protected float _x, _y;
        private readonly int _height, _width;

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
