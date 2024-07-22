﻿using System;
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

namespace Library_Management_System
{
    public partial class IssueBookReport : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");

        public IssueBookReport()
        {
            InitializeComponent();
        }

        private void IssueBookReport_Load(object sender, EventArgs e)
        {

                con.Open();
                SqlCommand cmd = new SqlCommand("Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@report", SqlDbType.NVarChar).Value = "Issue";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
        }
    }
}
