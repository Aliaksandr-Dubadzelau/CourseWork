using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork.Entity;
using OfficeClasses;
using System.Media;

using LogicDLL;
using PresenterCOM;

namespace CourseWork
{
    public partial class Form1 : Form
    {

        private readonly SaverInterface saver = new DataSaver();
        private readonly PresenterInterface presenter = new Presenter();
        private readonly MathLogic mathLogic = new MathLogic();
        
        private EntityCords entity;

        public Form1()
        {

            InitializeComponent();

            //lab 12
            this.label18 = new System.Windows.Forms.Label(); // 1
            this.textBox9 = new System.Windows.Forms.TextBox(); // 2
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem(); // 3
            this.pictureBox2 = new System.Windows.Forms.PictureBox(); // 4
            this.button1 = new System.Windows.Forms.Button(); // 5


            //1
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(296, 415);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 32);
            this.label18.TabIndex = 26;
            this.label18.Text = "sec";


            //2
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.Location = new System.Drawing.Point(159, 418);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(131, 30);
            this.textBox9.TabIndex = 17;
            this.textBox9.Text = "0,025";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;


            //3
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(208, 28);
            this.toolStripMenuItem4.Text = "Result to Word";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);


            //4
            this.pictureBox2.Location = new System.Drawing.Point(270, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1168, 356);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;


            //5
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(20, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //////////////////////////BUTTON CALCULATE/////////////////////////


        private void button1_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            try
            {
                toolStripButton1.Enabled = true;
                contextMenuStrip1.Enabled = true;
                contextMenuStrip1.Items[0].Enabled = true;
                button2.Enabled = true;

                double r0 = ReadInfoFromTextBox(textBox1);
                double P = ReadInfoFromTextBox(textBox2);
                double b = ReadInfoFromTextBox(textBox3);
                double h = ReadInfoFromTextBox(textBox4);
                double l = ReadInfoFromTextBox(textBox5);
                double E = ReadInfoFromTextBox(textBox6) * 10e10;
                double t0 = ReadInfoFromTextBox(textBox7);
                double tk = ReadInfoFromTextBox(textBox8);
                double th = ReadInfoFromTextBox(textBox9);

                entity = new EntityCords(r0, P, b, h, l, E, t0, tk, th);

                chart1.Series[0].Points.Clear();
                dataGridView1.Rows.Clear();
                entity.Clear();

                Calculate();

                button5.Enabled = true;
                toolStrip1.Items[2].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true; 
            }
            catch(Exception exception)
            {
                PlayExceptionSound();
                MessageBox.Show("Something wrong with \nyour input data.");
            }
        }


        //////////////////////////RIGHT BUTTON MENU/////////////////////////


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }


        //////////////////////////PRESENTATION/////////////////////////


        private void button4_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            try
            {
                presenter.StartPresintation();
            }
            catch(Exception exception)
            {
                PlayExceptionSound();
                MessageBox.Show("Exception. Beacause of using hacked version of PowerPoint.\n                \t\tTry again.");
            }
        }


        //////////////////////////HELP/////////////////////////


        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            Help.ShowHelp(null, @"E:\courseWork\CourseProject\CourseWork\CourseWork\help\CourseWorkHelp.chm");
        }


        //////////////////////////EXIT/////////////////////////


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            Application.Exit();
        }


        //////////////////////////ABOUT/////////////////////////


        private void button3_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            Form about = new About.About();
            about.Show();
            
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            Form about = new About.About();
            about.Show();
            
        }


        ///////////////////////////WORD/////////////////////////


        private void button2_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToWord(entity, chart1);

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToWord(entity, chart1);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToWord(entity, chart1);

        }


        ///////////////////////////EXCEL/////////////////////////


        private void button5_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToExcel(entity);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToExcel(entity);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            saver.SaveToExcel(entity);
        }


        //////////////////////////////ANIMATION//////////////////////////////


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PlayClickSound();

            float max = FindMax();
            Form animation = new Animation.Animation(max);
            animation.Show();
        }


        ///////////////////////////ADDED FUNCTIONS/////////////////////////


        private void Calculate()
        {
            int step = 1;

            double th = entity.GetTH();
            double t0 = entity.GetT0();
            double tk = entity.GetTK();
            double r0 = entity.GetR();
            double h = entity.GetH();
            double b = entity.GetB();
            double l = entity.GetL();
            double E = entity.GetE();
            double P = entity.GetP();

            while (t0 <= tk)
            {
                double resultY = mathLogic.CountY(r0, b, h, l, E, t0, P);

                dataGridView1.Rows.Add(step, t0, resultY);
                chart1.Series[0].Points.AddXY(t0, resultY);

                entity.AddT(t0);
                entity.AddY(resultY);

                t0 += th;
                t0 = Math.Round(t0, 3);
                step++;

                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }

        private double ReadInfoFromTextBox(TextBox textBox)
        {
            return Convert.ToDouble(textBox.Text);
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


        private float FindMax()
        {
            float max = 0;

            foreach(float number in entity.GetListY())
            {
                if(number > max)
                {
                    max = number;
                }
            }

            return max;
        }
    }
}
