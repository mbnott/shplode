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
        const int speed = 3;

        public Player(Sprite sprite, int x, int y, int height, int width) : base(sprite, x, y, height, width)
        {
        
        }

        /* 1 2 3
         * 4 5 6 epic directions
         * 7 8 9
         */
        public void Move(int direction)
        {
            if (direction <= 3) _y -= speed;
            else if (direction >= 7) _y += speed;

            if (direction % 3 == 1) _x -= speed;
            else if (direction % 3 == 0) _x += speed;
        }
    }
}
