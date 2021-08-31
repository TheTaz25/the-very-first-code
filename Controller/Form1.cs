using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Controller
{
    [Serializable()]
    public partial class Form1 : Form
    {
        static BinaryFormatter bin;
        static FileStream files;

        Process start = new Process();
        GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);
        //serializeable
        float tstick_links_x, tstick_links_y, trigger_right, trigger_left, tstick_rechts_x, tstick_rechts_y;
        bool button_a = false, button_b = false, b_a = false, b_lb = false, b_b = false, b_rb = false,
            b_dpad_links = false, b_dpad_rechts = false, dpad_rechts_down = false, dpad_links_down = false,
            b_lb_down = false, b_rb_down = false, b_dpad_up = false, dpad_up_down = false, b_dpad_down = false, dpad_down_down = false,
            button_x = false, b_x_down = false, button_y = false, b_y_down = false, button_start = false, b_s_down = false, button_select = false,
            b_sel_down = false, makro = false;
        public static bool tastatur = false;
        /// <summary>
        /// x=1
        /// y=2
        /// a=3
        /// b=4
        /// </summary>
        static int eingabe1 = 0, eingabe2 = 0;
        int trackbarvalue = 5;
       static string programm;
        
        public Form1()
        {
            InitializeComponent();

            if (gamepadstate.IsConnected == true)
            {
                l_checkstatus.Text = ("Controller erkannt, Nutzung erlaubt");
            }
            else
            {
                l_checkstatus.Text = ("Controller nicht erkannt, ggf neu anschliessen und erneut Versuchen!");
            }

            timer1.Enabled = true;
        }
        //Anschluss überprüfen
        private void cmd_state_reload_Click(object sender, EventArgs e)
        {
            GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);
            if (gamepadstate.IsConnected == true)
            {
                l_checkstatus.Text = ("Controller erkannt, Nutzung erlaubt");
            }
            else
            {
                l_checkstatus.Text = ("Controller nicht erkannt, ggf neu anschliessen und erneut Versuchen!");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!tastatur)
            {
                standard_steuer();
            }
            else
            {
                
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbarvalue = trackBar1.Value;
        }

        public static void boolchange()
        {
            tastatur = false;
        }
        public void standard_steuer()
        {
            datencheck();

            if (tstick_links_x != 0 || tstick_links_y != 0)
            {
                int tempx, tempy;
                tempx = Convert.ToInt16(tstick_links_x * trackbarvalue);
                tempy = (Convert.ToInt16(tstick_links_y * trackbarvalue) * (-1));
                Mouse.SetPosition(MousePosition.X + tempx, MousePosition.Y + tempy);
            }
            if (tstick_links_x == 0 && tstick_links_y == 0 && tstick_rechts_x != 0 || tstick_rechts_y != 0)
            {
                int tempx, tempy;
                tempx = Convert.ToInt16(tstick_rechts_x * (trackbarvalue / 2));
                tempy = Convert.ToInt16((tstick_rechts_y * (trackbarvalue / 2)) * (-1));
                Mouse.SetPosition(MousePosition.X + tempx, MousePosition.Y + tempy);
            }
            if (button_a == true && b_a == false)
            {
                if (makro == false)
                {
                    Class1.LeftClickDown(MousePosition.X, MousePosition.Y);
                    b_a = true;
                }
                else
                {
                    if (eingabe1 == 0)
                    {
                        eingabe1 = 3;
                    }
                    else
                    {
                        eingabe2 = 3;
                        makro = false;
                        makrostart();
                    }
                    b_a = true;
                }
            }
            if (button_a == false && b_a == true)
            {
                if(makro == false)
                Class1.LeftClickUp(MousePosition.X, MousePosition.Y);
                b_a = false;
            }
            if (button_b == true && b_b == false)
            {
                if (makro == false)
                {
                    Class1.RightClickDown(MousePosition.X, MousePosition.Y);
                    b_b = true;
                }
                else
                {
                    if (eingabe1 == 0)
                    {
                        eingabe1 = 4;
                    }
                    else
                    {
                        eingabe2 = 4;
                        makro = false;
                        makrostart();
                    }
                    b_b = true;
                }
            }
            if (button_b == false && b_b == true)
            {
                if(makro == false)
                Class1.RightClickUp(MousePosition.X, MousePosition.Y);
                b_b = false;
            }
            if (trigger_right != 0)
            {
                float wert;
                wert = ((trigger_right * 30) * (-1));
                Class1.Scroll(MousePosition.X, MousePosition.Y, wert);
            }
            if (trigger_left != 0)
            {
                float wert;
                wert = (trigger_left * 30);
                Class1.Scroll(MousePosition.X, MousePosition.Y, wert);
            }
            if (b_lb == true && b_lb_down == false)
            {
                SendKeys.Send("{ENTER}");
                b_lb_down = true;
            }
            else if (b_lb == false && b_lb_down == true)
            {
                b_lb_down = false;
            }
            if (b_rb == true && b_rb_down == false)
            {
                SendKeys.Send("{DEL}");
                b_rb_down = true;
            }
            else if (b_rb == false && b_rb_down == true)
            {
                b_rb_down = false;
            }
            if (b_dpad_links == true && dpad_links_down == false)
            {
                SendKeys.Send("{LEFT}");
                dpad_links_down = true;
            }
            else if (b_dpad_links == false && dpad_links_down == true)
            {
                dpad_links_down = false;
            }
            if (b_dpad_rechts && dpad_rechts_down == false)
            {
                SendKeys.Send("{RIGHT}");
                dpad_rechts_down = true;
            }
            else if (b_dpad_rechts == false && dpad_rechts_down == true)
            {
                dpad_rechts_down = false;
            }
            if (b_dpad_down == true && dpad_down_down == false)
            {
                SendKeys.Send("{DOWN}");
                dpad_down_down = true;
            }
            else if (b_dpad_down == false && dpad_down_down == true)
            {
                dpad_down_down = false;
            }
            if (b_dpad_up == true && dpad_up_down == false)
            {
                SendKeys.Send("{UP}");
                dpad_up_down = true;
            }
            else if (b_dpad_up == false && dpad_up_down == true)
            {
                dpad_up_down = false;
            }
            if (button_x == true && b_x_down == false)
            {
                if (makro == false)
                {
                    //SendKeys.SendWait("{ALTERNATE}");
                    //SendKeys.Send("{F4}");
                    b_x_down = true;
                }
                else
                {
                    if (eingabe1 == 0)
                    {
                        eingabe1 = 1;
                    }
                    else
                    {
                        eingabe2 = 1;
                        makro = false;
                        makrostart();
                    }
                    b_x_down = true;
                }
            }
            else if (button_x == false && b_x_down == true)
            {
                
                b_x_down = false;
            }
            if (button_y == true && b_y_down == false)
            {
                if (makro == false)
                {
                    if (tastatur == false)
                    {
                        new NoActiveForm().Show();
                        tastatur = true;
                    }
                    b_y_down = true;
                }
                else
                {
                    if (eingabe1 == 0)
                    {
                        eingabe1 = 2;
                    }
                    else
                    {
                        eingabe2 = 2;
                        makro = false;
                        makrostart();
                    }
                    b_y_down = true;
                }
            }
            else if (button_y == false && b_y_down == true)
            {
                b_y_down = false;
            }
            if (button_select == true && b_sel_down == false)
            {
                b_sel_down = true;
            }
            else if (button_select == false && b_sel_down == true)
            {
                b_sel_down = false;
            }
            if (button_start == true && b_s_down == false)
            {
                b_s_down = true;
                makro = true;
                GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
                Thread.Sleep(150);
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
                Thread.Sleep(150);
                GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
                Thread.Sleep(150);
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
            }
            else if (button_start == false && b_s_down == true)
            {
                b_s_down = false;
            }
        }
        public void datencheck()
        {
            GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);
            tstick_links_x = gamepadstate.ThumbSticks.Left.X;
            tstick_links_y = gamepadstate.ThumbSticks.Left.Y;
            button_a = Convert.ToBoolean(gamepadstate.Buttons.A);
            button_b = Convert.ToBoolean(gamepadstate.Buttons.B);
            trigger_right = gamepadstate.Triggers.Right;
            trigger_left = gamepadstate.Triggers.Left;
            b_lb = Convert.ToBoolean(gamepadstate.Buttons.LeftShoulder);
            b_rb = Convert.ToBoolean(gamepadstate.Buttons.RightShoulder);
            b_dpad_links = Convert.ToBoolean(gamepadstate.DPad.Left);
            b_dpad_rechts = Convert.ToBoolean(gamepadstate.DPad.Right);
            tstick_rechts_x = gamepadstate.ThumbSticks.Right.X;
            tstick_rechts_y = gamepadstate.ThumbSticks.Right.Y;
            b_dpad_down = Convert.ToBoolean(gamepadstate.DPad.Down);
            b_dpad_up = Convert.ToBoolean(gamepadstate.DPad.Up);
            button_x = Convert.ToBoolean(gamepadstate.Buttons.X);
            button_y = Convert.ToBoolean(gamepadstate.Buttons.Y);
            button_start = Convert.ToBoolean(gamepadstate.Buttons.Start);
            button_select = Convert.ToBoolean(gamepadstate.Buttons.Back);
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {        }
        public static void makrodaten()
        {
            /// <summary>
            /// x=1
            /// y=2
            /// a=3
            /// b=4
            /// </summary>
            switch (eingabe1)
            {
                case 1:
                    if (eingabe2 == 2)
                    {
                        programm = Makro.getxy();
                    }
                    else if (eingabe2 == 3)
                    {
                        programm = Makro.getxa();
                    }
                    else if (eingabe2 == 4)
                    {
                        programm = Makro.getxb();
                    }
                    break;

                case 2:
                    if (eingabe2 == 1)
                    {
                        programm = Makro.getyx();
                    }
                    else if (eingabe2 == 3)
                    {
                        programm = Makro.getya();
                    }
                    else if (eingabe2 == 4)
                    {
                        programm = Makro.getyb();
                    }
                    break;

                case 3:
                    if (eingabe2 == 1)
                    {
                        programm = Makro.getax();
                    }
                    else if (eingabe2 == 2)
                    {
                        programm = Makro.getay();
                    }
                    else if (eingabe2 == 4)
                    {
                        programm = Makro.getab();
                    }
                    break;

                case 4:
                    if (eingabe2 == 1)
                    {
                        programm = Makro.getbx();
                    }
                    else if (eingabe2 == 2)
                    {
                        programm = Makro.getby();
                    }
                    else if (eingabe2 == 3)
                    {
                        programm = Makro.getba();
                    }
                    break;
            }
        }
        private void makrostart()
        {
            makrodaten();
            if (programm != "")
            {
                start.StartInfo.FileName = (programm);
                start.Start();
            }
            eingabe1 = 0;
            eingabe2 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Makro().Show();
        }
    }
}
