using Microsoft.Xna.Framework;

namespace shplode.Classes
{
    /// <summary>
    /// Single waypoint an entity can move to/from using EntityPath
    /// </summary>
    public class EnemyWaypoint
    {
        private float _x;
        private float _y;
        private int _distance; // Amount of positions the entity will have to travel before getting to the next waypoint
        private int _pauseTime; // Amount of milliseconds the entity will stay on this waypoint for

        public EnemyWaypoint(int x, int y, int distance = 0, int pauseTime = 0) 
        {
            _x = x;
            _y = y;
            _distance = distance;
            _pauseTime = pauseTime;
        }

        public Vector2 GetPosition()
        {
            return new Vector2(_x, _y);
        }

        public int GetDistance()
        {
            return _distance;
        }
    }
}
