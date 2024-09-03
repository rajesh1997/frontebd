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

namespace QuickRepair
{
    public partial class purchase : Form
    {
        public purchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service g = new service();
            g.Show();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Add_d_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_quick3", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@customer_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text.Trim();

                SqlParameter p2 = new SqlParameter("@customer_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text.Trim();

                SqlParameter p3 = new SqlParameter("@mobile_no", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text.Trim();

                SqlParameter p4 = new SqlParameter("@date", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = textBox4.Text.Trim();

                SqlParameter p5 = new SqlParameter("@item", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = textBox5.Text.Trim();

                SqlParameter p6 = new SqlParameter("@Quantity", SqlDbType.VarChar);
                cmd.Parameters.Add(p6).Value = textBox6.Text.Trim();


                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Purchase details added");
                }
                else
                {
                    MessageBox.Show("failed");
                    c.Close();
                }
            }
            catch(Exception ex)
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
                SqlCommand cmd = new SqlCommand("sp_fetch1", c);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                c.Open();
                SqlCommand cmd = new SqlCommand("sp_update1", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@customer_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text.Trim();

                SqlParameter p2 = new SqlParameter("@customer_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text.Trim();

                SqlParameter p3 = new SqlParameter("@mobile_no", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text.Trim();

                SqlParameter p4 = new SqlParameter("@date", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = textBox4.Text.Trim();

                SqlParameter p5 = new SqlParameter("@item", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = textBox5.Text.Trim();

                SqlParameter p6 = new SqlParameter("@Quantity", SqlDbType.VarChar);
                cmd.Parameters.Add(p6).Value = textBox6.Text.Trim();


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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult check = MessageBox.Show("Are you want to delete?", "confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    SqlConnection c = new SqlConnection(@"Data Source = ASPIRE ;Initial catalog = electronics_system;Integrated Security = True");
                    c.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete3", c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@customer_id", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = textBox1.Text;
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
    }
}
