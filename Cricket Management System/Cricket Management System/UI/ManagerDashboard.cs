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
            _playerService = new PlayerBL();
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
            dgvPlayers.DataSource = _playerService.GetAllPlayers();
            dgvPlayers.Refresh();
            dgvSearchResults.DataSource = _playerService.GetAllPlayers();
            dgvSearchResults.Refresh();
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            numAge.Value = 18;
            cmbRole.SelectedIndex = -1;
            cmbBattingStyle.SelectedIndex = -1;
            cmbBowlingStyle.SelectedIndex = -1;
            numMatches.Value = 0;
            numRuns.Value = 0;
            numWickets.Value = 0;

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

        private CricketPlayer GetPlayerFromForm()
        {
            CricketPlayer player;
            string selectedRole;

            if (cmbRole.SelectedItem != null)
            {
                selectedRole = cmbRole.SelectedItem.ToString();
            }
            else
            {
                selectedRole = "";
            }

            switch (selectedRole)
            {
                case "Batsman":
                    Batsman batsman = new Batsman();
                    batsman.Id = selectedPlayerId;
                    batsman.Name = txtName.Text.Trim();
                    batsman.Age = (int)numAge.Value;
                    batsman.Role = "Batsman";

                    if (cmbBattingStyle.SelectedItem != null)
                    {
                        batsman.BattingStyle = cmbBattingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        batsman.BattingStyle = "";
                    }

                    batsman.BowlingStyle = "";
                    batsman.Matches = (int)numMatches.Value;
                    batsman.Runs = (int)numRuns.Value;
                    batsman.Wickets = 0;

                    int centuries;
                    if (int.TryParse(txtCenturies.Text, out centuries))
                    {
                        batsman.Centuries = centuries;
                    }
                    else
                    {
                        batsman.Centuries = 0;
                    }

                    int halfCenturies;
                    if (int.TryParse(txtHalfCenturies.Text, out halfCenturies))
                    {
                        batsman.HalfCenturies = halfCenturies;
                    }
                    else
                    {
                        batsman.HalfCenturies = 0;
                    }

                    int fours;
                    if (int.TryParse(txtFours.Text, out fours))
                    {
                        batsman.Fours = fours;
                    }
                    else
                    {
                        batsman.Fours = 0;
                    }

                    int sixes;
                    if (int.TryParse(txtSixes.Text, out sixes))
                    {
                        batsman.Sixes = sixes;
                    }
                    else
                    {
                        batsman.Sixes = 0;
                    }

                    player = batsman;
                    break;

                case "Bowler":
                    Bowler bowler = new Bowler();
                    bowler.Id = selectedPlayerId;
                    bowler.Name = txtName.Text.Trim();
                    bowler.Age = (int)numAge.Value;
                    bowler.Role = "Bowler";
                    bowler.BattingStyle = "";

                    if (cmbBowlingStyle.SelectedItem != null)
                    {
                        bowler.BowlingStyle = cmbBowlingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        bowler.BowlingStyle = "";
                    }

                    bowler.Matches = (int)numMatches.Value;
                    bowler.Runs = (int)numRuns.Value;
                    bowler.Wickets = (int)numWickets.Value;

                    int ballsBowled;
                    if (int.TryParse(txtBallsBowled.Text, out ballsBowled))
                    {
                        bowler.BallsBowled = ballsBowled;
                    }
                    else
                    {
                        bowler.BallsBowled = 0;
                    }

                    int fiveWickets;
                    if (int.TryParse(txtFiveWickets.Text, out fiveWickets))
                    {
                        bowler.FiveWicketHauls = fiveWickets;
                    }
                    else
                    {
                        bowler.FiveWicketHauls = 0;
                    }

                    player = bowler;
                    break;

                case "All-rounder":
                    AllRounder allRounder = new AllRounder();
                    allRounder.Id = selectedPlayerId;
                    allRounder.Name = txtName.Text.Trim();
                    allRounder.Age = (int)numAge.Value;
                    allRounder.Role = "All-rounder";

                    if (cmbBattingStyle.SelectedItem != null)
                    {
                        allRounder.BattingStyle = cmbBattingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        allRounder.BattingStyle = "";
                    }

                    if (cmbBowlingStyle.SelectedItem != null)
                    {
                        allRounder.BowlingStyle = cmbBowlingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        allRounder.BowlingStyle = "";
                    }

                    allRounder.Matches = (int)numMatches.Value;
                    allRounder.Runs = (int)numRuns.Value;
                    allRounder.Wickets = (int)numWickets.Value;

                    int allCenturies;
                    if (int.TryParse(txtCenturies.Text, out allCenturies))
                    {
                        allRounder.Centuries = allCenturies;
                    }
                    else
                    {
                        allRounder.Centuries = 0;
                    }

                    int allHalfCenturies;
                    if (int.TryParse(txtHalfCenturies.Text, out allHalfCenturies))
                    {
                        allRounder.HalfCenturies = allHalfCenturies;
                    }
                    else
                    {
                        allRounder.HalfCenturies = 0;
                    }

                    int allFours;
                    if (int.TryParse(txtFours.Text, out allFours))
                    {
                        allRounder.Fours = allFours;
                    }
                    else
                    {
                        allRounder.Fours = 0;
                    }

                    int allSixes;
                    if (int.TryParse(txtSixes.Text, out allSixes))
                    {
                        allRounder.Sixes = allSixes;
                    }
                    else
                    {
                        allRounder.Sixes = 0;
                    }

                    int allBallsBowled;
                    if (int.TryParse(txtBallsBowled.Text, out allBallsBowled))
                    {
                        allRounder.BallsBowled = allBallsBowled;
                    }
                    else
                    {
                        allRounder.BallsBowled = 0;
                    }

                    int allFiveWickets;
                    if (int.TryParse(txtFiveWickets.Text, out allFiveWickets))
                    {
                        allRounder.FiveWicketHauls = allFiveWickets;
                    }
                    else
                    {
                        allRounder.FiveWicketHauls = 0;
                    }

                    player = allRounder;
                    break;

                default:
                    Batsman defaultPlayer = new Batsman();
                    defaultPlayer.Id = selectedPlayerId;
                    defaultPlayer.Name = txtName.Text.Trim();
                    defaultPlayer.Age = (int)numAge.Value;
                    defaultPlayer.Role = selectedRole;

                    if (cmbBattingStyle.SelectedItem != null)
                    {
                        defaultPlayer.BattingStyle = cmbBattingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        defaultPlayer.BattingStyle = "";
                    }

                    if (cmbBowlingStyle.SelectedItem != null)
                    {
                        defaultPlayer.BowlingStyle = cmbBowlingStyle.SelectedItem.ToString();
                    }
                    else
                    {
                        defaultPlayer.BowlingStyle = "";
                    }

                    defaultPlayer.Matches = (int)numMatches.Value;
                    defaultPlayer.Runs = (int)numRuns.Value;
                    defaultPlayer.Wickets = (int)numWickets.Value;

                    player = defaultPlayer;
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

            CricketPlayer player = GetPlayerFromForm();

            if (_playerService.AddPlayer(player))
            {
                MessageBox.Show("Player added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllPlayers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Player Addition Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPlayerId <= 0)
            {
                MessageBox.Show("Please select a player to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CricketPlayer player = GetPlayerFromForm();
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

            DialogResult result = MessageBox.Show("Are you sure you want to delete this player?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                if (row.Cells["Centuries"] != null && row.Cells["Centuries"].Value != DBNull.Value)
                {
                    txtCenturies.Text = row.Cells["Centuries"].Value.ToString();
                }

                if (row.Cells["HalfCenturies"] != null && row.Cells["HalfCenturies"].Value != DBNull.Value)
                {
                    txtHalfCenturies.Text = row.Cells["HalfCenturies"].Value.ToString();
                }
                if (row.Cells["Fours"] != null && row.Cells["Fours"].Value != DBNull.Value)
                {
                    txtFours.Text = row.Cells["Fours"].Value.ToString();
                }
                if (row.Cells["Sixes"] != null && row.Cells["Sixes"].Value != DBNull.Value)
                {
                    txtSixes.Text = row.Cells["Sixes"].Value.ToString();
                }
                if (row.Cells["BallsBowled"] != null && row.Cells["BallsBowled"].Value != DBNull.Value)
                {
                    txtBallsBowled.Text = row.Cells["BallsBowled"].Value.ToString();
                }
                if (row.Cells["FiveWicketHauls"] != null && row.Cells["FiveWicketHauls"].Value != DBNull.Value)
                {
                    txtFiveWickets.Text = row.Cells["FiveWicketHauls"].Value.ToString();
                }
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearchName.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter in Search Option ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvSearchResults.DataSource = _playerService.SearchPlayersByName(search);
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
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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
            string selectedRole;
            if (cmbRole.SelectedItem != null)
            {
                selectedRole = cmbRole.SelectedItem.ToString();
            }
            else
            {
                selectedRole = "";
            }

            txtCenturies.Enabled = false;
            txtHalfCenturies.Enabled = false;
            txtFiveWickets.Enabled = false;
            txtBallsBowled.Enabled = false;
            txtFours.Enabled = false;
            txtSixes.Enabled = false;

            cmbBattingStyle.Enabled = false;
            cmbBowlingStyle.Enabled = false;

            switch (selectedRole)
            {
                case "Batsman":
                    txtCenturies.Enabled = true;
                    txtHalfCenturies.Enabled = true;
                    txtFours.Enabled = true;
                    txtSixes.Enabled = true;
                    cmbBattingStyle.Enabled = true;
                    break;

                case "Bowler":

                    txtFiveWickets.Enabled = true;
                    txtBallsBowled.Enabled = true;
                    cmbBowlingStyle.Enabled = true;
                    break;

                case "All-rounder":

                    txtCenturies.Enabled = true;
                    txtHalfCenturies.Enabled = true;
                    txtFours.Enabled = true;
                    txtSixes.Enabled = true;
                    txtFiveWickets.Enabled = true;
                    txtBallsBowled.Enabled = true;
                    cmbBattingStyle.Enabled = true;
                    cmbBowlingStyle.Enabled = true;
                    break;

                default:

                    cmbBattingStyle.Enabled = true;
                    cmbBowlingStyle.Enabled = true;
                    break;
            }
        }
    }
}
