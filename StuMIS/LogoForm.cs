using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StuMIS
{
    public partial class LogoForm : Form
    {
        private int i = 0;
        public LogoForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++; Console.WriteLine("i=", (i++).ToString());
            this.closeMe();
        }
        private void closeMe()
        {
            //timer1.Enabled = false;
            //this.Hide();
            //MainForm mainfrm = new MainForm();
            //mainfrm.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.closeMe();
        }

        private void LogoForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Yellow, 5);
            GraphicsPath gp = new GraphicsPath();  //定义一个图形路径对象
            gp.AddEllipse(new Rectangle(panel1.Left, panel1.Top, panel1.Width, panel1.Height));
            Region r = new Region(gp);
            this.Region = r;  //logo的区域为椭圆形状
            r = null;
            gp = null;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.closeMe();
        }
    }
}
