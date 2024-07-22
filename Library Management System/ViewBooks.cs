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

namespace Library_Management_System
{
    public partial class ViewBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");

        public ViewBooks()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ViewBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ViewBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
