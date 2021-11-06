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
using System.Text.RegularExpressions;

namespace Restaurant_Management_System
{
    public partial class Admin : Form
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
        public Admin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (username2.Text != "" && email.Text != "" && password.Text != "" && comboBox1.Text != "")
            {
                if (cpassword.Text == password.Text)
                {
                    if (!this.email.Text.Contains('@') || !this.email.Text.Contains('.'))
                    {
                        MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Regex phoneNumpattern = new Regex(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$");
                        if (phoneNumpattern.IsMatch(Contact.Text))
                        {
                            string type = "Admin";
                            con.Open();
                            SqlCommand com = new SqlCommand("INSERT Into Employee_signup (Name,Email,Date_Of_Birth,Passward,Gender,User_Type,Contact) VALUES (@Name,@Email,@Date_of_Birth,@Passward,@Gender,@User_Type,@Contact)", con);
                            com.Parameters.Add("@Name", username2.Text);
                            com.Parameters.Add("@Email", email.Text);
                            com.Parameters.Add("@Date_of_Birth", Convert.ToDateTime(date.Value));
                            com.Parameters.Add("@Passward", password.Text);
                            com.Parameters.Add("@Gender", comboBox1.Text);
                            com.Parameters.Add("@User_Type", type);
                            com.Parameters.Add("@Contact", Contact.Text);
                            com.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Sign Up Sucess");
                            username2.Text = "";
                            email.Text = "";
                            password.Text = "";
                            cpassword.Text = "";
                            comboBox1.Text = "";
                            Contact.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Contact Number is not Valid", "Invalid Contact Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passward Not Match", "Confirm Your Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insert Data first", "Enter Some Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Details lg = new Details();
            lg.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
