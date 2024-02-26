using Microsoft.Xna.Framework;

namespace shplode.Classes.GameElements
{
    /// <summary>
    /// Entity that's supposed to be part of the game, be able to interact with other GameEntites
    /// </summary>
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
