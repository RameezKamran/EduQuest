using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EduQuestFinal
{
    public partial class Form3 : Form
    {
        
        public string LoggedInUsername { get; private set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ramee\Documents\mydb.accdb;";
            OleDbConnection conn = new OleDbConnection(connString);
            conn.Open();

            string query = "SELECT Username FROM Users WHERE [email] = ? AND [Password] = ?";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", email);
            cmd.Parameters.AddWithValue("?", password);

            object userExists = cmd.ExecuteScalar();
            if(userExists != null)
            {
                string str = userExists.ToString();
                MessageBox.Show("Login successful!");
                Form4 dashboard = new Form4(str);
                dashboard.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Incorrect Email or Password, try again!");
            }

        }
    }
}
