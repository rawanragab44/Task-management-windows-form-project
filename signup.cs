using EvaluationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationProject
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TaskManagementDB context = new TaskManagementDB())
            {
                string username = textBox1.Text.Trim();
                string email = textBox2.Text.Trim();
                string password = textBox3.Text;
                string confirmPassword = textBox4.Text;

                // 🔹 Regex for Name (Only letters, min 3 chars, max 20)
                string namePattern = @"^[A-Za-z\s]{3,20}$";

                // 🔹 Regex for Email (Standard email format)
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // ✅ Validate Name
                if (!Regex.IsMatch(username, namePattern))
                {
                    MessageBox.Show("Invalid name! Use only letters (3-20 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Validate Email
                if (!Regex.IsMatch(email, emailPattern))
                {
                    MessageBox.Show("Invalid email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Validate Password Match
                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Check if Username Exists
                bool userExists = context.users.Any(u => u.Name.ToLower() == username.ToLower());
                if (userExists)
                {
                    MessageBox.Show("Username already exists. Choose another one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Save New User
                User newUser = new User
                {
                    Name = username,
                    Email = email,
                    Password = password
                };

                context.users.Add(newUser);
                context.SaveChanges();
                MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loginform login = new loginform();
                login.Show();
                this.Hide();
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }
    }
}
