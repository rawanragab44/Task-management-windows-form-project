using EvaluationProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EvaluationProject
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TaskManagementDB context = new TaskManagementDB())
            {
                string username = textBox1.Text.ToLower();
                string password = textBox2.Text;

                // Find user in database
                var user = context.users.FirstOrDefault(u => u.Name.ToLower() == username && u.Password == password);

                if (user != null)
                {
                    Form1 taskForm = new Form1(user);
                    taskForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
