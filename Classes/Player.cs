using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes
{
    public class Player : Entity
    {
        private int _speed;

        public Player(Sprite sprite, int x, int y, int height, int width, int speed = 3) : base(sprite, x, y, height, width)
        {
            _speed = speed;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _x -= _speed;
                    break;
                case Direction.Right:
                    _x += _speed;
                    break;
                case Direction.Up:
                    _y -= _speed;
                    break;
                case Direction.Down:
                    _y += _speed;
                    break;
            }
        }
    }
}
