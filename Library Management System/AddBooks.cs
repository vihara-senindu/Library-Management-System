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

namespace Library_Management_System
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_add_Books", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@Publication", SqlDbType.NVarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@PublicationDate", SqlDbType.NVarChar).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@BookPrice", SqlDbType.NVarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Added");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
