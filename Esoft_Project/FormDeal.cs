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
    public partial class FormDeal : Form
    {
        public FormDeal()
        {
            InitializeComponent();
            ShowSupply();
            ShowDemand();
            ShowDealSet();
        }

        void ShowSupply()
        {
            comboBoxSupply.Items.Clear();
            foreach (SupplySet supplySet in Program.wftDb.SupplySet)
            {
                string[] item = {supplySet.id.ToString() + ". ", "Риелтор: " + supplySet.Agentset.LastName,
                supplySet.Agentset.FirstName.Remove(1) + ".", supplySet.Agentset.MiddleName.Remove(1) + ".",
                " Клиент: " + supplySet.ClientsSet.LastName, supplySet.ClientsSet.FirstName.Remove(1) + ".",
                supplySet.ClientsSet.MiddleName.Remove(1) + "."};
                comboBoxSupply.Items.Add(string.Join(" ", item));
            }
        }

        void ShowDemand()
        {
            comboBoxDemand.Items.Clear();
            foreach (DemandSet demandSet in Program.wftDb.DemandSet)
            {
                string[] item = {demandSet.id.ToString() + ". ", "Риелтор: " + demandSet.Agentset.LastName,
                demandSet.Agentset.FirstName.Remove(1) + ".", demandSet.Agentset.MiddleName.Remove(1) + ".",
                "Клиент: " + demandSet.ClientsSet.LastName, demandSet.ClientsSet.FirstName.Remove(1) + ".",
                demandSet.ClientsSet.MiddleName.Remove(1) + "."};
                comboBoxDemand.Items.Add(string.Join(" ", item));
            }
        }

        private void ComboBoxSupply_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        private void ComboBoxDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        void Deductions()
        {
            if (comboBoxSupply.SelectedItem != null && comboBoxDemand.SelectedItem != null)
            {
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                DemandSet demandSet = Program.wftDb.DemandSet.Find(Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]));

                double customerCompanyDeductions = Convert.ToDouble(supplySet.Price * 0.03);
                textCustomerCompanyDeductions.Text = customerCompanyDeductions.ToString("0.00");

                if (demandSet.Agentset.DealShare != null)
                {
                    double agentCustomerDedutions = customerCompanyDeductions * Convert.ToDouble(demandSet.Agentset.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDedutions.ToString("0.00");
                }
                else
                {
                    double agentCustomerDedutions = customerCompanyDeductions * 0.45;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDedutions.ToString("0.00");
                }
            }
            else
            {
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
            }

            if (comboBoxSupply.SelectedItem != null)
            {
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));

                double sellerCompanyDeductions;
                if (supplySet.RealEstateSet.Type == 0)
                {
                    sellerCompanyDeductions = Convert.ToDouble(36000 + supplySet.Price * 0.01);
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else if (supplySet.RealEstateSet.Type == 1)
                {
                    sellerCompanyDeductions = Convert.ToDouble(36000 + supplySet.Price * 0.01);
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else
                {
                    sellerCompanyDeductions = Convert.ToDouble(36000 + supplySet.Price * 0.01);
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }

                if (supplySet.Agentset.DealShare != null)
                {
                    double agentSellerDeductions = sellerCompanyDeductions * Convert.ToDouble(supplySet.Agentset.DealShare) / 100.00;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
                else
                {
                    double agentSellerDeductions = sellerCompanyDeductions * 0.45;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
            }
            else
            {
                textBoxSellerCompanyDeductions.Text = "";
                textBoxAgentSellerDeductions.Text = "";
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
            }
        }

        void ShowDealSet()
        {
            listViewDealSet.Items.Clear();
            foreach (DealSet deal in Program.wftDb.DealSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    deal.SupplySet.ClientsSet.LastName + " " + deal.SupplySet.ClientsSet.FirstName.Remove(1) + "." + 
                    deal.SupplySet.ClientsSet.MiddleName.Remove(1) + ".",
                    deal.SupplySet.Agentset.LastName + " " + deal.SupplySet.Agentset.FirstName.Remove(1) + "." +
                    deal.SupplySet.Agentset.MiddleName.Remove(1) + ".",
                    deal.DemandSet.ClientsSet.LastName + " " + deal.DemandSet.ClientsSet.FirstName.Remove(1) + "." +
                    deal.DemandSet.ClientsSet.MiddleName.Remove(1) + ".",
                    deal.DemandSet.Agentset.LastName + " " + deal.DemandSet.Agentset.FirstName.Remove(1) + "." +
                    deal.DemandSet.Agentset.MiddleName.Remove(1) + ".",
                    "г." +  deal.SupplySet.RealEstateSet.Address_City + ", ул." + deal.SupplySet.RealEstateSet.Address_Street +
                    ", д." + deal.SupplySet.RealEstateSet.Address_House + ", кв." + deal.SupplySet.RealEstateSet.Address_Number,
                    deal.SupplySet.Price.ToString()
                });
                item.Tag = deal;
                listViewDealSet.Items.Add(item);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDemand.SelectedItem != null && comboBoxSupply.SelectedItem != null)
            {
                DealSet deal = new DealSet();
                deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.DealSet.Add(deal);
                Program.wftDb.SaveChanges();
                ShowDealSet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDealSet.SelectedItems.Count == 1)
                {
                    DealSet deal = listViewDealSet.SelectedItems[0].Tag as DealSet;
                    deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                    deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);

                    Program.wftDb.SaveChanges();
                    ShowDealSet();
                }
            }
            catch { }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDealSet.SelectedItems.Count == 1)
                {
                    DealSet deal = listViewDealSet.SelectedItems[0].Tag as DealSet;
                    Program.wftDb.DealSet.Remove(deal);
                    Program.wftDb.SaveChanges();
                    ShowDealSet();
                }
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ListViewDealSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDealSet.SelectedItems.Count == 1)
            {
                DealSet deal = listViewDealSet.SelectedItems[0].Tag as DealSet;
                comboBoxSupply.SelectedIndex = comboBoxSupply.FindString(deal.idSupply.ToString());
                comboBoxDemand.SelectedIndex = comboBoxDemand.FindString(deal.idDemand.ToString());
            }
            else
            {
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
        }
    }
}
