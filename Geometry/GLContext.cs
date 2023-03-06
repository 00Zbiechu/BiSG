using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGL;
using System.Drawing;

namespace Geometry
{

    

    public class GLContext
    {
        public GLView View;
        IntPtr HDC;
        IntPtr HRC;
        public Point Rotation;



        public IntPtr Handle
        {
            get
            {
                if (HRC == IntPtr.Zero)
                {
                    HDC = View.CreateGraphics().GetHdc();
                    var pfd = new Win32.PIXELFORMATDESCRIPTOR();
                    var idx = Win32.ChoosePixelFormat(HDC, pfd);
                    Win32.SetPixelFormat(HDC, idx, pfd);
                    HRC = Win32.wglCreateContext(HDC);

                }
                return HRC;
            }
        }



        public void DrawView()
        {

            if (Handle != IntPtr.Zero)
            {
                Win32.wglMakeCurrent(HDC, HRC);
                var vp = View.ClientRectangle;
                OpenGL.glViewport(vp.Left,vp.Top, vp.Width,vp.Height);
                var bg = View.BackColor;
                OpenGL.glClearColor(bg.R/255f,bg.G/255f,bg.B/255f,1);
                OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                DrawScene();
                Win32.SwapBuffers(HDC);
            }

        }

        void DrawScene()
        {
            OpenGL.glLoadIdentity();
            DrawTriangle();

        }

        void DrawTriangle()
        {
            OpenGL.glRotated(Rotation.Y, 0, 1, 0);
            OpenGL.glRotated(Rotation.X, 1, 0, 0);
            OpenGL.glScaled(0.5,0.5,0.5);
            OpenGL.glBegin(OpenGL.GL_TRIANGLES);
            OpenGL.glColor3d(0, 0, 1);
            OpenGL.glVertex3d(-1, -1, 0);
            OpenGL.glVertex3d(+1, -1, 0);
            OpenGL.glVertex3d(0, +1, 0);
            OpenGL.glEnd();
            

        }



    }

    
}
