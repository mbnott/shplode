using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace shplode.Classes.Pathing
{
    /// <summary>
    /// Property to add to an entity. Allows it to move from waypoints to other waypoints.
    /// Stays static on last waypoint
    /// </summary>
    public class Path
    {
        private readonly List<Waypoint> _waypoints;
        private int _current; // Current waypoint the entity is moving FROM
        private int _progress; // Current waypoint distance progression till next waypoint
        private bool _active;
        private bool _done;
        
        /// <summary>
        /// Static position
        /// </summary>
        /// <param name="spawnX"></param>
        /// <param name="spawnY"></param>
        public Path(int spawnX, int spawnY) {
            _waypoints = new List<Waypoint>()
            {
                new Waypoint(spawnX, spawnY)
            };
            _current = 0;
            _progress = 0;
            _active = false;
            _done = true;
        }

        /// <summary>
        /// Multiple waypoint path
        /// </summary>
        /// <param name="waypoints"></param>
        public Path(List<Waypoint> waypoints)
        {
            _waypoints = waypoints;
            _current = 0;
            _progress = 0;
            _active = false;
            _done = false;
        }

        public void AddWaypoint(int x, int y, int waitTime)
        {
            _waypoints.Add(new Waypoint(x, y, waitTime));
        }

        public void Start()
        {
            _active = true;
        }

        public void Stop()
        {
            _active = false;
        }

        public void Move()
        {
            if (_active)
            {
                if (_progress < _waypoints[_current].GetDistance())
                {
                    _progress++;
                }
                else if (_current < _waypoints.Count - 1)
                {
                    _current++;
                    _progress = 0;
                    // TODO: IMPLEMENT WAIT BETWEEN WAYPOINTS
                }
                if (_current >= _waypoints.Count - 1)
                {
                    _done = true;
                }
            }
        }

        public Vector2 GetCurrentPosition()
        {
            if (_done) return _waypoints.Last().GetPosition();
            float x = ShplodeMaths.Lerp(
                _waypoints[_current].GetPosition().X,
                _waypoints[_current + 1].GetPosition().X,
                (float)_progress / _waypoints[_current].GetDistance());
            float y = ShplodeMaths.Lerp(
                _waypoints[_current].GetPosition().Y,
                _waypoints[_current + 1].GetPosition().Y,
                (float)_progress / _waypoints[_current].GetDistance());
            return new Vector2(x, y);
        }
    }
}
