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
            _playerService = new PlayerBL();
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
            string search = txtSearchName.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter... ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvPlayers.DataSource = _playerService.SearchPlayersByName(search);
            dgvPlayers.Refresh();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogue = MessageBox.Show("Are you sure you want to logout?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogue == DialogResult.Yes)
            {
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
            if (dgvPlayers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a player to view statistics", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            int centuries = 0;
            int halfCenturies = 0;
            int fours = 0;
            int sixes = 0;
            int ballsBowled = 0;
            int fiveWicketHauls = 0;

            if (row.Cells["Centuries"] != null && row.Cells["Centuries"].Value != DBNull.Value)
            {
                centuries = Convert.ToInt32(row.Cells["Centuries"].Value);
            }

            if (row.Cells["HalfCenturies"] != null && row.Cells["HalfCenturies"].Value != DBNull.Value)
            {
                halfCenturies = Convert.ToInt32(row.Cells["HalfCenturies"].Value);
            }

            if (row.Cells["Fours"] != null && row.Cells["Fours"].Value != DBNull.Value)
            {
                fours = Convert.ToInt32(row.Cells["Fours"].Value);
            }

            if (row.Cells["Sixes"] != null && row.Cells["Sixes"].Value != DBNull.Value)
            {
                sixes = Convert.ToInt32(row.Cells["Sixes"].Value);
            }

            if (row.Cells["BallsBowled"] != null && row.Cells["BallsBowled"].Value != DBNull.Value)
            {
                ballsBowled = Convert.ToInt32(row.Cells["BallsBowled"].Value);
            }

            if (row.Cells["FiveWicketHauls"] != null && row.Cells["FiveWicketHauls"].Value != DBNull.Value)
            {
                fiveWicketHauls = Convert.ToInt32(row.Cells["FiveWicketHauls"].Value);
            }

            CricketPlayer player;
            string stats = "";

            if (role == "Batsman")
            {
                Batsman batsman = new Batsman(name, age, battingStyle, matches, runs, centuries, halfCenturies, fours, sixes);
                batsman.Id = id;
                stats += "Performance Index: " + batsman.CalculatePerformanceIndex().ToString("F2") + "\n";
                stats += "Centuries: " + centuries + "\n";
                stats += "Half Centuries: " + halfCenturies + "\n";
                stats += "Fours: " + fours + "\n";
                stats += "Sixes: " + sixes + "\n";
                player = batsman;
            }
            else if (role == "Bowler")
            {
                Bowler bowler = new Bowler(name, age, bowlingStyle, matches, wickets, runs, ballsBowled, fiveWicketHauls);
                bowler.Id = id;
                stats += "Performance Index: " + bowler.CalculatePerformanceIndex().ToString("F2") + "\n";
                stats += "Balls Bowled: " + ballsBowled + "\n";
                stats += "Five Wicket Hauls: " + fiveWicketHauls + "\n";
                player = bowler;
            }
            else if (role == "All-rounder")
            {
                AllRounder allRounder = new AllRounder(
                    name, age, battingStyle, bowlingStyle, matches, runs, wickets,
                    centuries, halfCenturies, fours, sixes, ballsBowled, fiveWicketHauls);
                allRounder.Id = id;
                stats += "Performance Index: " + allRounder.CalculatePerformanceIndex().ToString("F2") + "\n";
                stats += "Centuries: " + centuries + "\n";
                stats += "Half Centuries: " + halfCenturies + "\n";
                stats += "Fours: " + fours + "\n";
                stats += "Sixes: " + sixes + "\n";
                stats += "Balls Bowled: " + ballsBowled + "\n";
                stats += "Five Wicket Hauls: " + fiveWicketHauls + "\n";
                player = allRounder;
            }
            else
            {
                Batsman defaultPlayer = new Batsman();
                defaultPlayer.Id = id;
                defaultPlayer.Name = name;
                defaultPlayer.Age = age;
                defaultPlayer.Role = role;
                defaultPlayer.BattingStyle = battingStyle;
                defaultPlayer.BowlingStyle = bowlingStyle;
                defaultPlayer.Matches = matches;
                defaultPlayer.Runs = runs;
                defaultPlayer.Wickets = wickets;
                stats += "Performance Index: " + defaultPlayer.CalculatePerformanceIndex().ToString("F2") + "\n";
                player = defaultPlayer;
            }

            lblStats.Text =
                "Name: " + player.Name + "\n" +
                "Age: " + player.Age + "\n" +
                "Role: " + player.Role + "\n" +
                "Batting Style: " + player.BattingStyle + "\n" +
                "Bowling Style: " + player.BowlingStyle + "\n" +
                "Matches: " + player.Matches + "\n" +
                "Runs: " + player.Runs + "\n" +
                "Wickets: " + player.Wickets + "\n\n" +
                stats;
        }
        

        private void grpStats_Enter(object sender, EventArgs e)
        {

        }
    }
}

