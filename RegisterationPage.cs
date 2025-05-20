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

namespace EduQuestFinal
{
    public partial class Form2 : Form
    {
        int id  = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            int age = int.Parse(textBox2.Text);
            string email = textBox4.Text;


            if (username!="" && password!="" && email!="")
            {
                if(age>=18)
                {
                    MessageBox.Show("This Platform is only for Children aged below 18.");
                }

                else
                {
                    string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ramee\Documents\mydb.accdb;";
                    OleDbConnection conn = new OleDbConnection(connString);
                    conn.Open();

                    string query = "INSERT INTO Users ([Username], [Password], [Age],[email],[userID]) VALUES (?, ?, ?,?,?)";


                    OleDbCommand cmd = new OleDbCommand(query, conn);


                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);
                    cmd.Parameters.AddWithValue("?", age);
                    cmd.Parameters.AddWithValue("?", email);
                    cmd.Parameters.AddWithValue("?", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data inserted successfully!");
                    id++;

                    conn.Close();

                    this.Hide();
                    Form3 loginForm = new Form3();
                    loginForm.Show();

                }
            }

            else
            {
                MessageBox.Show("Please Fill All Fields!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
