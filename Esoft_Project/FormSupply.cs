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
    public partial class FormSupply : Form
    {
        public FormSupply()
        {
            InitializeComponent();
            ShowAgents();
            ShowClients();
            ShowRealEatate();
            ShowSupplySet();
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (Agentset agentset in Program.wftDb.Agentset)
            {
                string[] item = {agentset.id.ToString() + ".", agentset.FirstName.Remove(1) + ".",
                agentset.MiddleName.Remove(1) + ".", agentset.LastName, agentset.DealShare.ToString() + "%"};
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }

        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                string[] item = {clientsSet.id.ToString() + ".", clientsSet.FirstName.Remove(1) + ".",
                clientsSet.MiddleName.Remove(1) + ".", clientsSet.LastName};
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        void ShowRealEatate()
        {
            comboBoxRealEstate.Items.Clear();
            foreach (RealEstateSet realEstateSet in Program.wftDb.RealEstateSet)
            {
                string[] item = { realEstateSet.id.ToString() + ".",  realEstateSet.Address_City + ", ",
                realEstateSet.Address_Street + ", ", "д." + realEstateSet.Address_House + ", ", "кв."
                + realEstateSet.Address_Number, " " + realEstateSet.TotalArea.ToString() + "кв/м" };
                comboBoxRealEstate.Items.Add(string.Join(" ", item));
            }
        }

        void ShowSupplySet()
        {
            listViewSupplySet.Items.Clear();
            foreach (SupplySet supply in Program.wftDb.SupplySet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    supply.idAgent.ToString(),
                    supply.Agentset.LastName + " " + supply.Agentset.FirstName.Remove(1) + "." 
                    + supply.Agentset.MiddleName.Remove(1) + ".",
                    supply.idClient.ToString(),
                    supply.ClientsSet.LastName + " " + supply.ClientsSet.FirstName .Remove(1) + "."
                    + supply.ClientsSet.MiddleName,
                    supply.idRealEstate.ToString(),
                    "г. " + supply.RealEstateSet.Address_City + ", ул. " + 
                    supply.RealEstateSet.Address_Street + ", д. " + supply.RealEstateSet.Address_House
                    + ", кв. " + supply.RealEstateSet.Address_Number,
                    supply.Price.ToString()
                });
                item.Tag = supply;
                listViewSupplySet.Items.Add(item);
            }
        }

        private void LabelRealEstate_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null
                && comboBoxRealEstate.SelectedItem != null && textBoxPrice.Text != "") 
            {
                    SupplySet supply = new SupplySet();
                    supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                    supply.Price = Convert.ToInt64(textBoxPrice.Text);
                    Program.wftDb.SupplySet.Add(supply);
                    Program.wftDb.SaveChanges();
                    ShowSupplySet();
            }
            else  MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                try
                {
                    if (comboBoxAgents.Text == "" || comboBoxClients.Text == "" || comboBoxRealEstate.Text == ""
                        || textBoxPrice.Text == "")
                    {
                        throw new Exception("Заполните все поля!");
                    }

                    SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                    supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                    supply.Price = Convert.ToInt64(textBoxPrice.Text);
                    Program.wftDb.SaveChanges();
                    ShowSupplySet();
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSupplySet.SelectedItems.Count == 1)
                {
                    SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                    Program.wftDb.SupplySet.Remove(supply);
                    Program.wftDb.SaveChanges();
                    ShowSupplySet();
                }

                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewSupplySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(supply.idAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(supply.idClient.ToString());
                comboBoxRealEstate.SelectedIndex = comboBoxRealEstate.FindString(supply.idRealEstate.ToString());
                textBoxPrice.Text = supply.Price.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";

            }
        }
    }
}
    