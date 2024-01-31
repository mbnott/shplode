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
        private const int Speed = 3;

        public Player(Sprite sprite, int x, int y, int height, int width) : base(sprite, x, y, height, width)
        {

        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _x -= Speed;
                    break;
                case Direction.Right:
                    _x += Speed;
                    break;
                case Direction.Top:
                    _y -= Speed;
                    break;
                case Direction.Bottom:
                    _y += Speed;
                    break;
                case Direction.TopLeft:
                    _x -= Speed;
                    _y -= Speed;
                    break;
                case Direction.BottomLeft:
                    _x -= Speed;
                    _y += Speed;
                    break;
                case Direction.TopRight:
                    _x += Speed;
                    _y -= Speed;
                    break;
                case Direction.BottomRight:
                    _x += Speed;
                    _y += Speed;
                    break;
            }
        }
    }
}
