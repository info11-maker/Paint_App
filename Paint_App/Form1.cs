using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_App
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        int x1, y1;
        public Form1()
        {

            InitializeComponent();
            pic = new Bitmap(1000, 1000);
            x1 = y1 = 0;
        }
        /*private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            /*colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
            p.Color = colorDialog1.Color;*/
            Button b = (Button)sender;
            button4.BackColor = b.BackColor;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                pic.Save(saveFileDialog1.FileName);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }

        /*private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            h = e.X - x1;
            w = e.Y - y1;
            Graphics g = this.CreateGraphics(); 
            Rectangle shape = new Rectangle(x1, y1, h, w);
            if (radioButton1.Checked)
            {
                g.DrawEllipse(p, shape);
            }
            else if (radioButton2.Checked)
            {
                g.DrawRectangle(p, shape);
            }
        }*/



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button4.BackColor, trackBar1.Value);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);
            if (e.Button == MouseButtons.Left)
            {

                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                    pictureBox1.Image = pic;
                }
                x1 = e.X;
                y1 = e.Y;
            }
        }
    }
}
