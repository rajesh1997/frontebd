using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuickRepair
{
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_update", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@count", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text.Trim();

                SqlParameter p2 = new SqlParameter("@id", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text.Trim();

                SqlParameter p3 = new SqlParameter("@category", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text.Trim();

                SqlParameter p4 = new SqlParameter("@item_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = textBox4.Text.Trim();

                SqlParameter p5 = new SqlParameter("@Quantity_in_stock", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = textBox5.Text.Trim();


                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("updated successfully");
                }
                else
                {
                    MessageBox.Show("updation failed");
                    c.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service x = new service();
            x.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_d_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_quick", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@count", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text.Trim();

                SqlParameter p2 = new SqlParameter("@id", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text.Trim();

                SqlParameter p3 = new SqlParameter("@category", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text.Trim();

                SqlParameter p4 = new SqlParameter("@item_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = textBox4.Text.Trim();

                SqlParameter p5 = new SqlParameter("@Quantity_in_stock", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = textBox5.Text.Trim();


                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Stock details added");
                }
                else
                {
                    MessageBox.Show("failed");
                    c.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_fetch", c);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                c.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult check = MessageBox.Show("Are you want to delete?", "confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                    c.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete", c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@count", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = textBox6.Text;
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        MessageBox.Show("deleted Successfully");
                    }
                    c.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
                  
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_search", c);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox6.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                c.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
    }
}



