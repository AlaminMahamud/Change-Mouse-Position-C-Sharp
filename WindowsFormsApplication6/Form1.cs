using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x00000010; /* right button down */

        [DllImport("user32.dll",
            CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
            int dwExtraInfo);

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoveCursor();
        }

        // Move Cursor
        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position, 
            // and set its clipping rectangle to the form.  

            this.Cursor = new Cursor(Cursor.Current.Handle);
            try
            {
                Cursor.Position = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                //Cursor.Position = new Point(Convert.ToInt32(25), Convert.ToInt32(40));
                //Thread.Sleep(200);
                mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                //mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);

                //x  mouse_event(MOUSEEVENTF_RIGHTDOWN, Convert.ToInt32(25), Convert.ToInt32(45), 0, 0);
            }
            catch
            {
                Cursor.Position = new Point(0, 0);
            }

            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // GetCursorPosition
            GetCursorPosition();
        }

        private void GetCursorPosition()
        {
            // Gets The Current Cursor Position
            // and sets the X and Y Value to textBoxes
            this.Cursor = new Cursor(Cursor.Current.Handle);
            label7.Text = "" + Cursor.Position.X;
            label8.Text = "" + Cursor.Position.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

    }
}
