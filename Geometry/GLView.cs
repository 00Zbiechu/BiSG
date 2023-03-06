using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGL;

namespace Geometry
{
    public partial class GLView : UserControl
    {

        public GLContext Context = new GLContext();

        public GLView()
        {
            InitializeComponent();
            Context.View = this;
            ResizeRedraw = true;
            SetStyle(ControlStyles.Opaque, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Context.DrawView();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle |= Win32.CS_OWNDC;
                return cp;
            }    
            
        }
    }
}
