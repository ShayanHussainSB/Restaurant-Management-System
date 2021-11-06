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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Restaurant_Management_System
{
    public partial class Records : Form
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
        SqlConnection con = new SqlConnection(Login.db);
        public Records()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Home lg = new Home();
            lg.Show();
            this.Hide();
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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Details d1 = new Details();
            d1.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            account a = new account();
            a.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = Login.passingtext;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Day_Details", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            string query = "Select * from Day_Details where Date  like '%" + this.bunifuMaterialTextbox1.Text + "%'";
            SqlDataAdapter a = new SqlDataAdapter(query, con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }
    }
}
