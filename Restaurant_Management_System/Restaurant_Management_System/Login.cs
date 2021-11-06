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
using System.Configuration;
using System.Text.RegularExpressions;
namespace Restaurant_Management_System
{
    public partial class Login : Form
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
        public static string db = "Data Source=.; Initial Catalog=Restaurant_Management_System; Integrated Security=true;";
        public static string type;
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            panel3.Hide();
        }
        public static string passingtext;
        public static string text;
        SqlConnection con = new SqlConnection(db);
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifu_email.Text != "" && pass.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name From Employee_Signup WHERE Email = '" + this.bunifu_email.Text + "'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    passingtext = (dr["Name"].ToString());
                }
                con.Close();
                LOGIN2 l1 = new LOGIN2(bunifu_email.Text, pass.Text);
                string msg = l1.chklogin();
                if (msg == "successfull")
                {
                    text = bunifu_email.Text;
                    type = "Admin";
                    MessageBox.Show("Welcome Admin " + passingtext + " You have been Login Sucessfully","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    bunifu_email.Text = "";
                    pass.Text = "";
                    Home h1 = new Home();
                    h1.Show();
                    this.Hide();
                }
                else if (msg == "successfull2")
                {
                    text = bunifu_email.Text;
                    type = "User";
                    MessageBox.Show("Welcome User " + passingtext + " You have been Login Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    userhome sh = new userhome();
                    sh.Show();
                    this.Hide();
                    bunifu_email.Text = "";
                    pass.Text = "";
                }
                else if (msg == "successfull3")
                {
                    text = bunifu_email.Text;
                    type = "Owner";
                    MessageBox.Show("Welcome Owner " + passingtext + " You have been Login Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifu_email.Text = "";
                    pass.Text = "";
                    Home h1 = new Home();
                    h1.Show();
                    this.Hide();
                }     
                else
                {
                    MessageBox.Show("Email or Password Incorrect Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                            string type = "Owner";
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
                            Login lg = new Login();
                            lg.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Contact Number is not Valid", "Invalid Contact Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Passward Not Match","Please Confirm Your Password",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insert Data first","Enter Some Input",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_signup", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                bunifuThinButton21.Hide();
            }
            else
            {
                bunifuThinButton21.Show();
            }
            con.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Contact_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void date_onValueChanged(object sender, EventArgs e)
        {

        }

        private void cpassword_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void username2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pass_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifu_email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
