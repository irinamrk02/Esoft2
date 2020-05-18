﻿using System;
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
    public partial class FormDemandSet : Form
    {
        public FormDemandSet()
        {
            InitializeComponent();
            ShowAgents();
            ShowClients();
            comboBoxRealEstate.SelectedIndex = 0;
            ShowDemandSet();
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (Agentset agentset in Program.wftDb.Agentset)
            {
                string[] item = {agentset.id.ToString() + ".", agentset.FirstName,
                agentset.MiddleName, agentset.LastName, agentset.DealShare.ToString() + "%"};
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }

        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                string[] item = {clientsSet.id.ToString() + ".", clientsSet.FirstName,
                clientsSet.MiddleName, clientsSet.LastName};
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        void ShowDemandSet()
        {
            listViewApartment.Items.Clear();
            listViewHouse.Items.Clear();
            listViewLand.Items.Clear();

            foreach (DemandSet demand in Program.wftDb.DemandSet)
            {
                if (demand.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.idAgent.ToString(),
                        demand.Agentset.LastName + " " + demand.Agentset.FirstName +
                        " " + demand.Agentset.MiddleName,
                        demand.idClient.ToString(),
                        demand.ClientsSet.LastName + " " + demand.ClientsSet.FirstName +
                        " " + demand.ClientsSet.MiddleName,demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(),
                        demand.MaxArea.ToString(), demand.MinRooms.ToString(), demand.MaxRooms.ToString(),
                        demand.MinFloor.ToString(), demand.MaxFloor.ToString()
                    });
                    item.Tag = demand;
                    listViewApartment.Items.Add(item);
                }
                else if (demand.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.idAgent.ToString(),
                        demand.Agentset.LastName + " " + demand.Agentset.FirstName +
                        " " + demand.Agentset.MiddleName,
                        demand.idClient.ToString(),
                        demand.ClientsSet.LastName + " " + demand.ClientsSet.FirstName +
                        " " + demand.ClientsSet.MiddleName,
                        demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(),
                        demand.MaxArea.ToString(), demand.MinFloors.ToString(), demand.MaxFloors.ToString()
                    });
                    item.Tag = demand;
                    listViewHouse.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demand.idAgent.ToString(),
                        demand.Agentset.LastName + " " + demand.Agentset.FirstName +
                        " " + demand.Agentset.MiddleName,
                        demand.idClient.ToString(),
                        demand.ClientsSet.LastName + " " + demand.ClientsSet.FirstName +
                        " " + demand.ClientsSet.MiddleName,
                        demand.MinPrice.ToString(), demand.MaxPrice.ToString(), demand.MinArea.ToString(),
                        demand.MaxArea.ToString()
                    });
                    item.Tag = demand;
                    listViewLand.Items.Add(item);
                }
                listViewApartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewHouse.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewLand.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxRealEstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRealEstate.SelectedIndex == 0)
            {
                //квартира
                listViewApartment.Visible = true;
                labelMinRooms.Visible = true;
                textBoxMinRooms.Visible = true;
                labelMaxRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                labelMinFloor.Visible = true;
                textBoxMinFloor.Visible = true;
                labelMaxFloor.Visible = true;
                textBoxMaxFloor.Visible = true;

                listViewHouse.Visible = false;
                listViewLand.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }

            //Дом
            else if (comboBoxRealEstate.SelectedIndex == 1)
            {
                listViewHouse.Visible = true;
                labelMinFloors.Visible = true;
                textBoxMinFloors.Visible = true;
                labelMaxFloors.Visible = true;
                textBoxMaxFloors.Visible = true;

                listViewApartment.Visible = false;
                listViewLand.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;

                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }

            //Земля
            else if (comboBoxRealEstate.SelectedIndex == 2)
            {
                listViewLand.Visible = true;

                listViewApartment.Visible = false;
                listViewHouse.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void ListViewLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLand.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewLand.SelectedItems[0].Tag as DemandSet;

                comboBoxAgents.SelectedItem = comboBoxAgents.FindString(demand.idAgent.ToString());
                comboBoxClients.SelectedItem = comboBoxClients.FindString(demand.idClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void ListViewHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewHouse.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewHouse.SelectedItems[0].Tag as DemandSet;

                comboBoxAgents.SelectedItem = comboBoxAgents.FindString(demand.idAgent.ToString());
                comboBoxClients.SelectedItem = comboBoxClients.FindString(demand.idClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinFloors.Text = demand.MinFloors.ToString();
                textBoxMaxFloors.Text = demand.MaxFloors.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
        }

        private void ListViewApartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewApartment.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewApartment.SelectedItems[0].Tag as DemandSet;

                comboBoxAgents.SelectedItem = comboBoxAgents.FindString(demand.idAgent.ToString());
                comboBoxClients.SelectedItem = comboBoxClients.FindString(demand.idClient.ToString());
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                textBoxMinArea.Text = demand.MinArea.ToString();
                textBoxMaxArea.Text = demand.MaxArea.ToString();
                textBoxMinRooms.Text = demand.MinRooms.ToString();
                textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                textBoxMinFloor.Text = demand.MinFloor.ToString();
                textBoxMaxFloor.Text = demand.MaxFloor.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null)
            {
                DemandSet demand = new DemandSet();
                demand.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demand.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                if (textBoxMinPrice.Text == "")
                {
                    textBoxMinPrice.Text = demand.MinPrice.ToString();
                }
                else
                {
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                }
                if (textBoxMaxPrice.Text == "")
                {
                    textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                }
                else
                {
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                }
                if (textBoxMinArea.Text == "")
                {
                    textBoxMinArea.Text = demand.MinArea.ToString();
                }
                else
                {
                    demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                }
                if (textBoxMaxArea.Text == "")
                {
                    textBoxMaxArea.Text = demand.MaxArea.ToString();
                }
                else
                {
                    demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                }
                

                if (comboBoxRealEstate.SelectedIndex == 0)
                {
                    demand.Type = 0;
                    if (textBoxMinRooms.Text == "")
                    {
                        textBoxMinRooms.Text = demand.MinRooms.ToString();
                    }
                    else
                    {
                        demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                    }
                    if (textBoxMaxRooms.Text == "")
                    {
                        textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                    }
                    else
                    {
                        demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                    }
                    if (textBoxMinFloor.Text == "")
                    {
                        textBoxMinFloor.Text = demand.MinFloor.ToString();
                    }
                    else
                    {
                        demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    }
                    if (textBoxMaxFloor.Text == "")
                    {
                        textBoxMaxFloor.Text = demand.MaxFloor.ToString();
                    }
                    else
                    {
                        demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                    }
                }

                else if (comboBoxRealEstate.SelectedIndex == 1)
                {
                    demand.Type = 1;

                    if (textBoxMinFloors.Text == "")
                    {
                        textBoxMinFloors.Text = demand.MinFloors.ToString();
                    }
                    else
                    {
                        demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                    }
                    if (textBoxMaxFloors.Text == "")
                    {
                        textBoxMaxFloors.Text = demand.MaxFloors.ToString();
                    }
                    else
                    {
                        demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                    }
                }

                else
                {
                    demand.Type = 2;
                }
                Program.wftDb.DemandSet.Add(demand);
                Program.wftDb.SaveChanges();
                ShowDemandSet();
            }
            else MessageBox.Show("Выберете РИЕЛТОРА и КЛИЕНТА", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxRealEstate.SelectedIndex == 0)
            {
                if (listViewApartment.SelectedItems.Count == 1)
                {
                    try
                    {
                        DemandSet demand = listViewApartment.SelectedItems[0].Tag as DemandSet;
                        demand.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        demand.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        if (textBoxMinPrice.Text == "")
                        {
                            textBoxMinPrice.Text = demand.MinPrice.ToString();
                        }
                        else
                        {
                            demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                        }
                        if (textBoxMaxPrice.Text == "")
                        {
                            textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                        }
                        else
                        {
                            demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                        }
                        if (textBoxMinArea.Text == "")
                        {
                            textBoxMinArea.Text = demand.MinArea.ToString();
                        }
                        else
                        {
                            demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                        }
                        if (textBoxMaxArea.Text == "")
                        {
                            textBoxMaxArea.Text = demand.MaxArea.ToString();
                        }
                        else
                        {
                            demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                        }
                        if (textBoxMinRooms.Text == "")
                        {
                            textBoxMinRooms.Text = demand.MinRooms.ToString();
                        }
                        else
                        {
                            demand.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                        }
                        if (textBoxMaxRooms.Text == "")
                        {
                            textBoxMaxRooms.Text = demand.MaxRooms.ToString();
                        }
                        else
                        {
                            demand.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                        }
                        if (textBoxMinFloor.Text == "")
                        {
                            textBoxMinFloor.Text = demand.MinFloor.ToString();
                        }
                        else
                        {
                            demand.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                        }
                        if (textBoxMaxFloor.Text == "")
                        {
                            textBoxMaxFloor.Text = demand.MaxFloor.ToString();
                        }
                        else
                        {
                            demand.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                        }

                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else if (comboBoxRealEstate.SelectedIndex == 1)
            {
                if (listViewHouse.SelectedItems.Count == 1)
                {
                    try
                    {
                        DemandSet demand = listViewHouse.SelectedItems[0].Tag as DemandSet;
                        demand.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        demand.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        if (textBoxMinPrice.Text == "")
                        {
                            textBoxMinPrice.Text = demand.MinPrice.ToString();
                        }
                        else
                        {
                            demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                        }
                        if (textBoxMaxPrice.Text == "")
                        {
                            textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                        }
                        else
                        {
                            demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                        }
                        if (textBoxMinArea.Text == "")
                        {
                            textBoxMinArea.Text = demand.MinArea.ToString();
                        }
                        else
                        {
                            demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                        }
                        if (textBoxMaxArea.Text == "")
                        {
                            textBoxMaxArea.Text = demand.MaxArea.ToString();
                        }
                        else
                        {
                            demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                        }
                        if (textBoxMinFloors.Text == "")
                        {
                            textBoxMinFloors.Text = demand.MinFloors.ToString();
                        }
                        else
                        {
                            demand.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                        }
                        if (textBoxMaxFloors.Text == "")
                        {
                            textBoxMaxFloors.Text = demand.MaxFloors.ToString();
                        }
                        else
                        {
                            demand.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                        }

                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

            else
            {
                if (listViewLand.SelectedItems.Count == 1)
                {
                    try
                    {
                        DemandSet demand = listViewLand.SelectedItems[0].Tag as DemandSet;
                        demand.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        demand.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        if (textBoxMinPrice.Text == "")
                        {
                            textBoxMinPrice.Text = demand.MinPrice.ToString();
                        }
                        else
                        {
                            demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                        }
                        if (textBoxMaxPrice.Text == "")
                        {
                            textBoxMaxPrice.Text = demand.MaxPrice.ToString();
                        }
                        else
                        {
                            demand.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                        }
                        if (textBoxMinArea.Text == "")
                        {
                            textBoxMinArea.Text = demand.MinArea.ToString();
                        }
                        else
                        {
                            demand.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                        }
                        if (textBoxMaxArea.Text == "")
                        {
                            textBoxMaxArea.Text = demand.MaxArea.ToString();
                        }
                        else
                        {
                            demand.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                        }

                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRealEstate.SelectedIndex == 0)
                {
                    if (listViewApartment.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewApartment.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }

                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";
                }

                else if (comboBoxRealEstate.SelectedIndex == 1)
                {
                    if (listViewHouse.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewHouse.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }

                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinFloors.Text = "";
                    textBoxMaxFloors.Text = "";
                }

                else
                {
                    if (listViewLand.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewLand.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demand);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }

                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
