using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Copters
{

    public partial class Form1 : Form
    {


        private Color NegColor = Color.YellowGreen;
        private Color PosColor = Color.SkyBlue;

        public double LandRadius = 150;
        public double CopterRadius = 120;
        public double CopterAngle = 0d;

        public double CopterR = 0f;
        public double CopterPhi = 0f;

        public RadialCoodrs CopterPosition = new RadialCoodrs();

        public int AllTry = 0;
        public int BadTry = 0;

        public List<Point> BadPointHookUps = new List<Point>();
        public List<Point> BadPointCenters = new List<Point>();
        public List<Point> FastMemoryHookUps = new List<Point>();
        public List<Point> FastMemoryCenters = new List<Point>();

        public List<string> BadMessages = new List<string>();
        public string QuickMessage = "";

        public GraphicSectrors SectorDB;
        public StreamWriter File;
        Bitmap Map;
        public Form1()
        {
            InitializeComponent();
            UpdateNumeric();
        }

        public void UpdateNumeric()
        {
            LandingRadiusUpDown1.Value = (decimal)(LandRadius);
            CopterRadiusUpDown2.Value = (decimal)(CopterRadius);
            /*
            numericUpDown3.Value = (decimal)CopterAngle;
            numericUpDown4.Value = (decimal)CopterR;
            numericUpDown5.Value = (decimal)CopterPhi;*/
        }

        /// <summary>
        /// Возвращает Rectangle, соответствующий размеру PictureBox1
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(new Point(0, 0), pictureBox1.Size);
        }

        /// <summary>
        /// Возвращает Декартовы координаты центра коптера по его полярным координатам
        /// </summary>
        /// <returns></returns>
        public RadialCoodrs GetCopterCenter()
        {
            return new RadialCoodrs(CopterR, CopterPhi, GetRectangle(),LandRadius);
        }
        public void DrawLandingPlace()
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                Rectangle Rect = new Rectangle(pictureBox1.Location, pictureBox1.Size);
                Canvas.Clear(Color.White);
                Brush NegBrush = new SolidBrush(NegColor);
                Brush PosBrush = new SolidBrush(PosColor);
                using (Pen pen = new Pen(Color.Black, 1))
                {

                    Canvas.DrawRectangle(pen, GetRectangle());
                    Canvas.FillEllipse(NegBrush, GetRectangle());
                    Canvas.DrawEllipse(pen, GetRectangle());

                    Canvas.DrawPie(pen, GetRectangle(), -30, 120);
                    Canvas.DrawPie(pen, GetRectangle(), -150, 120);
                    Canvas.FillPie(PosBrush, GetRectangle(), -30, -120);
                    NegBrush.Dispose();
                    PosBrush.Dispose();
                }

            }
        }
       
        /// <summary>
        /// Отмечает центр коптера при неудачной посадке
        /// </summary>
        /// <param name="Center">Координаты коптера в Radial</param>
        public void PrintCenter(RadialCoodrs Center)
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                using (Pen pen = new Pen(Color.DarkRed, 1))
                {
                    Canvas.DrawEllipse(pen, new Rectangle((int)Center.GetX(), (int)Center.GetY(), 1, 1));
                }
            }
        }
        public void PrintCenter(Point Center)
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                using (Pen pen = new Pen(Color.DarkRed, 1))
                {
                    Canvas.DrawEllipse(pen, new Rectangle(Center.X, Center.Y, 1, 1));
                }
            }
        }
        public void PrintPoint(RadialCoodrs point)
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    try
                    {
                        RectangleF rect = new RectangleF(point.GetX(), point.GetY(), 1, 1);
                        Canvas.DrawEllipse(pen, rect);
                    }
                    catch { }
                }
            }
        }
        public void PrintPoint(Point point)
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                using (Pen pen = new Pen(Color.Black,1))
                {
                    Canvas.DrawEllipse(pen, point.X, point.Y, 1, 1);
                }
            }
        }
        public void PrintLandingPoint1(Point point)
        {
            using (Graphics Canvas = Graphics.FromImage(Map))
            {
                using (Pen pen = new Pen(Color.FromArgb(53, 23, 12)))
                {
                    Canvas.DrawEllipse(pen, point.X, point.Y, 1, 1);
                }
            }
        }
        private void Activate(object sender, EventArgs e)
        {
            panel2_Resize(sender,e);

            Map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(Map, GetRectangle());

            DrawLandingPlace();

            SectorDB = new GraphicSectrors(Map, LandRadius);
            
            SectorDB.DrawGrid();
            pictureBox1.Image = Map;
            
            
        }



        public void RotateCopter(RadialCoodrs CopterCenter, double CopterRad)
        {

            for (double CopterRotateAngle = 0; CopterRotateAngle < 120; CopterRotateAngle += 0.5d)
            {
                AllTry++;
                if (CopterCenter.AllContactsAreNegative(CopterRad, CopterRotateAngle) == true)
                {
                    if (!BadPointCenters.Contains(CopterCenter.ToPoint())) { BadPointCenters.Add(CopterCenter.ToPoint()); FastMemoryCenters.Add(CopterCenter.ToPoint()); }
                    CopterCenter.SetHookUps(CopterRadius, CopterRotateAngle);
                    if (!BadPointHookUps.Contains(CopterCenter.GetHookUp1.ToPoint())) { BadPointHookUps.Add(CopterCenter.GetHookUp1.ToPoint()); FastMemoryHookUps.Add(CopterCenter.GetHookUp1.ToPoint()); }
                    if (!BadPointHookUps.Contains(CopterCenter.GetHookUp2.ToPoint())) { BadPointHookUps.Add(CopterCenter.GetHookUp2.ToPoint()); FastMemoryHookUps.Add(CopterCenter.GetHookUp2.ToPoint()); }
                    if (!BadPointHookUps.Contains(CopterCenter.GetHookUp3.ToPoint())) { BadPointHookUps.Add(CopterCenter.GetHookUp3.ToPoint()); FastMemoryHookUps.Add(CopterCenter.GetHookUp3.ToPoint()); }
                    // Обратить внимание
                    //PrintCopterStandPoints(CopterCenter, CopterRad, A);
                    //string output = $"[{(int)(CopterCenter.GetHookUp1.phi)} {(int)(CopterCenter.GetHookUp2.phi)} {(int)(CopterCenter.GetHookUp3.phi)}] {CopterR} {CopterPhi}";
                    try
                    {
                        BadTry++;
                        BadMessages.Add($" BadLandings\t{BadTry}\t \t LegsAngles\t[{(CopterRotateAngle)}\t{(CopterRotateAngle+120)}\t{(CopterRotateAngle + 240)}]\t\t CopterRadialCoordinats \t[{CopterCenter.Radius}\t{CopterCenter.phi}°]\t\t Bad Chance\t{Convert.ToString(BadTry * 100d / AllTry)}%");
                    }
                    catch (Exception e) { }
                }

            }
        }

       
        public void ExpAction(CopterCoords Coords)
        {
            RadialCoodrs Copter = new RadialCoodrs(Coords.CopterShift, Coords.CopterPhi, GetRectangle(), LandRadius);
            RotateCopter(Copter, CopterRadius);
        }

        public void Experiment()
        {
            AllTry = 0;
            BadTry = 0;
            
            List<Task<string>> TaskList= new List<Task<string>>();
            MainBar.Maximum = (int)((LandRadius - CopterRadius) / 1);
            MainBar.Step = 1;
            MainBar.Value = 0;
            double deltaPhi = 0.5d;
            SecondBar.Maximum = (int)(360 / deltaPhi);
            SecondBar.Step = 1;
            
            for (double CopterShift = 0; CopterShift <= (LandRadius - CopterRadius); CopterShift++)
            {
                SecondBar.Value = 0;
                for (double CopterPhi = 0; CopterPhi < 360; CopterPhi = CopterPhi + deltaPhi)
                {
                    RadialCoodrs Copter = new RadialCoodrs(CopterShift, CopterPhi, GetRectangle(), LandRadius);
                    RotateCopter(Copter, CopterRadius);
                    SecondBar.PerformStep();
                    BadLabel.Text = $"Bad Landings: {BadTry}";
                    BadLabel.Refresh();
                    AllLabel.Text = $"All Landings: {AllTry}";
                    AllLabel.Refresh();
                    ChanceLabel.Text = $"Bad Chance: {(float)((float)BadTry * 100 / AllTry)}%";
                    ChanceLabel.Refresh();


                }

                StageLabel.Text = $"Experiment stage: {MainBar.Value}/{MainBar.Maximum}";
                StageLabel.Refresh();
                PaintCenters();
                PaintBadPoints();
                pictureBox1.Refresh();
                WriteResults();

                MainBar.PerformStep();
                QuickMessage = $"All landings: {AllTry}\r\nBad Landings: {BadTry}\r\nAnalysed radial landing: {CopterShift}/{LandRadius-CopterRadius}\r\nBadChance: {(float)((float)BadTry *100/AllTry)}%";

                
                
                //textBox1.Text = QuickMessage;
                //textBox1.Refresh();
                //panel1.Refresh();
                //label6.Text = "Идёт анализ";
                
                //textBox1.Text = $"Неудачных попаданий: {BadTry} \n\r Всего просчитано попаданий: {AllTry} \n\r Вероятность неудачи: {Convert.ToString(BadTry * 100d / AllTry)}%";
            
            }
            WriteResults();
            pictureBox1.Refresh();

        }

        public void WriteResults()
        {
            string path1 = Directory.GetCurrentDirectory() + "\\";
            string path2 = $"Landing_{LandRadius}_Copter_{CopterRadius}.txt";
            string path3 = path1 + path2;
            File = new StreamWriter(path3, true);

            foreach (string Message in BadMessages)
            {
             File.WriteLine(Message);
            }
            File.Close();
            BadMessages.Clear();
        }
        public void PaintBadPoints()
        {
            foreach (Point HookUp in FastMemoryHookUps)
            {
                if (!BadPointCenters.Contains(HookUp))
                {
                    PrintPoint(HookUp);
                }
            }
            FastMemoryHookUps.Clear();
        }
        public void PaintCenters()
        {
            foreach (Point center in FastMemoryCenters)
            {
                PrintCenter(center);
            }
            FastMemoryCenters.Clear();
        }

        public class CopterCoords
        {
            public double CopterShift;
            public double CopterPhi;
            
            public CopterCoords (double _Shift, double _Phi)
            {
                CopterShift = _Shift;
                CopterPhi = _Phi;
            }
        }

        public void PrintCopterStandPoints(RadialCoodrs CopterCenter, double CopterRadius, double CopterAngle)
        {
            this.PrintCenter(CopterCenter);
            CopterCenter.SetHookUps(CopterRadius, CopterAngle);
            this.PrintLandingPoint1(CopterCenter.PrintHookUp1());
            this.PrintLandingPoint1(CopterCenter.PrintHookUp2());
            this.PrintLandingPoint1(CopterCenter.PrintHookUp3());
        }

        #region Индикаторы

        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.LandRadius = (double)(LandingRadiusUpDown1.Value);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.CopterRadius = (double)(CopterRadiusUpDown2.Value);
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (CopterR > (LandRadius - CopterRadius))
            {
                CopterR = (LandRadius - CopterRadius);
                UpdateNumeric();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DrawLandingPlace();
            Experiment();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.None;
            pictureBox1.Top = 0;
            pictureBox1.Left = 0;
            if (panel2.Width < panel2.Height)
            {
                pictureBox1.Width = panel2.Width;
                pictureBox1.Height = panel2.Width;
                pictureBox1.Left = 0;
                pictureBox1.Top = (panel2.Height - panel2.Width) / 2;
            }
            else
            {
                pictureBox1.Width = panel2.Height;
                pictureBox1.Height = panel2.Height;
                pictureBox1.Top = 0;
                pictureBox1.Left = (panel2.Width - panel2.Height) / 2;
            }
        }

        #endregion


    }
}


