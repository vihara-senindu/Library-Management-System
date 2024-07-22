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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = library; Integrated Security = true");
        private void loginBtn_Click(object sender, EventArgs e)
        {     
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = userNameBox.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = passwordBox.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                    passwordBox.Text = "";
                }
                con.Close();
            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
