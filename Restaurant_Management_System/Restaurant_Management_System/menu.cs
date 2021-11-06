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
    public partial class menu : Form
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
        public menu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        SqlConnection con = new SqlConnection(Login.db);
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (Login.type == "User")
            {
                MessageBox.Show("Sorry " + Login.passingtext + " You can not access this", "You are a User", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Home lg = new Home();
                lg.Show();
                this.Hide();
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (Login.type == "User")
            {
                MessageBox.Show("Sorry " + Login.passingtext + " You can not access this", "You are a User", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Details d1 = new Details();
                d1.Show();
                this.Hide();
            }
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
                menu m1 = new menu();
                m1.Show();
                this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            totl.Enabled = false;
            lbldate.Text = DateTime.Now.ToLongDateString();
            PName.Enabled = false;
            Pprice.Enabled = false;
            totl.Enabled = false;
            richTextBox1.Enabled = false;
            bunifuCustomLabel1.Text = Login.passingtext;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * From Product",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            string query = "Select * from Product where Product_Name  like '%" + this.bunifuMaterialTextbox1.Text + "%'";
            SqlDataAdapter a = new SqlDataAdapter(query, con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Sea Food'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Deals'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            menu m1 = new menu();
            m1.Show();
            this.Hide();
      
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.Rows[ind];
            PName.Text = Convert.ToString(selectedRows.Cells[1].Value);
            Pprice.Text = Convert.ToString(selectedRows.Cells[2].Value);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
          
            bool check = false;
            if (PName.Text != "" && Pprice.Text != "")
            {
                if (Quantity.Text != "0")
                {
                    if (dataGridView2.Rows.Count > 1)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                        {

                            if (dataGridView2.Rows[i].Cells[0].Value.ToString() == PName.Text)
                            {
                                check = true;
                                dataGridView2.Rows[i].Cells[2].Value = Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value) + Quantity.Value;
                                dataGridView2.Rows[i].Cells[3].Value = Convert.ToDecimal(dataGridView2.Rows[i].Cells[1].Value) * Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                            }
                        }
                    }

                    if (check != true)
                    {
                        int subtotal = Convert.ToInt32(Pprice.Text) * Convert.ToInt32(Quantity.Value);
                        string[] arr = { PName.Text, Pprice.Text, Quantity.Value.ToString(), subtotal.ToString() };
                        dataGridView2.Rows.Add(arr);
                    }
                    int total = 0;

                    for (int l = 0; l < dataGridView2.Rows.Count - 1; l++)
                    {

                        total += Convert.ToInt32(dataGridView2.Rows[l].Cells[3].Value);
                    }

                    totl.Text = total.ToString();

                }
                else
                {
                    MessageBox.Show("Please Select Your Quantity","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select your Meal","Select your meal properly",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
            PName.Text = "";
            Pprice.Text = "";
            Quantity.Text = "0";

            
           
           
           
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Bar B.Q'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Rolls'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Apetizer'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Fast Food'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Beverages'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (Login.type == "User")
            {
                MessageBox.Show("Sorry " + Login.passingtext + " You can not access this", "You are a User", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                product p = new product();
                p.Show();
                this.Hide();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.Filter = "Text files (*.txt)|.txt|All files (*.*)| *.*";

            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBox1.LoadFile(openfile.FileName, RichTextBoxStreamType.PlainText);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Notepad text";
            savefile.Filter = "Text files (*.txt)|.txt|All files (*.*)| *.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(savefile.FileName))
                    sw.WriteLine(richTextBox1.Text);

            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.Cut();
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                richTextBox1.Paste();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void PName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                if (totl.Text != "")
                {
                    if (customername.Text != "")
                    {
                        try
                        {
                            con.Open();
                            SqlCommand com = new SqlCommand("INSERT Into Recipts (Customer_Name,Total_Price,Recipt_Date,Recipt_Time) VALUES (@Customer_Name,@Total_Price,@Recipt_Date,@Recipt_Time)", con);
                            com.Parameters.Add("@Customer_Name", customername.Text);
                            com.Parameters.Add("@Total_Price", Convert.ToInt32(totl.Text));
                            com.Parameters.Add("@Recipt_Date", lbldate.Text);
                            com.Parameters.Add("@Recipt_Time", lbltime.Text);
                            com.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Query Error");
                        }
                        SqlCommand query = new SqlCommand("Select Recipt_Id From Recipts  Where Recipt_Time = '" + lbltime.Text + "'",con);
                        SqlDataAdapter adapter = new SqlDataAdapter(query);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            string name = (dr["Recipt_Id"].ToString());
                            demo.Text = name;
                        }
                        con.Close();
                        string id = demo.Text;
                        totl.Enabled = false;
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText("\t      " + "FOOD CARVING'S" + Environment.NewLine);
                        richTextBox1.AppendText("\t      " + " " + Environment.NewLine);
                        richTextBox1.AppendText("\t    " + "Pizza Fries,Karahi,B.B.Q" + Environment.NewLine);
                        richTextBox1.AppendText("        " + "Fast Food , Sea Food & Much More To Eat" + Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText("\t      " + "Recipt Information" + Environment.NewLine);
                        richTextBox1.AppendText("\t      " + " " + Environment.NewLine);
                        richTextBox1.AppendText("Recipt Id :"+ demo.Text + Environment.NewLine);
                        richTextBox1.AppendText("Name : " + customername.Text + Environment.NewLine);
                        richTextBox1.AppendText("Time : " + lbltime.Text + Environment.NewLine);
                        richTextBox1.AppendText("Date : " + lbldate.Text + Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText("\t      " + "PURCHASE" + Environment.NewLine);
                        richTextBox1.AppendText("" + Environment.NewLine);
                        richTextBox1.AppendText("Prodeucts        Price        Quantity        Total" + Environment.NewLine);
                        for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView2.Columns.Count; j++)
                            {
                                richTextBox1.Text = richTextBox1.Text + dataGridView2.Rows[i].Cells[j].Value.ToString() + "               ";
                            }
                        }
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText("Total:\t" + totl.Text + Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText("\t THANK YOU" + Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update Recipts SET Recipt = @Recipt where Recipt_Id = '" + this.demo.Text + "' ", con);
                        cmd.Parameters.Add("@Recipt", richTextBox1.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("CheckOut Sucess Please Proceed","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        printPreviewDialog1.Document = printDocument1;
                        printPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Enter Customer Name", "Customers Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Select Your Meal", "Your Meal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Clear Data For Check Out", "Your Meal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
                    }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton19_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton12_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Mutton Karahi'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton14_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Chicken Karahi'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Product Where Product_Category = 'Extras'", con);
            DataTable b = new DataTable();
            a.Fill(b);
            dataGridView1.DataSource = b;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
