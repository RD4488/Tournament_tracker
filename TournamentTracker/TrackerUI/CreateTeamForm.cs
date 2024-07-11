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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connections.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        ITeamRequester calling;
        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            calling = caller;
            WireUpLists();
            
        }
        private void WireUpLists()
        {
            selectteamcomboBox.DataSource = null;

            selectteamcomboBox.DataSource = availableTeamMembers;
            selectteamcomboBox.DisplayMember = "FullName";

            teammemberslistBox.DataSource = null;

            teammemberslistBox.DataSource = selectedTeamMembers;
            teammemberslistBox.DisplayMember = "FullName";
        }

        private void creatememberbutton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstnametextBox.Text;
                p.LastName = lastnametextBox.Text;
                p.EmailAddress = emailtextBox.Text;
                p.CellPhoneNumber = cellphonetextBox.Text;

                GlobalConfig.Connections.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

                firstnametextBox.Text = string.Empty;
                lastnametextBox.Text = string.Empty;
                emailtextBox.Text = string.Empty;
                cellphonetextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("You need to fill in all of the fields.");
            }
        }
        private bool ValidateForm()
        {
            if (firstnametextBox.Text.Length == 0)
            {
                return false;
            }

            if (lastnametextBox.Text.Length == 0)
            {
                return false;
            }

            if (emailtextBox.Text.Length == 0)
            {
                return false;
            }

            if (cellphonetextBox.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void addteambutton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectteamcomboBox.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void tournamnetplayerdeletebutton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teammemberslistBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeambutton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
             
            t.TeamName = teamnametextBox.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connections.CreateTeam(t);

            calling.TeamCompeleted(t);

            this.Close();
        }

    }
}
