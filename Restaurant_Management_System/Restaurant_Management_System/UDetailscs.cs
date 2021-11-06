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
    public partial class UDetailscs : Form
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
        public UDetailscs()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
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

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UDetailscs_Load(object sender, EventArgs e)
        {
            Email.Enabled = false;
            bunifu_id.Enabled = false;
            Bunifu_type.Enabled = false;
            Bunifu_Pass.Enabled = false;
            Gender.Enabled = false;
            bunifu_name.Enabled = false;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee_signup WHERE User_Type = 'User' ",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void email_OnValueChanged(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_signup Where Email = '" + email.Text + "'", con);
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
             
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void Email_r_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            Gender.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ind = e.RowIndex;
                DataGridViewRow selectedRows = dataGridView1.Rows[ind];
                bunifu_name.Text = Convert.ToString(selectedRows.Cells[1].Value);
                Email.Text = Convert.ToString(selectedRows.Cells[2].Value);
                bunifu_Contact.Text = Convert.ToString(selectedRows.Cells[7].Value);
                Gender.Text = Convert.ToString(selectedRows.Cells[5].Value);
                bunifu_id.Text = Convert.ToString(selectedRows.Cells[0].Value);
                Bunifu_Pass.Text = Convert.ToString(selectedRows.Cells[4].Value);
                Bunifu_type.Text = Convert.ToString(selectedRows.Cells[6].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Your Error :" +ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Email_OnValueChanged_1(object sender, EventArgs e)
        {
            string query = "Select * from Employee_signup where Email  like '%" + this.Email.Text + "%' AND User_Type = 'User'";
            SqlDataAdapter a = new SqlDataAdapter(query, con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifu_name_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Bunifu_Pass_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Bunifu_type_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifu_id_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (bunifu_id != null && Email != null && bunifu_name != null && bunifu_Contact != null && Bunifu_Pass != null && Bunifu_type != null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE From Employee_Signup WHERE ID = '" + this.bunifu_id.Text + "' ", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee_signup WHERE User_Type = 'User' ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                MessageBox.Show("Fill The Text Boxs Or Click a Row");
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
    }
}
