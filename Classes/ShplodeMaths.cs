using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shplode.Classes
{
    /// <summary>
    /// Personal static class that contains very handy maths related functions
    /// </summary>
    public static class ShplodeMaths
    {
        // Linear interpolation (amount at 1 is end, 0 is start)
        public static float Lerp(float start, float end, float amount)
        {
            return start + (end - start) * amount;
        }
    }
}
