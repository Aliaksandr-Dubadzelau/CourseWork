using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.Animation
{
    public partial class Animation : Form
    {
        private readonly static float DEFAULT_X1 = 100.0F;
        private readonly static float DEFAULT_X2 = 450.0F;
        private readonly static float DEFAULT_Y = 150.0F;
        private readonly static float MAX_WIDTH = 150.0F;
        private readonly static float MIN_WIDTH = 0.86F;

        // карандаш для рисования
        private bool isForce = true;

        private float width;
        private float currentY;
        private float step;
        private float startAngle = 180.0F;
        private float endAngle = 180.0F;
        private float leftX = DEFAULT_X1;
        private float rightX = DEFAULT_X2;

        public Animation(float width)
        {
            InitializeComponent();
            this.width = width;
            this.currentY = width;
            this.step = width / 10;
        }

        private void Animation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            timer1.Stop();
            this.Close();
        }

        private void PlayClickSound()
        {

            SoundPlayer doneSound = new SoundPlayer(@"E:\courseWork\CourseProject\CourseWork\CourseWork\sounds\soundClick.wav");
            doneSound.Play();

        }

        private void PlayExceptionSound()
        {

            SoundPlayer doneSound = new SoundPlayer(@"E:\courseWork\CourseProject\CourseWork\CourseWork\sounds\soundException.wav");
            doneSound.Play();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen aniamationPen = new Pen(Color.Black, 10);
            Pen staticFigure = new Pen(Color.SaddleBrown, 5);
            Pen power = new Pen(Color.Red, 4);

            int staticFigure1X1 = 100;
            int staticFigure1X2 = 100;
            int staticFigure1Y1 = 150;
            int staticFigure1Y2 = 400;

            int staticFigure2X1 = 450;
            int staticFigure2X2 = 450;
            int staticFigure2Y1 = 150;
            int staticFigure2Y2 = 400;

            e.Graphics.DrawLine(staticFigure, new Point(staticFigure1X1, staticFigure1Y1), new Point(staticFigure1X2, staticFigure1Y2));
            e.Graphics.DrawLine(staticFigure, new Point(staticFigure2X1, staticFigure2Y1), new Point(staticFigure2X2, staticFigure2Y2));

            if (isForce)
            {

                int x1 = (int)DEFAULT_X1;
                int x2 = (int)DEFAULT_X2;
                int y1 = (int)DEFAULT_Y;
                int y2 = (int)DEFAULT_Y;

                int powerLineX1 = 275;
                int powerLineX2 = 275;
                int powerLineY1 = 140;
                int powerLineY2 = 110;

                Point[] polygon = new Point[] { new Point(270, 138), new Point(280, 138), new Point(275, 143) };

                e.Graphics.DrawLine(aniamationPen, new Point(x1, y1), new Point(x2, y2));
                e.Graphics.DrawLine(power, new Point(powerLineX1, powerLineY1), new Point(powerLineX2, powerLineY2));
                e.Graphics.DrawPolygon(power, polygon);
                e.Graphics.DrawString("Pressing force", new Font("Palatino Linotype", 14), Brushes.Red, 215, 75);
                e.Graphics.DrawString("        We can display vibrations with level more then 0.86 and less then 150.", new Font("Palatino Linotype", 12), Brushes.DarkGreen, 0, 220);
                e.Graphics.DrawString("\t\t\tYour vibration level: " + width, new Font("Palatino Linotype", 11), Brushes.DarkGreen, 0, 260);

            }
            else
            {

                if (currentY + step > width)
                {
                    step = -step;
                }

                if (currentY + step <= 0)
                {
                    step = Math.Abs(step);

                    if (startAngle == 180.0F)
                    {
                        startAngle = 0.0F;
                        endAngle = 180.0F;
                    }
                    else
                    {
                        startAngle = 180.0F;
                        endAngle = 180.0F;
                    }
                }

                currentY += step;

                e.Graphics.DrawArc(aniamationPen, leftX, DEFAULT_Y - currentY, rightX - leftX, currentY + currentY, startAngle, endAngle);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            isForce = false;

            if (width > MAX_WIDTH)
            {
                PlayExceptionSound();
                MessageBox.Show("It is not possible to display\nvery powerful vibrations.");
            }
            else if (width < MIN_WIDTH)
            {
                PlayExceptionSound();
                MessageBox.Show("It is not possible to display\nweak vibrations.");
            }
            else
            {
                timer1.Interval = 50; //интервал 20 мс
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Invalidate();

        }
    }
}
