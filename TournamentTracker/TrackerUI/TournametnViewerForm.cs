using System.ComponentModel;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournametnViewerForm : Form
    {
        private TournamentModel model;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();


        public TournametnViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            model = tournamentModel;

            model.OnTournamentComplete += Model_OnTournamentComplete;

            WireUpLists();

            SetUpForm();

        }

        private void Model_OnTournamentComplete(object? sender, DateTime e)
        {
            this.Close();
        }

        private void SetUpForm()
        {
            tournamentlabel.Text = model.TournamentName;
            LoadRounds();
        }
        private void WireUpLists()
        {
            roundcomboBox.DataSource = rounds;
            matchuplistBox.DataSource = selectedMatchups;
            matchuplistBox.DisplayMember = "DisplayName";
        }
        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int cuurRound = 1;

            foreach (List<MatchupModel> matchups in model.Rounds)
            {
                if (matchups.First().MatchupRound > cuurRound)
                {
                    cuurRound = matchups.First().MatchupRound;
                    rounds.Add(cuurRound);
                }
            }
            LoadMatchUps(1);
        }

        private void roundcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchUps((int)roundcomboBox.SelectedItem);
        }
        private void LoadMatchUps(int round)
        {
            foreach (List<MatchupModel> matchups in model.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedonlycheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }
            if (selectedMatchups.Count > 0)
            {
                LoadMatchUp(selectedMatchups.First()); 
            }
            DisplayMatchupInfo();
        }
        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamonelabel.Visible = isVisible;
            label3.Visible = isVisible;
            teamonescoretextBox.Visible = isVisible;

            teamtwolabel.Visible = isVisible;
            label4.Visible = isVisible;
            teamtwoscoretextBox.Visible = isVisible;

            label5.Visible = isVisible;

            scorebutton.Visible = isVisible;
        }
        private void LoadMatchUp(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamonelabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamonescoretextBox.Text = m.Entries[0].Score.ToString();

                        teamtwolabel.Text = "<bye>";
                        teamtwoscoretextBox.Text = "0";
                    }
                    else
                    {
                        teamonelabel.Text = "Not Yet Set";
                        teamonescoretextBox.Text = "";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamtwolabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamtwoscoretextBox.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamtwolabel.Text = "Not Yet Set";
                        teamtwoscoretextBox.Text = "";
                    }
                }
            }
        }
        private void matchuplistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchuplistBox.SelectedIndex != -1)
            {
                LoadMatchUp((MatchupModel)matchuplistBox.SelectedItem);
            }
        }
        private void unplayedonlycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchUps((int)roundcomboBox.SelectedItem);
        }
        private string ValidateData()
        {
            string output = "";

            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(teamonescoretextBox.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamtwoscoretextBox.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The score One value is not a valid number.";
            }
            else if (!scoreTwoValid)
            {
                output = "The score Two value is not a valid number.";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You did not enter a score for either team.";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties in this application.";
            }

            return output;
        }
        private void scorebutton_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateData();

            if (errorMessage.Length > 0)
            {
                MessageBox.Show($"Input Error: {errorMessage}");
                return;
            }

            MatchupModel m = (MatchupModel)matchuplistBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamonescoretextBox.Text, out teamOneScore);

                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1.");
                            return;
                        }
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamtwoscoretextBox.Text, out teamTwoScore);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2.");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"This application have following errors : {ex.Message}");
                return;
            }

            LoadMatchUps((int)roundcomboBox.SelectedItem);   
        }
    }
}