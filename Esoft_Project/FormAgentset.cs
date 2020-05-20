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
    public partial class FormAgentset : Form
    {
        public FormAgentset()
        {
            InitializeComponent();
            ShowAgent();
        }

        void ShowAgent()
        {
            listViewAgent.Items.Clear();
            foreach (Agentset agentset in Program.wftDb.Agentset)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    agentset.id.ToString(), agentset.FirstName,
                    agentset.MiddleName, agentset.LastName,
                    agentset.DealShare.ToString()
                });
                item.Tag = agentset;
                listViewAgent.Items.Add(item);
            }
            listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Agentset agentset = new Agentset();
                agentset.FirstName = textBoxFirstName.Text;
                agentset.MiddleName = textBoxMiddleName.Text;
                agentset.LastName = textBoxLastName.Text;
                if (textBoxDealShare.Text != "")
                {
                    agentset.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                }

                if (agentset.FirstName == "" || agentset.MiddleName == "" || agentset.LastName == "")
                {
                    throw new Exception("Заполните поля 'ФАМИЛИЯ', 'ИМЯ', 'ОТЧЕСТВО'!");
                }

                if (agentset.DealShare < 0 || agentset.DealShare > 100)
                {
                    throw new Exception("Доля от комиссии может принимать значение от 0 до 100");
                }
                Program.wftDb.Agentset.Add(agentset);
                Program.wftDb.SaveChanges();
                ShowAgent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {

            if (listViewAgent.SelectedItems.Count == 1)
            {
                try
                {

                    Agentset agentset = listViewAgent.SelectedItems[0].Tag as Agentset;
                    agentset.FirstName = textBoxFirstName.Text;
                    agentset.MiddleName = textBoxMiddleName.Text;
                    agentset.LastName = textBoxLastName.Text;
                    if (textBoxDealShare.Text != "")
                    {
                        agentset.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                    }
                    else agentset.DealShare = null;
                    if (agentset.DealShare < 0 || agentset.DealShare > 100)
                    {
                        throw new Exception("Доля от комиссии может принимать значение от 0 до 100");
                    }
                    if (agentset.FirstName == "" || agentset.MiddleName == "" || agentset.LastName == "")
                    {
                        throw new Exception("Заполните поля 'ФАМИЛИЯ', 'ИМЯ', 'ОТЧЕСТВО'!");
                    }
                    Program.wftDb.SaveChanges();
                    ShowAgent();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    Agentset agentset = listViewAgent.SelectedItems[0].Tag as Agentset;
                    Program.wftDb.Agentset.Remove(agentset);
                    Program.wftDb.SaveChanges();
                    ShowAgent();
                }

                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                Agentset agentset = listViewAgent.SelectedItems[0].Tag as Agentset;
                textBoxFirstName.Text = agentset.FirstName;
                textBoxMiddleName.Text = agentset.MiddleName;
                textBoxLastName.Text = agentset.LastName;
                textBoxDealShare.Text = agentset.DealShare.ToString();
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }
    }
}
