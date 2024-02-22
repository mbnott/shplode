using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes
{
    public static class CollisionManager
    {
        public static bool CheckCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            return rectangle2.Intersects(rectangle1);
        }
    }
}
