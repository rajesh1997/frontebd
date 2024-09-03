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
    public partial class feedback : Form
    {
        public feedback()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service w = new service();
            w.Show();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("sp_submit", c);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@your_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text.Trim();

                SqlParameter p2 = new SqlParameter("@your_feedback", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text.Trim();

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Thanks for your Feedback");
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
                SqlCommand cmd = new SqlCommand("sp_fetch5", c);
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
                    SqlCommand cmd = new SqlCommand("sp_delete4", c);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@your_name", SqlDbType.VarChar);
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
