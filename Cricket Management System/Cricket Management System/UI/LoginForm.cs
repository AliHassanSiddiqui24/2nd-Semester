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
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserBL();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password";
                return;
            }

            string role;
            if (_userService.Login(username, password, out role))
            {
                lblMessage.Text = "Login successful!";

                if (role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
                {
                    ManagerDashboard managerDashboard = new ManagerDashboard();
                    this.Hide();
                    managerDashboard.ShowDialog();
                    this.Close();
                }
                else if (role.Equals("Viewer", StringComparison.OrdinalIgnoreCase))
                {
                    ViewerDashboard viewerDashboard = new ViewerDashboard();
                    this.Hide();
                    viewerDashboard.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                lblMessage.Text = "Invalid username or password";
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            this.Hide();
            signupForm.ShowDialog();
            this.Show();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
