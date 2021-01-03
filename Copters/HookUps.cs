using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Copters
{
    public class HookUps : RadialCoodrs
    {
        public bool IsPositive()
        {
            if (Math.Sin(phi * Math.PI / 180) >= 0.5001)//((phi >= 30) & (phi <= 120))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public HookUps(double X, double Y, Rectangle _rect,  double _LandingRadius)
        {

            x = X;
            y = Y;
            Radius = Math.Sqrt(x * x + y * y);
            if ((x == 0) & (y == 0))
            {
                phi = 0;
            }
            else
            {
                phi = Math.Atan2(y, x) * 180 / Math.PI; ;
            }
            this.rect = _rect;
            LandingRadius = _LandingRadius;
        }
    }
}
