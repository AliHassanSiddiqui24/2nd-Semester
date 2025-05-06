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
    public partial class ManagerDashboard : Form
    {
        private readonly IPlayerService _playerService;
        private int selectedPlayerId = 0;

        public ManagerDashboard()
        {
            InitializeComponent();
            _playerService = new PlayerBL(); // Dependency Injection
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            LoadAllPlayers();
            ClearForm();
        }
        private void LoadAllPlayers()
        {
            // Populate the DataGridView with all players
            dgvPlayers.DataSource = _playerService.GetAllPlayers();
            dgvPlayers.Refresh();
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            numAge.Value = 20;
            cmbRole.SelectedIndex = -1;
            cmbBattingStyle.SelectedIndex = -1;
            cmbBowlingStyle.SelectedIndex = -1;
            numMatches.Value = 0;
            numRuns.Value = 0;
            numWickets.Value = 0;
            selectedPlayerId = 0;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private Player GetPlayerFromForm()
        {
            Player player = new Player();
            player.Id = selectedPlayerId;
            player.Name = txtName.Text.Trim();
            player.Age = (int)numAge.Value;
            player.Role = cmbRole.SelectedItem?.ToString() ?? string.Empty;
            player.BattingStyle = cmbBattingStyle.SelectedItem?.ToString() ?? string.Empty;
            player.BowlingStyle = cmbBowlingStyle.SelectedItem?.ToString() ?? string.Empty;
            player.Matches = (int)numMatches.Value;
            player.Runs = (int)numRuns.Value;
            player.Wickets = (int)numWickets.Value;
            return player;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter a player name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player role", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Player player = GetPlayerFromForm();
            if (_playerService.AddPlayer(player))
            {
                MessageBox.Show("Player added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPlayers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add player", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPlayerId <= 0)
            {
                MessageBox.Show("Please select a player to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Player player = GetPlayerFromForm();
            if (_playerService.UpdatePlayer(player))
            {
                MessageBox.Show("Player updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPlayers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to update player", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPlayerId <= 0)
            {
                MessageBox.Show("Please select a player to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this player?", "Confirm Delete",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_playerService.DeletePlayer(selectedPlayerId))
                {
                    MessageBox.Show("Player deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPlayers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete player", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPlayers.Rows[e.RowIndex];
                selectedPlayerId = Convert.ToInt32(row.Cells["Id"].Value);

                txtName.Text = row.Cells["Name"].Value.ToString();
                numAge.Value = Convert.ToInt32(row.Cells["Age"].Value);
                cmbRole.Text = row.Cells["Role"].Value.ToString();
                cmbBattingStyle.Text = row.Cells["BattingStyle"].Value.ToString();
                cmbBowlingStyle.Text = row.Cells["BowlingStyle"].Value.ToString();
                numMatches.Value = Convert.ToInt32(row.Cells["Matches"].Value);
                numRuns.Value = Convert.ToInt32(row.Cells["Runs"].Value);
                numWickets.Value = Convert.ToInt32(row.Cells["Wickets"].Value);

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchName.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvSearchResults.DataSource = _playerService.SearchPlayersByName(searchTerm);
            dgvSearchResults.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = string.Empty;
            dgvSearchResults.DataSource = _playerService.GetAllPlayers();
            dgvSearchResults.Refresh();
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
