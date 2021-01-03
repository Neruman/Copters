using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Copters
{

    public class Sector
    {
        public PictureBox Picture;
        private int badLandingCount = 0;
        public int BadLandingCount
        {
            get => badLandingCount;
            set
            {
                //???
                badLandingCount = value;
            }
        }
        public Sector() { }
        public Sector(PictureBox _PictureBox)
        {
            Picture = _PictureBox;
        }
        

    }
    public class GraphicSectrors
    {
        public Image Picture;
        public double LandingRadius;
        public double deltaPhi = 5d;
        public double deltaRadius = 5d;

        public GraphicSectrors()
        {
            
        }
        public GraphicSectrors(Image _sourcePictureBox, double _LandingRadius)
        {
            LandingRadius = _LandingRadius;
            Picture = _sourcePictureBox;
        }


        public Rectangle GetPictureBorders()
        {
            return new Rectangle(new Point(0, 0), Picture.Size);
        }


        public void DrawGrid()
        {

            using (Graphics Canvas = Graphics.FromImage(Picture))
            {
                Rectangle Rect = new Rectangle(new Point(0, 0), Picture.Size);
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    pen.DashStyle = DashStyle.Dot;
                    for (double InnerRadius = 10; InnerRadius < (LandingRadius); InnerRadius += deltaRadius)
                    {
                        Rectangle InnerRect = new Rectangle((int)(Picture.Width / 2 * (1 - InnerRadius / LandingRadius)),
                                                            (int)(Picture.Height / 2 * (1 - InnerRadius / LandingRadius)),
                                                            (int)(InnerRadius * Picture.Width / (LandingRadius)),
                                                            (int)(InnerRadius * Picture.Width / (LandingRadius)));

                        Canvas.DrawEllipse(pen, InnerRect);
                    }
                    for (double phi = 0; phi < 360; phi += deltaPhi)
                    {
                        RadialCoodrs StartPoint = new RadialCoodrs(10, phi, GetPictureBorders(), LandingRadius);
                        RadialCoodrs EndPoint = new RadialCoodrs(LandingRadius, phi, GetPictureBorders(), LandingRadius);
                        Point _StartPoint = new Point((int)StartPoint.GetX(), (int)StartPoint.GetY());
                        Point _endPoint = new Point((int)EndPoint.GetX(), (int)EndPoint.GetY());
                        Canvas.DrawLine(pen, _StartPoint, _endPoint);
                    }
                }

            } 
        }
           
        public void DrawSector(double InnerRadius, double StartPhi)
        {

            RadialCoodrs LeftInner      = new RadialCoodrs(InnerRadius,                 StartPhi,               GetPictureBorders(), LandingRadius);
            RadialCoodrs LeftOutter   = new RadialCoodrs(InnerRadius + deltaRadius,   StartPhi,               GetPictureBorders(), LandingRadius);
            RadialCoodrs RigthInner     = new RadialCoodrs(InnerRadius,                 StartPhi + deltaPhi,    GetPictureBorders(), LandingRadius);
            RadialCoodrs RigthOutter  = new RadialCoodrs(InnerRadius + deltaRadius,   StartPhi + deltaPhi,    GetPictureBorders(), LandingRadius);

            using (Graphics Canvas = Graphics.FromImage(Picture))
            {
                Rectangle Rect = new Rectangle(new Point(0,0), Picture.Size);
                

                using (Pen pen = new Pen(Color.Transparent, 1))
                {
                    Canvas.DrawLine(pen, LeftInner.GetX(), LeftInner.GetY(), LeftOutter.GetX(), LeftOutter.GetY());
                    Canvas.DrawLine(pen, RigthInner.GetX(), RigthInner.GetY(), RigthOutter.GetX(), RigthOutter.GetY());

                    Rectangle InnerRect = new Rectangle((int)(Picture.Width / 2 * (1 - InnerRadius / LandingRadius)),
                                                        (int)(Picture.Height / 2 * (1 - InnerRadius / LandingRadius)),
                                                        (int)(InnerRadius * Picture.Width / (LandingRadius)),
                                                        (int)(InnerRadius * Picture.Width / (LandingRadius)));
                    
                    Rectangle OutterRect = new Rectangle((int)(Picture.Width / 2 * (1 - (InnerRadius + deltaRadius)/ LandingRadius)),
                                                        (int)(Picture.Height / 2 * (1 - (InnerRadius + deltaRadius)/ LandingRadius)),
                                                        (int)((InnerRadius + deltaRadius) * Picture.Width / (LandingRadius)),
                                                        (int)((InnerRadius + deltaRadius) * Picture.Width / (LandingRadius)));

                    //Canvas.DrawArc(pen, InnerRect, (float)StartPhi, (float)(StartPhi + deltaPhi));
                    //Canvas.DrawArc(pen, OutterRect, (float)StartPhi, (float)(StartPhi + deltaPhi));
                }

            }

        }

    }
}
