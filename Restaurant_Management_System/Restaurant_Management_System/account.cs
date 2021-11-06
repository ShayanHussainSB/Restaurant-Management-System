using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Runtime.InteropServices; 
namespace Restaurant_Management_System
{
    public partial class account : Form
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
        public account()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void account_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = Login.passingtext ;
            label1.Text = Login.type;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT  * FROM Employee_signup Where Email = '"+Login.text+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               bunifu_name.Text = (dr["Name"].ToString());
               bunifu_DOB.Value = (Convert.ToDateTime(dr["Date_Of_Birth"]));
               bunifu_Gender.Text = (dr["Gender"].ToString());
            }
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
        
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            if (Login.type == "User")
            {
                userhome uh = new userhome();
                uh.Show();
                this.Hide();
            }
            else
            {
                Home g1 = new Home();
                g1.Show();
                this.Hide();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string pas;
            string pass = bunifu_Current_Password.Text;
            con.Open();
            SqlCommand cmdl = new SqlCommand("SELECT * FROM Employee_signup Where Email = '"+Login.text+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmdl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pas = (dr["Passward"].ToString());
                if (bunifu_name.Text != "" && bunifu_Gender.Text != "")
                {
                    if(pas == pass)
                    {
                        if (bunifu_new_Pass.Text == "")
                        {
                            SqlCommand cmd = new SqlCommand("Update Employee_Signup SET Name =@name ,Gender = @gender , Date_Of_Birth = @dob WHERE Email = '" + Login.text + "' ", con);
                            cmd.Parameters.Add("@name", bunifu_name.Text);
                            cmd.Parameters.Add("@gender", bunifu_Gender.Text);
                            cmd.Parameters.Add("@dob", Convert.ToDateTime(bunifu_DOB.Value));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Update Sucess");
                            account a = new account();
                            a.Show();
                            this.Hide();
                        }
                        else if (bunifu_new_Pass.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand("Update Employee_Signup SET Name =@name ,Passward = @pass,Gender = @gender , Date_Of_Birth = @dob WHERE Email = '" + Login.text + "' ", con);
                            cmd.Parameters.Add("@name", bunifu_name.Text);
                            cmd.Parameters.Add("@pass", bunifu_new_Pass.Text);
                            cmd.Parameters.Add("@gender", bunifu_Gender.Text);
                            cmd.Parameters.Add("@dob", Convert.ToDateTime(bunifu_DOB.Value));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Update Sucess");
                            account a = new account();
                            a.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Enter Text");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Data");
                }
                con.Close();
            }
        }
    }
}
