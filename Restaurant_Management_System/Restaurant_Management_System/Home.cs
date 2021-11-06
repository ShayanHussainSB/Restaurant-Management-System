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
    public partial class Home : Form
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
        public Home()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbldate.Text = DateTime.Now.ToLongDateString();
            bunifuCustomLabel1.Text = Login.passingtext;
            string date = lbldate.Text;
            int admin;
            int user;
            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("SELECT * FROM Recipts",con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            int sum = 0;
            foreach(DataRow dr in dt5.Rows)
            {
                sum += Convert.ToInt32(dr["Total_Price"]);
            }
            ordrpric.Text = sum.ToString();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) From Employee_signup WHERE User_Type = 'Admin' ",con);
            cmd.ExecuteNonQuery();
            admin = (int)cmd.ExecuteScalar();
            admin_n.Text = Convert.ToString(admin);
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) From Employee_signup WHERE User_Type = 'User' ", con);
            cmd2.ExecuteNonQuery();
            user = (int)cmd2.ExecuteScalar();
            User.Text = Convert.ToString(user);
            SqlCommand cmd3 = new SqlCommand("Select * FROM  Employee_signup Where User_Type = 'Owner' ",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string name = (dr["Name"].ToString());
                owner_name.Text = name;
                string email = (dr["Email"].ToString());
                owner_email.Text = email;
            }
            
            SqlCommand query = new SqlCommand("SELECT COUNT(*) FROM Recipts Where Recipt_Date = '"+date+"'", con);
            query.ExecuteNonQuery();
            int dta = (int)query.ExecuteScalar();
            today_recipt.Text = Convert.ToString(dta);

            SqlDataAdapter q = new SqlDataAdapter("SELECT * FROM Recipts Where Recipt_Date = '" + date + "'", con);
            DataTable d = new DataTable();
            q.Fill(d);
            int sum3 = 0;
            foreach (DataRow dr in d.Rows)
            {
                sum3 += Convert.ToInt32(dr["Total_Price"]);
            }
            Today_sell.Text = sum.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Home lg = new Home();
            lg.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            Details d1 = new Details();
            d1.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {
            
        }

        private void User_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can add User " + Login.passingtext + " Proceed", "check Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UDetailscs d = new UDetailscs();
            d.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(Login.type == "Owner")
            {
                MessageBox.Show("You can add Admin " + Login.passingtext + " Proceed", "check Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_detail ad = new Admin_detail();
                ad.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry"+Login.type+ " " + Login.passingtext + " You can not use this System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            account a = new account();
            a.Show();
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

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            if (Login.type == "Owner")
            {
                MessageBox.Show("You can add Admin " + Login.passingtext + " Proceed", "check Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_detail ad = new Admin_detail();
                ad.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry" + Login.type + " " + Login.passingtext + " You can not use this System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {
           
        }

        private void admin_n_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuCustomLabel14_Click_1(object sender, EventArgs e)
        {
            UDetailscs a = new UDetailscs();
            a.Show();
            this.Hide();
        }

        private void User_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void reset_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("INSERT Into Day_Details (Todays_Selling,Generated_Recipt,Date,Time_of_reset) VALUES (@TSellings,@GRecipt,@Recipt_Date,@Recipt_Time)", con);
                com.Parameters.Add("@TSellings", Today_sell.Text);
                com.Parameters.Add("@GRecipt", today_recipt.Text);
                com.Parameters.Add("@Recipt_Date", lbldate.Text);
                com.Parameters.Add("@Recipt_Time", lbltime.Text);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Todays Data Sucessfully Saved", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : Please try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            if (Login.type == "Owner")
            {
                MessageBox.Show("You can " + Login.passingtext + " Proceed", "check Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Records a = new Records();
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry" + Login.type + " " + Login.passingtext + " You can not use this System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {
            if (Login.type == "Owner")
            {
                MessageBox.Show("You can " + Login.passingtext + " Proceed", "check Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Records a = new Records();
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry" + Login.type + " " + Login.passingtext + " You can not use this System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
            
        
    }
}
