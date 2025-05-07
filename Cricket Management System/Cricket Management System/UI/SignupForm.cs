using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cricket_Management_System.BL;

namespace Cricket_Management_System.UI
{
    public partial class SignupForm : Form
    {
        private readonly IUserService _userService;

        public SignupForm()
        {
            InitializeComponent();
            _userService = new UserBL(); // Dependency Injection
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            // Add roles to the combo box
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("Viewer");
            cmbRole.SelectedIndex = 1; // Default to Viewer
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblMessage.Text = "Please fill in all fields";
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match";
                return;
            }

            if (_userService.Register(username, password, role))
            {
                MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblMessage.Text = "Username already exists or registration failed";
            }
        }

 

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}