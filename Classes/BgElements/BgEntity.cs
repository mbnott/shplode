namespace shplode.Classes.BgElements
{
    public abstract class BgEntity : Entity
    {
        public BgEntity (Sprite sprite, float x, float y, int width, int height) : base(sprite, x, y, width, height)
        {
            
        }

        public abstract void Move();
    }
}
