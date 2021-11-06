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
    public partial class Admin_detail : Form
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
        public Admin_detail()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void Admin_detail_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = Login.passingtext;
            Email.Enabled = false;
            bunifu_Type.Enabled = false;
            bunifu_contact.Enabled = false;
            bunifu_pass.Enabled = false;
            bunifu_Gender.Enabled = false;
            bunifu_name.Enabled = false;
            bunifu_id.Enabled = false;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee_signup WHERE User_Type = 'Admin' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void bunifu_id_OnValueChanged(object sender, EventArgs e)
        {
            bunifu_id.Enabled = false;
        }

        private void Email_OnValueChanged(object sender, EventArgs e)
        {
            string query = "Select * from Employee_signup where Email  like '%" + this.Email.Text + "%' AND User_Type = 'Admin'";
            SqlDataAdapter a = new SqlDataAdapter(query, con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifu_name_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifu_Gender_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifu_pass_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifu_Type_OnValueChanged(object sender, EventArgs e)
        {
            bunifu_Type.Enabled = false;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
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

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (bunifu_id != null && Email != null && bunifu_name != null && bunifu_contact != null && bunifu_pass != null && bunifu_Type != null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Employee_Signup SET Contact =@contact ,Email = @email where ID = '" + this.bunifu_id.Text + "' ", con);
                cmd.Parameters.Add("@contact", bunifu_contact.Text);
                cmd.Parameters.Add("@email", Email.Text);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee_signup WHERE User_Type = 'Admin' ", con);
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifu_id != null && Email != null && bunifu_name != null && bunifu_contact != null && bunifu_pass != null && bunifu_Type != null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE From Employee_Signup WHERE ID = '" + this.bunifu_id.Text + "' ", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee_signup WHERE User_Type = 'Admin' ", con);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.Rows[ind];
            bunifu_name.Text = Convert.ToString(selectedRows.Cells[1].Value);
            Email.Text = Convert.ToString(selectedRows.Cells[2].Value);
            bunifu_contact.Text = Convert.ToString(selectedRows.Cells[7].Value);
            bunifu_Gender.Text = Convert.ToString(selectedRows.Cells[5].Value);
            bunifu_id.Text = Convert.ToString(selectedRows.Cells[0].Value);
            bunifu_pass.Text = Convert.ToString(selectedRows.Cells[4].Value);
            bunifu_Type.Text = Convert.ToString(selectedRows.Cells[6].Value);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.Show();
            this.Hide();
        }
    }
}
