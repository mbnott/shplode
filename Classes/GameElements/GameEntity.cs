using Microsoft.Xna.Framework;

namespace shplode.Classes.GameElements
{
    public abstract class GameEntity : Entity
    {
        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)_x, (int)_y, _width, _height); }
        }

        protected GameEntity(Sprite sprite, float x, float y, int width, int height) : base(sprite, x, y, width, height)
        { 
            
        }
    }
}
