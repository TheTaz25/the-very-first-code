using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public partial class Makro : Form
    {
        public static string ay, ax, ab, ya, yx, yb, xy, xa, xb, ba, by, bx;

        public bool firstload = true;
        public Makro()
        {
            InitializeComponent();
        }
        public static string getxy()
        {
            return xy;
        }
        public static string getxa()
        {
            return xa;
        }
        public static string getxb()
        {
            return xb;
        }
        public static string getyx()
        {
            return yx;
        }
        public static string getya()
        {
            return ya;
        }
        public static string getyb()
        {
            return yb;
        }
        public static string getay()
        {
            return ay;
        }
        public static string getax()
        {
            return ax;
        }
        public static string getab()
        {
            return ab;
        }
        public static string getby()
        {
            return by;
        }
        public static string getbx()
        {
            return bx;
        }
        public static string getba()
        {
            return ba;
        }

        private void tb_x_y_TextChanged(object sender, EventArgs e)
        {
            xy = tb_x_y.Text;
        }

        private void tb_x_a_TextChanged(object sender, EventArgs e)
        {
            xa = tb_x_a.Text;
        }

        private void tb_x_b_TextChanged(object sender, EventArgs e)
        {
            xb = tb_x_b.Text;
        }

        private void tb_y_a_TextChanged(object sender, EventArgs e)
        {
            ya = tb_y_a.Text;
        }

        private void tb_y_b_TextChanged(object sender, EventArgs e)
        {
            yb = tb_y_b.Text;
        }

        private void tb_y_x_TextChanged(object sender, EventArgs e)
        {
            yx = tb_y_x.Text;
        }

        private void tb_a_x_TextChanged(object sender, EventArgs e)
        {
            ax = tb_a_x.Text;
        }

        private void tb_a_y_TextChanged(object sender, EventArgs e)
        {
            ay = tb_a_y.Text;
        }

        private void tb_a_b_TextChanged(object sender, EventArgs e)
        {
            ab = tb_a_b.Text;
        }

        private void tb_b_a_TextChanged(object sender, EventArgs e)
        {
            ba = tb_b_a.Text;
        }

        private void tb_b_x_TextChanged(object sender, EventArgs e)
        {
            bx = tb_b_x.Text;
        }

        private void tb_b_y_TextChanged(object sender, EventArgs e)
        {
            by = tb_b_y.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Makro_Load(object sender, EventArgs e)
        {
            if (firstload == false)
            {
                tb_a_b.Text = ab;
                tb_a_x.Text = ax;
                tb_a_y.Text = ay;
                tb_x_a.Text = xa;
                tb_x_y.Text = xy;
                tb_x_b.Text = xb;
                tb_b_a.Text = ba;
                tb_b_y.Text = by;
                tb_b_x.Text = bx;
                tb_y_a.Text = ya;
                tb_y_x.Text = yx;
                tb_y_b.Text = yb;
            }
            else
            {
                firstload = false;                
            }
           
        }
        public string strName;

        public Makro(string str)
        {
            strName = str;
        }
    }
}
