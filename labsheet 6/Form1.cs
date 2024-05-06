
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
using static System.Collections.Specialized.BitVector32;
using System.Data.SqlClient;

namespace Question1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Yr1 Sem3\C#\Lab Sheets\Lab6\Question1\Database1.mdf"";Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string dob = dateTimePicker1.Value.ToString();
            string email = textBox3.Text;
            string contactNo = textBox5.Text;
            string address = textBox6.Text;
            string username = textBox7.Text;
            string password = textBox8.Text;

            string Query1 = $"INSET INTO employee (Username, Name, DOB, Password) VALUES({username},{name},{dob},{password});";
            SqlCommand cmd1 = new SqlCommand(Query1, sqlConnection);

            string Query2 = $"INSET INTO Contact (Username, ContactNo, Email, Address) VALUES({username},{contactNo},{email},{address});";
            SqlCommand cmd2 = new SqlCommand(Query2, sqlConnection);

            try
            {
                sqlConnection.Open();
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();

                sqlConnection.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Registration successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errors:" + ex.Message, "Registration Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}