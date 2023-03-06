using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point StartPos;


        private void glView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                glView1.Context.Rotation.X += e.Y - StartPos.Y;
                glView1.Context.Rotation.Y += e.X - StartPos.X;
                StartPos = e.Location;
                glView1.Invalidate();
            }
        }
    }
}
