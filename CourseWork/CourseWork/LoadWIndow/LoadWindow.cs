using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.LoadWIndow
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            timer1.Start();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();

            if (progressBar1.Value == progressBar1.Maximum)
            {
               
                Thread main =  new Thread(NewForm);
                main.Start();

                this.Close();

            }
        }

        private static void NewForm()
        {
            Form mainForm = new CourseWork.Form1();
            mainForm.ShowDialog();
        }

    }
}
