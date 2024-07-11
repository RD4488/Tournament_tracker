
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

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournamentModels = GlobalConfig.Connections.GetTournament_All();
        public TournamentDashboardForm()
        {
            InitializeComponent();

            InitializeList();
        }
        private void InitializeList()
        {

            loadexistingcomboBox.DataSource = tournamentModels;
            loadexistingcomboBox.DisplayMember = "TournamentName";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateTournamentForm create = new CreateTournamentForm();
            create.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadexistingcomboBox.SelectedItem;
            TournametnViewerForm form = new TournametnViewerForm(tm);
            form.Show();
        }
    }
}
