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
    public partial class ViewerDashboard : Form
    {
        private readonly IPlayerService _playerService;

        public ViewerDashboard()
        {
            InitializeComponent();
            _playerService = new PlayerBL(); // Dependency Injection
        }

        private void ViewerDashboard_Load(object sender, EventArgs e)
        {
            LoadAllPlayers();
        }
        private void LoadAllPlayers()
        {
            dgvPlayers.DataSource = _playerService.GetAllPlayers();
            dgvPlayers.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchName.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvPlayers.DataSource = _playerService.SearchPlayersByName(searchTerm);
            dgvPlayers.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = string.Empty;
            LoadAllPlayers();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Confirm before logout
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Close current form and show login form
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
