using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;

namespace Copters
{
    public class RadialCoodrs
    {
        /// <summary>
        /// Радиус в радиальных координатах
        /// </summary>
        public double Radius = 0;
        /// <summary>
        /// угол поворота в радиальных координатах, градусы
        /// </summary>
        public double phi = 0;
        /// <summary>
        /// Ось Х в декарте
        /// </summary>
        public double x = 0;

        /// <summary>
        /// Ось У в декарте
        /// </summary>
        public double y = 0;

        public double LandingRadius = 0;
        protected HookUps HookUp1;
        protected HookUps HookUp2;
        protected HookUps HookUp3;
        
        public HookUps GetHookUp1
        {
            get => HookUp1;
        }
        public HookUps GetHookUp2
        {
            get => HookUp2;
        }
        public HookUps GetHookUp3
        {
            get => HookUp3;
        }

        public Point PrintHookUp1()
        {
            return new Point ((int)(HookUp1.x + rect.Width / 2), (int)(rect.Height / 2 - HookUp1.y));
        }
        public Point PrintHookUp2()
        {
            return new Point((int)(HookUp2.x + rect.Width / 2), (int)(rect.Height / 2 - HookUp2.y));
        }
        public Point PrintHookUp3()
        {
            return new Point((int)(HookUp3.x + rect.Width / 2), (int)(rect.Height / 2 - HookUp3.y));
        }
        public bool AllContactsAreNegative(double CopterRadius, double CopterAngle)
        {
            SetHookUps(CopterRadius, CopterAngle);
            if (HookUp1.IsPositive()) { return false; }
            if (HookUp2.IsPositive()) { return false; }
            if (HookUp3.IsPositive()) { return false; }

            return true;
        }
        public Rectangle rect = new Rectangle(0, 0, 0, 0);

        public RadialCoodrs()
        {

        }
        public RadialCoodrs(double R, double Phi, Rectangle Rect, double _LandingRadius)
        {
            Radius = R;
            phi = Phi;
            x = Radius * Math.Cos(phi * Math.PI / 180);
            y = Radius * Math.Sin(phi * Math.PI / 180);
            rect = Rect;
            LandingRadius = _LandingRadius;
        }
        public RadialCoodrs(float X, float Y, Rectangle Rect, double _LandingRadius)
        {
            x = (double)X;
            y = (double)Y;
            Radius = Math.Sqrt(x * x + y * y);
            if ((x == 0) & (y == 0))
            {
                phi = 0;
            }
            else
            {
                phi = Math.Atan2(y, x) * 180 / Math.PI; ;
            }
            rect = Rect;
            LandingRadius = _LandingRadius;
        }

        public Point GetPoint()
        {
            return new Point((int)GetX(), (int)GetY());
        }

        public void SetHookUps(double CopterRadius, double CopterAngle)
        {
            SetHookup1(CopterRadius, CopterAngle);
            SetHookup2(CopterRadius, CopterAngle);
            SetHookup3(CopterRadius, CopterAngle);
        }
        private void SetHookup1(double CopterRadius, double CopterRotateAngle)
        {
            double x1 = CopterRadius * Math.Cos((0 + CopterRotateAngle) * Math.PI / 180) + x;
            double y1 = CopterRadius * Math.Sin((0 + CopterRotateAngle) * Math.PI / 180) + y;
            HookUp1 = new HookUps(x1, y1,rect, LandingRadius);
        }
        private void SetHookup2(double CopterRadius, double CopterAngle)
        {
            double x2 = CopterRadius * Math.Cos((120 + CopterAngle) * Math.PI / 180) + x;
            double y2 = CopterRadius * Math.Sin((120 + CopterAngle) * Math.PI / 180) + y;
            HookUp2 = new HookUps(x2, y2, rect, LandingRadius);
        }
        private void SetHookup3(double CopterRadius, double CopterAngle)
        {
            double x3 = CopterRadius * Math.Cos((240 + CopterAngle) * Math.PI / 180) + x;
            double y3 = CopterRadius * Math.Sin((240 + CopterAngle) * Math.PI / 180) + y;
            HookUp3 = new HookUps(x3, y3, rect, LandingRadius);
        }
        public float GetX()
        {
            float result = (float)(rect.Width / 2 * (1 + x / LandingRadius));
            return result;
        }
        public float GetY()
        {
            float result = (float)(rect.Height / 2 *(1-y/LandingRadius));
            return result;
        }
        public Point ToPoint()
        {
            Point result = new Point((int)GetX(), (int)GetY());
            return result;
        }
    }

}
