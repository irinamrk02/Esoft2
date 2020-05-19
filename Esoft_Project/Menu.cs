using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ButtonOpenClients_Click(object sender, EventArgs e)
        {
            Form formClient = new FormClient();
            formClient.Show();
        }

        private void ButtonOpenRealEstates_Click(object sender, EventArgs e)
        {
            Form formRealEstate = new FormRealEstate();
            formRealEstate.Show();
        }

        private void ButtonOpenAgents_Click(object sender, EventArgs e)
        {
            Form formAgents = new FormAgentset();
            formAgents.Show();
        }

        private void ButtonOpenDemands_Click(object sender, EventArgs e)
        {
            Form formSupply = new FormSupply();
            formSupply.Show();
        }

        private void ButtonOpenSupplies_Click(object sender, EventArgs e)
        {
            Form formDemand = new FormDemandSet();
            formDemand.Show();
        }

        private void ButtonOpenDeals_Click(object sender, EventArgs e)
        {
            Form formDeal = new FormDeal();
            formDeal.Show();
        }
    }
}
