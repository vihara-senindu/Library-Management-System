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
    public partial class AddStudents : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");
        public AddStudents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_addStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Student_Id", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = textBox6.Text;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox4.Text;
                cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Details Added");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
