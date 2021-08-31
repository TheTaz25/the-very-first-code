using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Controller
{
    public partial class NoActiveForm : Form
    {
        bool umschalt = false, shift = false, altgr = false;
        double mausx, mausy;
        public NoActiveForm()
        {
            InitializeComponent();
            this.TopMost = true;
            if (MousePosition.Y >= Screen.PrimaryScreen.Bounds.Size.Width/2)
            {
                this.SetDesktopLocation(Screen.PrimaryScreen.Bounds.Size.Width / 2 - this.Width/2, 100);
            }
            else
            {
                this.SetDesktopLocation(Screen.PrimaryScreen.Bounds.Size.Width / 2 - this.Width/2, Screen.PrimaryScreen.Bounds.Size.Height / 2 + 100);
            }
            maussetzten();
            timer1.Enabled = true;
        }
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
        private const int
            WM_MOUSEACTIVATE = 0x0021,
            MA_NOACTIVATE = 0x0003;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATE;
                return;
            }
            base.WndProc(ref m);
        }
        private const int
            WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle = WS_EX_NOACTIVATE;
                return createParams;
            }
        }
        private void setTextgross()
        {
            cmd_0.Text = "=";
            cmd_1.Text = "!";
            cmd_2.Text = "''";
            cmd_3.Text = "§";
            cmd_4.Text = "$";
            cmd_5.Text = "%";
            cmd_6.Text = "&";
            cmd_7.Text = "/";
            cmd_8.Text = "(";
            cmd_9.Text = ")";
            cmd_zirkumflex.Text = "°";
            cmd_scharfs.Text = "?";
            cmd_apostroph.Text = "`";
            cmd_q.Text = "Q";
            cmd_w.Text = "W";
            cmd_e.Text = "E";
            cmd_r.Text = "R";
            cmd_t.Text = "T";
            cmd_z.Text = "Z";
            cmd_u.Text = "U";
            cmd_i.Text = "I";
            cmd_o.Text = "O";
            cmd_p.Text = "P";
            cmd_ue.Text = "Ü";
            cmd_plus.Text = "*";
            cmd_a.Text = "A";
            cmd_s.Text = "S";
            cmd_d.Text = "D";
            cmd_f.Text = "F";
            cmd_g.Text = "G";
            cmd_h.Text = "H";
            cmd_j.Text = "J";
            cmd_k.Text = "K";
            cmd_l.Text = "L";
            cmd_oe.Text = "Ö";
            cmd_ae.Text = "Ä";
            cmd_hashtag.Text = "'";
            cmd_arrow.Text = ">";
            cmd_y.Text = "Y";
            cmd_x.Text = "X";
            cmd_c.Text = "C";
            cmd_v.Text = "V";
            cmd_b.Text = "B";
            cmd_n.Text = "N";
            cmd_m.Text = "M";
            cmd_komma.Text = ";";
            cmd_dot.Text = ":";
            cmd_minus.Text = "_";
        }
        private void setTextklein()
        {
            cmd_0.Text = "0";
            cmd_1.Text = "1";
            cmd_2.Text = "2";
            cmd_3.Text = "3";
            cmd_4.Text = "4";
            cmd_5.Text = "5";
            cmd_6.Text = "6";
            cmd_7.Text = "7";
            cmd_8.Text = "8";
            cmd_9.Text = "9";
            cmd_zirkumflex.Text = "^";
            cmd_scharfs.Text = "ß";
            cmd_apostroph.Text = "´";
            cmd_q.Text = "q";
            cmd_w.Text = "w";
            cmd_e.Text = "e";
            cmd_r.Text = "r";
            cmd_t.Text = "t";
            cmd_z.Text = "z";
            cmd_u.Text = "u";
            cmd_i.Text = "i";
            cmd_o.Text = "o";
            cmd_p.Text = "p";
            cmd_ue.Text = "ü";
            cmd_plus.Text = "+";
            cmd_a.Text = "a";
            cmd_s.Text = "s";
            cmd_d.Text = "d";
            cmd_f.Text = "f";
            cmd_g.Text = "g";
            cmd_h.Text = "h";
            cmd_j.Text = "j";
            cmd_k.Text = "k";
            cmd_l.Text = "l";
            cmd_oe.Text = "ö";
            cmd_ae.Text = "ä";
            cmd_hashtag.Text = "#";
            cmd_arrow.Text = "<";
            cmd_y.Text = "y";
            cmd_x.Text = "x";
            cmd_c.Text = "c";
            cmd_v.Text = "v";
            cmd_b.Text = "b";
            cmd_n.Text = "n";
            cmd_m.Text = "m";
            cmd_komma.Text = ",";
            cmd_dot.Text = ".";
            cmd_minus.Text = "-";
        }
        private void text_altgr_on()
        {
            cmd_3.Text = "³";
            cmd_2.Text = "²";
            cmd_7.Text = "{";
            cmd_8.Text = "[";
            cmd_9.Text = "]";
            cmd_0.Text = "}";
            cmd_scharfs.Text = " \\ ";
            cmd_q.Text = "@";
            cmd_e.Text = "€";
            cmd_plus.Text = "~";
            cmd_arrow.Text = "|";
            cmd_m.Text = "µ";
            if (shift || umschalt)
            {
                shift = false;
                umschalt = false;
                setTextklein();
            }
        }

        private void cmd_shift2_Click(object sender, EventArgs e)
        {
            shift = !shift;
            if (shift)
            {
                setTextgross();
            }
            else
            {
                setTextklein();
            }
        }
        private void cmd_shift_Click(object sender, EventArgs e)
        {
            shift = !shift;
            if (shift)
            {
                setTextgross();
            }
            else
            {
                setTextklein();
            }
        }

        private void cmd_umschalt_Click(object sender, EventArgs e)
        {
            umschalt = !umschalt;
            if (umschalt)
            {
                setTextgross();
            }
            else
            {
                setTextklein();
            }
        }

        private void cmd_1_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("!"); 
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("1");
            }
        }

        private void cmd_close_Click(object sender, EventArgs e)
        {
            Mouse.SetPosition(Convert.ToInt16(mausx), Convert.ToInt16(mausy));
            changebool();
            this.Close();
        }

        private void cmd_2_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("''");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("2");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("²");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_3_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("§");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("3");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("³");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_altgr_Click(object sender, EventArgs e)
        {
            altgr = !altgr;
            if (altgr)
            {
                setTextklein();
                text_altgr_on();
            }
            else
            {
                setTextklein();
            }
        }

        private void cmd_4_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("$");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("4");
            }
        }

        private void cmd_5_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("{%}");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("5");
            }
        }

        private void cmd_6_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("{&}");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("6");
            }
        }

        private void cmd_7_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("/");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("7");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("{{}");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_8_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                if (shift)
                {
                    setTextklein();
                }
                SendKeys.Send("{(}");
                shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("8");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("[");
                altgr = false;
                setTextklein();
            }
            
        }

        private void cmd_9_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("{)}");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("9");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("]");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_0_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("=");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("0");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("{}}");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_scharfs_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("?");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("ß");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send(@"{\}");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_apostroph_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("`");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("´");
            }
        }

        private void cmd_zirkumflex_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("°");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send(Convert.ToString(cmd_zirkumflex.Text));
            }
        }

        private void cmd_tab_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void cmd_q_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("Q");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("q");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("@");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_w_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("W");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("w");
            }
        }

        private void cmd_e_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("E");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("e");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("€");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_r_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("R");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("r");
            }
        }

        private void cmd_t_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("T");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("t");
            }
        }

        private void cmd_z_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("Z");
               
                if (shift)
                {
                    setTextklein();
                } shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("z");
            }
        }

        private void cmd_u_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("U");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("u");
            }
        }

        private void cmd_i_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("I");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("i");
            }
        }

        private void cmd_o_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("O");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("o");
            }
        }

        private void cmd_p_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("P");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("p");
            }
        }

        private void cmd_ue_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("Ü");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("ü");
            }
        }

        private void cmd_plus_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send("*");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("{+}");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("{~}");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_a_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("A");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("a");
            }
        }

        private void cmd_s_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("S");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("s");
            }
        }

        private void cmd_d_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("D");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("d");
            }
        }

        private void cmd_f_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("F");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("f");
            }
        }

        private void cmd_g_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("G");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("g");
            }
        }

        private void cmd_h_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("H");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("h");
            }
        }

        private void cmd_j_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("J");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("j");
            }
        }

        private void cmd_k_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("K");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("k");
            }
        }

        private void cmd_l_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("L");
                
                if (shift)
                {
                    setTextklein();
                }shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("l");
            }
        }

        private void cmd_oe_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("Ö");               
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("ö");
            }
        }

        private void cmd_ae_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("Ä");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("ä");
            }
        }

        private void cmd_hashtag_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("'");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("#");
            }
        }

        private void cmd_arrow_Click(object sender, EventArgs e)
        {
            if (umschalt || shift && !altgr)
            {
                SendKeys.Send(">");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift && !altgr)
            {
                SendKeys.Send("<");
            }
            else if (!umschalt && !shift && altgr)
            {
                SendKeys.Send("|");
                altgr = false;
                setTextklein();
            }
        }

        private void cmd_y_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("Y");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("y");
            }
        }

        private void cmd_x_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("X");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("x");
            }
        }

        private void cmd_c_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("C");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("c");
            }
        }

        private void cmd_v_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("V");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("v");
            }
        }

        private void cmd_b_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("B");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("b");
            }
        }

        private void cmd_n_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("N");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("n");
            }
        }

        private void cmd_m_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("M");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("m");
            }
        }

        private void cmd_komma_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send(";");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send(",");
            }
        }

        private void cmd_dot_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send(":");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send(".");
            }
        }

        private void cmd_minus_Click(object sender, EventArgs e)
        {
            if (umschalt || shift)
            {
                SendKeys.Send("_");
                if (shift)
                {
                    setTextklein();
                }
                shift = false;
            }
            else if (!umschalt && !shift)
            {
                SendKeys.Send("-");
            }
        }

        private void cmd_space_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void cmd_enter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
            if (cmd_enter_close.Checked == true)
            {
                Mouse.SetPosition(Convert.ToInt16(mausx), Convert.ToInt16(mausy));
                changebool();
                this.Close();
            }
        }
        public static void changebool()
        {
            Form1.boolchange();
        }
        private void maussetzten()
        {
            mausx = MousePosition.X;
            mausy = MousePosition.Y;
            int bildposx = Convert.ToInt16(this.DesktopLocation.X), bildposy = Convert.ToInt16(this.DesktopLocation.Y);
            Mouse.SetPosition(bildposx + 25+16, bildposy+25+16);
        }
        private void weitergabe_tastatur_links_ablauf() 
        {
            if (MousePosition.X > this.DesktopLocation.X + 50 && MousePosition.Y < this.DesktopLocation.Y + this.Height - 100)
            {
                Mouse.SetPosition(MousePosition.X - 56, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 50 && MousePosition.Y < this.DesktopLocation.Y + this.Height - 100)
            {
                Mouse.SetPosition(MousePosition.X + 672 , MousePosition.Y);
            }
            else
            {
                links_exception();
            }
            
        }
        private void links_exception()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(MousePosition.X + 560, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 460)
            {
                Mouse.SetPosition(MousePosition.X - 224, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 628)
            {
                Mouse.SetPosition(MousePosition.X - 196 , MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X+ 748)
            { 
                Mouse.SetPosition(MousePosition.X -140, MousePosition.Y);
            }
        }
        private void weitergabe_tastatur_rechts_ablauf()
        {
            if (MousePosition.X < this.DesktopLocation.X + this.Width - 50 && MousePosition.Y < this.DesktopLocation.Y + this.Height - 100)
            {
                Mouse.SetPosition(MousePosition.X + 56, MousePosition.Y);
            }
            else if (MousePosition.X > this.DesktopLocation.X + this.Width - 50 && MousePosition.Y < this.DesktopLocation.Y + this.Height - 100)
            {
                Mouse.SetPosition(MousePosition.X - 672, MousePosition.Y);
            }
            else
            {
                rechts_exception();
            }
        }
        private void rechts_exception()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(MousePosition.X + 224, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 460)
            {
                Mouse.SetPosition(MousePosition.X + 196, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 628)
            {
                Mouse.SetPosition(MousePosition.X + 140, MousePosition.Y);
            }
            else if (MousePosition.X < this.DesktopLocation.X+ 748)
            { 
                Mouse.SetPosition(MousePosition.X -560, MousePosition.Y);
            }
        
        }
        private void weitergabe_tastatur_unten_ablauf()
        {
            if (MousePosition.Y < this.DesktopLocation.Y + 174)
            {
                Mouse.SetPosition(MousePosition.X, MousePosition.Y + 56);
            }
            else if (MousePosition.Y < this.DesktopLocation.Y + 230)
            {
                unten_exception1();
            }
            else
            {
                unten_exception2();
            }
        }
        private void unten_exception1()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 121, MousePosition.Y + 56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 454)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 345, MousePosition.Y + 56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 622)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 541, MousePosition.Y + 56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + this.Width)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 681, MousePosition.Y + 56);
            }
        }
        private void unten_exception2()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 149, MousePosition.Y - 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 454)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 373, MousePosition.Y - 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 541)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 541, MousePosition.Y - 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + this.Width)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 653, MousePosition.Y - 224);
            }
        }
        private void weitergabe_tastatur_oben_ablauf()
        {
            if (MousePosition.Y > this.DesktopLocation.Y + 62 && MousePosition.Y < this.DesktopLocation.Y + 230)
            {
                Mouse.SetPosition(MousePosition.X, MousePosition.Y - 56);
            }
            else if (MousePosition.Y > this.DesktopLocation.Y + 230)
            {
                oben_exception1();
            }
            else
            {
                //Screen.PrimaryScreen.Bounds.Size.Height
                oben_exception2();
            }
        }
        private void oben_exception1()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 149, MousePosition.Y -56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 454)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 373, MousePosition.Y -56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 622)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 541, MousePosition.Y -56);
            }
            else if (MousePosition.X < this.DesktopLocation.X + this.Width)
            {
                Mouse.SetPosition(this.DesktopLocation.X + this.Width - 37, MousePosition.Y -56);
            }
        }
        private void oben_exception2()
        {
            if (MousePosition.X < this.DesktopLocation.X + 230)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 121, MousePosition.Y + 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 454)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 345, MousePosition.Y + 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + 622)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 541, MousePosition.Y + 224);
            }
            else if (MousePosition.X < this.DesktopLocation.X + this.Width)
            {
                Mouse.SetPosition(this.DesktopLocation.X + 681, MousePosition.Y + 224);
            }
        }

        bool button_a = false, button_b = false, b_a = false, b_lb = false, b_b = false, b_rb = false,
    b_dpad_links = false, b_dpad_rechts = false, dpad_rechts_down = false, dpad_links_down = false,
   /* b_lb_down = false, b_rb_down = false,*/ b_dpad_up = false, dpad_up_down = false, b_dpad_down = false, dpad_down_down = false,
    button_x = false, /*b_x_down = false,*/ button_y = false, b_y_down = false, button_start = false, /*b_s_down = false,*/ button_select = false
    /*b_sel_down = false*/;
        GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);
        float tstick_links_x, tstick_links_y, trigger_right, trigger_left, tstick_rechts_x, tstick_rechts_y;

        public void tastatur_steuer()
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

            if (b_dpad_links == true && dpad_links_down == false)
            {
                weitergabe_tastatur_links_ablauf();
                dpad_links_down = true;
            }
            else if (b_dpad_links == false && dpad_links_down == true)
            {
                dpad_links_down = false;
            }
            if (b_dpad_rechts && dpad_rechts_down == false)
            {
                weitergabe_tastatur_rechts_ablauf();
                dpad_rechts_down = true;
            }
            else if (b_dpad_rechts == false && dpad_rechts_down == true)
            {
                dpad_rechts_down = false;
            }
            if (b_dpad_down == true && dpad_down_down == false)
            {
                weitergabe_tastatur_unten_ablauf();
                dpad_down_down = true;
            }
            else if (b_dpad_down == false && dpad_down_down == true)
            {
                dpad_down_down = false;
            }
            if (b_dpad_up == true && dpad_up_down == false)
            {
                weitergabe_tastatur_oben_ablauf();
                dpad_up_down = true;
            }
            else if (b_dpad_up == false && dpad_up_down == true)
            {
                dpad_up_down = false;
            }
            if (button_x == true)
            {
                Mouse.SetPosition(Convert.ToInt16(mausx), Convert.ToInt16(mausy));
                changebool();
                this.Close();
            }
            if (button_a == true && b_a == false)
            {
                Class1.LeftClickDown(MousePosition.X, MousePosition.Y);
                Class1.LeftClickUp(MousePosition.X, MousePosition.Y);
                b_a = true;
            }
            else if (button_a == false && b_a == true)
            {
                b_a = false;
            }
            if (button_y == true && b_y_down == false)
            {
                SendKeys.Send("{BACKSPACE}");
                b_y_down = true;
            }
            else if (button_y == false && b_y_down == true)
            {
                b_y_down = false;
            }
            if (button_b == true && b_b == false)
            {
                SendKeys.Send(" ");
                b_b = true;
            }
            else if (button_b == false && b_b == true)
            {
                b_b = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tastatur_steuer();
        }

    }
}
