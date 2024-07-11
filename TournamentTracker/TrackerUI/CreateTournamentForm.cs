
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {

        List<TeamModel> availableTeams = GlobalConfig.Connections.GetTeams_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            InitializeList();
        }

        private void InitializeList()
        {
            selectteamcomboBox.DataSource = null;
            selectteamcomboBox.DataSource = availableTeams;
            selectteamcomboBox.DisplayMember = "TeamName";

            tournamentplayerslistBox.DataSource = null;
            tournamentplayerslistBox.DataSource = selectedTeams;
            tournamentplayerslistBox.DisplayMember = "TeamName";

            prizeslistBox.DataSource = null;
            prizeslistBox.DataSource = selectedPrizes;
            prizeslistBox.DisplayMember = "PlaceName";
        }

        private void addteambutton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)selectteamcomboBox.SelectedItem;
            if (p != null)
            {
                availableTeams.Remove(p);
                selectedTeams.Add(p);

                InitializeList();
            }
        }

        private void createprizebutton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm fm = new CreatePrizeForm(this);
            fm.Show();
        }

        public void PrizeComplete(PrizeModel prize)
        {
            selectedPrizes.Add(prize);
            InitializeList();
        }

        public void TeamCompeleted(TeamModel team)
        {
            selectedTeams.Add(team);
            InitializeList();
        }

        private void createnewlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm fm = new CreateTeamForm(this);
            fm.Show();
        }

        private void tournamnetplayerdeletebutton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)tournamentplayerslistBox.SelectedItem;
            if (p != null)
            {
                selectedTeams.Remove(p);
                availableTeams.Add(p);

                InitializeList();
            }
        }

        private void prizelistdeletebutton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizeslistBox.SelectedItem;
            if (p != null)
            {
                selectedPrizes.Remove(p);
                InitializeList();
            }
        }

        private void createTournamentbutton_Click(object sender, EventArgs e)
        {
            decimal fee = 0;

            bool feeAcceptable = decimal.TryParse(entryfeetextBox.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid Entry Fee.",
                    "Invalid Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            TournamentModel tm = new TournamentModel
            {
                TournamentName = tournamentnametextBox.Text,
                EntryFee = fee,
                Prizes = selectedPrizes,
                EnteredTeams = selectedTeams
            };

            TournamentLogic.CreateRounds(tm);

            GlobalConfig.Connections.CreateTournament(tm);

            tm.AleartUsersToRound();

            TournametnViewerForm form = new TournametnViewerForm(tm);
            form.Show();

            this.Close();
        }
    }
}