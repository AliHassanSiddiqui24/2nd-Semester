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
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            txtSearchName.Text = string.Empty;
            LoadAllPlayers();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dgvPlayers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a player to view statistics", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dgvPlayers.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string name = row.Cells["Name"].Value.ToString();
            int age = Convert.ToInt32(row.Cells["Age"].Value);
            string role = row.Cells["Role"].Value.ToString();
            string battingStyle = row.Cells["BattingStyle"].Value.ToString();
            string bowlingStyle = row.Cells["BowlingStyle"].Value.ToString();
            int matches = Convert.ToInt32(row.Cells["Matches"].Value);
            int runs = Convert.ToInt32(row.Cells["Runs"].Value);
            int wickets = Convert.ToInt32(row.Cells["Wickets"].Value);

            // Get additional statistics from row if they exist
            int centuries = 0, halfCenturies = 0, fours = 0, sixes = 0, ballsBowled = 0, fiveWicketHauls = 0;

            // Safely get values if they exist
            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "Centuries"))
                centuries = row.Cells["Centuries"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Centuries"].Value) : 0;

            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "HalfCenturies"))
                halfCenturies = row.Cells["HalfCenturies"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["HalfCenturies"].Value) : 0;

            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "Fours"))
                fours = row.Cells["Fours"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Fours"].Value) : 0;

            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "Sixes"))
                sixes = row.Cells["Sixes"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Sixes"].Value) : 0;

            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "BallsBowled"))
                ballsBowled = row.Cells["BallsBowled"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["BallsBowled"].Value) : 0;

            if (row.Cells.Cast<DataGridViewCell>().Any(c => c.OwningColumn.Name == "FiveWicketHauls"))
                fiveWicketHauls = row.Cells["FiveWicketHauls"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["FiveWicketHauls"].Value) : 0;

            // Create appropriate player type based on role - demonstrating polymorphism
            Player player;
            string stats = "";

            switch (role)
            {
                case "Batsman":
                    Batsman batsman = new Batsman(name, age, battingStyle, matches, runs, centuries, halfCenturies, fours, sixes);
                    stats = $"Batting Average: {batsman.CalculateBattingAverage():F2}\n";
                    stats += $"Centuries: {centuries}\n";
                    stats += $"Half Centuries: {halfCenturies}\n";
                    stats += $"Fours: {fours}\n";
                    stats += $"Sixes: {sixes}\n";
                    player = batsman;
                    break;

                case "Bowler":
                    Bowler bowler = new Bowler(name, age, bowlingStyle, matches, wickets, runs, ballsBowled, fiveWicketHauls);
                    stats = $"Bowling Average: {bowler.CalculateBowlingAverage():F2}\n";
                    stats += $"Balls Bowled: {ballsBowled}\n";
                    stats += $"Five Wicket Hauls: {fiveWicketHauls}\n";
                    if (ballsBowled > 0)
                    {
                        stats += $"Economy Rate: {bowler.CalculateEconomyRate():F2}\n";
                    }
                    player = bowler;
                    break;

                case "All-rounder":
                    AllRounder allRounder = new AllRounder(name, age, battingStyle, bowlingStyle,
                                                         matches, runs, wickets, centuries, fiveWicketHauls);
                    stats = $"Batting Average: {allRounder.CalculateBattingAverage():F2}\n";
                    stats += $"Bowling Average: {allRounder.CalculateBowlingAverage():F2}\n";
                    stats += $"All-rounder Index: {allRounder.CalculateAllRounderIndex():F2}\n";
                    stats += $"Centuries: {centuries}\n";
                    stats += $"Five Wicket Hauls: {fiveWicketHauls}\n";
                    player = allRounder;
                    break;

                default:
                    player = new Player(id, name, age, role, battingStyle, bowlingStyle, matches, runs, wickets);
                    stats = $"Batting Average: {player.CalculateBattingAverage():F2}\n";
                    if (wickets > 0)
                    {
                        stats += $"Bowling Average: {player.CalculateBowlingAverage():F2}\n";
                    }
                    break;
            }

            // Display player info and basic stats
            lblStats.Text =
                $"Name: {player.Name}\n" +
                $"Age: {player.Age}\n" +
                $"Role: {player.Role}\n" +
                $"Batting Style: {player.BattingStyle}\n" +
                $"Bowling Style: {player.BowlingStyle}\n" +
                $"Matches: {player.Matches}\n" +
                $"Runs: {player.Runs}\n" +
                $"Wickets: {player.Wickets}\n\n" +
                stats;
        }
    }
}

