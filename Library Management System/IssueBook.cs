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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
       
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getbooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("ViewStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Student_ID", SqlDbType.NVarChar).Value = textBox6.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                }
                dr.Close();
                con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_addissuebook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Student_ID", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("@Issue_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
                cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = " ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Issued Book Added");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
