﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class ReturnBook : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=library; Integrated Security=true");

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("ViewIssueBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Student_ID", SqlDbType.NVarChar).Value = textBox6.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
                con.Open();
                SqlCommand cmd = new SqlCommand("Update_issuebook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Returned");
                con.Close(); 
        }
    }
}
 