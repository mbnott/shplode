using Microsoft.Xna.Framework;

namespace shplode.Classes.GameElements
{
    public abstract class GameEntity : Entity
    {
        protected GameEntity(Sprite sprite, float x, float y, int width, int height) : base(sprite, x, y, width, height)
        { 
            
        }

        public bool Collides(Rectangle target)
        {
            return false; // TODO
        }
    }
}
