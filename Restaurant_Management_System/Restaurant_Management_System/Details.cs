using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Restaurant_Management_System
{
    public partial class Details : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Details()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Home lg = new Home();
            lg.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Details d1 = new Details();
            d1.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = Login.passingtext;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(Login.type == "Admin")
            {
                MessageBox.Show("Type Check Sucess Welcome Admin " + Login.passingtext + " You can add User", "Can Access This ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User u = new User();
                u.Show();
                this.Hide();
            }
            else if(Login.type == "Owner")
            {
                MessageBox.Show("Type Check Sucess Welcome Owner " + Login.passingtext + " You can add User", "Can Access This ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User u = new User();
                u.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Type Check Sucess User " + Login.passingtext + " You can not add User", "Can Not Access This ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Login.type == "Admin")
            {
                MessageBox.Show("Type Check Sucess Welcome Admin " + Login.passingtext + " You can not Use this", "Can Not Access This ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Login.type == "Owner")
            {
                MessageBox.Show("Type Check Sucess Welcome Owner " + Login.passingtext + " You can use this", "Can Access This ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin u = new Admin();
                u.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Type Check Sucess User " + Login.passingtext + " You can not add User", "Can Not Access This ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            account a = new account();
            a.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            menu m1 = new menu();
            m1.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.Show();
            this.Hide();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            orderdetails od = new orderdetails();
            od.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            orderdetails od = new orderdetails();
            od.Show();
            this.Hide();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
