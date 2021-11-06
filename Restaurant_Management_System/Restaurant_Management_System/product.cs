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
    public partial class product : Form
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
        public product()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void product_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = Login.passingtext;
            id.Enabled = false;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ind = e.RowIndex;
                DataGridViewRow selectedRows = dataGridView1.Rows[ind];
                Pname.Text = Convert.ToString(selectedRows.Cells[1].Value);
                Pprice.Text = Convert.ToString(selectedRows.Cells[2].Value);
                Pcategory.Text = Convert.ToString(selectedRows.Cells[3].Value);
                id.Text = Convert.ToString(selectedRows.Cells[0].Value);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your Error :" + ex);
            }
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

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (Pname.Text != "" && Pprice.Text != "" && Pcategory.Text != "")
            {
                if (id.Text == "")
                {
                    MessageBox.Show("Enter Id Of The Product To Delete Product");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE From PRoduct WHERE Product_Id = '" + this.id.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your selected Product is Deleted");
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    Pname.Text = "";
                    Pprice.Text = "";
                    id.Text = "";
                    Pcategory.Text = "";
                        
                }
            }
            else
            {
                MessageBox.Show("Fill The Text Boxs Or Click a Row");
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Pname.Text != "" && Pprice.Text != "" && Pcategory.Text != "")
            {
                if (id.Text == "")
                {
                    MessageBox.Show("Enter Id Of The Product To Update Product");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Product SET Product_Name =@name ,Product_Price = @price,Product_Category = @category where Product_ID = '" + this.id.Text + "' ", con);
                    cmd.Parameters.Add("@name", Pname.Text);
                    cmd.Parameters.Add("@price", Pprice.Text);
                    cmd.Parameters.Add("@category", Pcategory.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated");
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    Pname.Text = "";
                    Pprice.Text = "";
                    id.Text = "";
                    Pcategory.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Fill The Text Boxs Or Click a Row");
            }
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            if (Pname.Text != "" && Pprice.Text != "" && Pcategory.Text != "")
            {
                int distance;
                if (int.TryParse(Pprice.Text, out distance))
                {
                    // it's a valid integer => you could use the distance variable here
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into Product (Product_Name,Product_Price,Product_Category) VALUES (@Product_Name,@Product_Price,@Product_Category)", con);
                    cmd.Parameters.Add("@Product_Name", Pname.Text);
                    cmd.Parameters.Add("@Product_Price", Pprice.Text);
                    cmd.Parameters.Add("@Product_Category", Pcategory.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Enter Peoduct is Added");
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    Pname.Text = "";
                    Pprice.Text = "";
                    id.Text = "";
                    Pcategory.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter A Proper Price","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insert Some Data");
            }

        }

        private void id_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Pprice_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
