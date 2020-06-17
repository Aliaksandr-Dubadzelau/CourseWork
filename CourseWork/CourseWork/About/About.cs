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

namespace CourseWork.About
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            label1.Parent = pictureBox2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            this.Close();

        }

        private void PlayClickSound()
        {

            SoundPlayer doneSound = new SoundPlayer(@"E:\courseWork\CourseProject\CourseWork\CourseWork\sounds\soundClick.wav");
            doneSound.Play();

        }
    }
}
