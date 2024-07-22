using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IssueBookReport iBR = new IssueBookReport();
            iBR.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReturnBookReport rBR = new ReturnBookReport();
            rBR.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReturnBook rB = new ReturnBook();
            rB.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IssueBook iB = new IssueBook();
            iB.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewStudents vS = new ViewStudents();
            vS.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBooks aB = new AddBooks();
            aB.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewBooks vB = new ViewBooks();
            vB.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStudents aS = new AddStudents();
            aS.Show();
        }
    }
}
