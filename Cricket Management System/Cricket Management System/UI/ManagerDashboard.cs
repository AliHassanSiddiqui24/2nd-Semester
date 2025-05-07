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
            dgvSearchResults.DataSource = _playerService.GetAllPlayers();
            dgvSearchResults.Refresh();
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

            // Clear additional statistics fields
            txtCenturies.Text = "0";
            txtHalfCenturies.Text = "0";
            txtFours.Text = "0";
            txtSixes.Text = "0";
            txtBallsBowled.Text = "0";
            txtFiveWickets.Text = "0";

            selectedPlayerId = 0;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private Player GetPlayerFromForm()
        {
            Player player;
            string selectedRole = cmbRole.SelectedItem?.ToString() ?? string.Empty;

            switch (selectedRole)
            {
                case "Batsman":
                    Batsman batsman = new Batsman();
                    batsman.Id = selectedPlayerId;
                    batsman.Name = txtName.Text.Trim();
                    batsman.Age = (int)numAge.Value;
                    batsman.Role = "Batsman";
                    batsman.BattingStyle = cmbBattingStyle.SelectedItem?.ToString() ?? string.Empty;
                    batsman.BowlingStyle = "";
                    batsman.Matches = (int)numMatches.Value;
                    batsman.Runs = (int)numRuns.Value;
                    batsman.Wickets = 0;

                    // Batsman-specific properties
                    batsman.Centuries = int.TryParse(txtCenturies.Text, out int centuries) ? centuries : 0;
                    batsman.HalfCenturies = int.TryParse(txtHalfCenturies.Text, out int halfCenturies) ? halfCenturies : 0;
                    batsman.Fours = int.TryParse(txtFours.Text, out int fours) ? fours : 0;
                    batsman.Sixes = int.TryParse(txtSixes.Text, out int sixes) ? sixes : 0;

                    player = batsman;
                    break;

                case "Bowler":
                    Bowler bowler = new Bowler();
                    bowler.Id = selectedPlayerId;
                    bowler.Name = txtName.Text.Trim();
                    bowler.Age = (int)numAge.Value;
                    bowler.Role = "Bowler";
                    bowler.BattingStyle = "";
                    bowler.BowlingStyle = cmbBowlingStyle.SelectedItem?.ToString() ?? string.Empty;
                    bowler.Matches = (int)numMatches.Value;
                    bowler.Runs = (int)numRuns.Value;
                    bowler.Wickets = (int)numWickets.Value;

                    // Bowler-specific properties
                    bowler.BallsBowled = int.TryParse(txtBallsBowled.Text, out int ballsBowled) ? ballsBowled : 0;
                    bowler.FiveWicketHauls = int.TryParse(txtFiveWickets.Text, out int fiveWickets) ? fiveWickets : 0;

                    player = bowler;
                    break;

                case "All-rounder":
                    AllRounder allRounder = new AllRounder();
                    allRounder.Id = selectedPlayerId;
                    allRounder.Name = txtName.Text.Trim();
                    allRounder.Age = (int)numAge.Value;
                    allRounder.Role = "All-rounder";
                    allRounder.BattingStyle = cmbBattingStyle.SelectedItem?.ToString() ?? string.Empty;
                    allRounder.BowlingStyle = cmbBowlingStyle.SelectedItem?.ToString() ?? string.Empty;
                    allRounder.Matches = (int)numMatches.Value;
                    allRounder.Runs = (int)numRuns.Value;
                    allRounder.Wickets = (int)numWickets.Value;

                    // All-rounder-specific properties
                    allRounder.Centuries = int.TryParse(txtCenturies.Text, out int allCenturies) ? allCenturies : 0;
                    allRounder.FiveWicketHauls = int.TryParse(txtFiveWickets.Text, out int allFiveWickets) ? allFiveWickets : 0;

                    player = allRounder;
                    break;

                default:
                    player = new Player();
                    player.Id = selectedPlayerId;
                    player.Name = txtName.Text.Trim();
                    player.Age = (int)numAge.Value;
                    player.Role = selectedRole;
                    player.BattingStyle = cmbBattingStyle.SelectedItem?.ToString() ?? string.Empty;
                    player.BowlingStyle = cmbBowlingStyle.SelectedItem?.ToString() ?? string.Empty;
                    player.Matches = (int)numMatches.Value;
                    player.Runs = (int)numRuns.Value;
                    player.Wickets = (int)numWickets.Value;
                    break;
            }

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

                // Load additional statistics if available in the database
                if (row.Cells["Centuries"] != null && row.Cells["Centuries"].Value != DBNull.Value)
                    txtCenturies.Text = row.Cells["Centuries"].Value.ToString();

                if (row.Cells["HalfCenturies"] != null && row.Cells["HalfCenturies"].Value != DBNull.Value)
                    txtHalfCenturies.Text = row.Cells["HalfCenturies"].Value.ToString();

                if (row.Cells["Fours"] != null && row.Cells["Fours"].Value != DBNull.Value)
                    txtFours.Text = row.Cells["Fours"].Value.ToString();

                if (row.Cells["Sixes"] != null && row.Cells["Sixes"].Value != DBNull.Value)
                    txtSixes.Text = row.Cells["Sixes"].Value.ToString();

                if (row.Cells["BallsBowled"] != null && row.Cells["BallsBowled"].Value != DBNull.Value)
                    txtBallsBowled.Text = row.Cells["BallsBowled"].Value.ToString();

                if (row.Cells["FiveWicketHauls"] != null && row.Cells["FiveWicketHauls"].Value != DBNull.Value)
                    txtFiveWickets.Text = row.Cells["FiveWicketHauls"].Value.ToString();

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem?.ToString() ?? string.Empty;

            // Hide all specialized fields first
            txtCenturies.Enabled = false;
            txtHalfCenturies.Enabled = false;
            txtFiveWickets.Enabled = false;
            txtBallsBowled.Enabled = false;
            txtFours.Enabled = false;
            txtSixes.Enabled = false;

            // Show relevant fields based on role
            switch (selectedRole)
            {
                case "Batsman":
                    txtCenturies.Enabled = true;
                    txtHalfCenturies.Enabled = true;
                    txtFours.Enabled = true;
                    txtSixes.Enabled = true;
                    break;

                case "Bowler":
                    txtFiveWickets.Enabled = true;
                    txtBallsBowled.Enabled = true;
                    break;

                case "All-rounder":
                    txtCenturies.Enabled = true;
                    txtFiveWickets.Enabled = true;
                    break;
            }
        }
    }
}
