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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {

        IPrizeRequester calling;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();
            calling = caller;
        }

        private void createPrizebutton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel prize = new PrizeModel(
                    placenametextBox.Text,
                    placenumbertextBox.Text,
                    placeamounttextBox.Text,
                    prizepercantagetextBox.Text);

                GlobalConfig.Connections.CreatePrize(prize);

                calling.PrizeComplete(prize);

                this.Close();

            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            bool placeNumberValidNumber = int.TryParse(placenumbertextBox.Text, out int placeNumber);

            if (placeNumberValidNumber == false)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placenametextBox.Text.Length == 0)
            {
                output = false;
            }

            bool prizeAmountValid = decimal.TryParse(placeamounttextBox.Text, out decimal prizeAmount);
            bool prizePercentageValid = int.TryParse(prizepercantagetextBox.Text, out int prizePercentage);

            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
