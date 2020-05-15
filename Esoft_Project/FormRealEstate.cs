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
    public partial class FormRealEstate : Form
    {
        public FormRealEstate()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            ShowRealEstateSet();
        }

        void ShowRealEstateSet()
        {
            listViewRealEstateSet_Apartment.Items.Clear();
            listViewRealEstateSet_House.Items.Clear();
            listViewRealEstateSet_Land.Items.Clear();

            foreach (RealEstateSet realEstate in Program.wftDb.RealEstateSet)
            {
                if (realEstate.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House,
                        realEstate.Address_Number, realEstate.Coordinate_Iatitude.ToString(),
                        realEstate.Coordinate_Iongitude.ToString(), realEstate.TotalArea.ToString(),
                        realEstate.Rooms.ToString(), realEstate.Floor.ToString()
                    });

                    item.Tag = realEstate;
                    listViewRealEstateSet_Apartment.Items.Add(item);
                }

                else if (realEstate.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House,
                        realEstate.Address_Number, realEstate.Coordinate_Iatitude.ToString(),
                        realEstate.Coordinate_Iongitude.ToString(), realEstate.TotalArea.ToString(),
                        realEstate.Rooms.ToString(), realEstate.Floor.ToString()
                    });

                    item.Tag = realEstate;
                    listViewRealEstateSet_House.Items.Add(item);
                }
            }
            listViewRealEstateSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRealEstateSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRealEstateSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Квартира (индекс 0)
            if (comboBoxType.SelectedIndex == 0)
            {
                //видимые
                listViewRealEstateSet_Apartment.Visible = true;
                labelFloor.Visible = true;
                textBoxFloor.Visible = true;
                labelRooms.Visible = true;
                textBoxRooms.Visible = true;

                //скрытые
                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Land.Visible = false;
                labelTotalFloors.Visible = false;
                textBoxTotalFloors.Visible = false;

                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }

            //Дом (1)
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewRealEstateSet_House.Visible = true;
                labelTotalFloors.Visible = true;
                textBoxTotalFloors.Visible = true;

                listViewRealEstateSet_Land.Visible = false;
                listViewRealEstateSet_Apartment.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;

                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxTotalFloors.Text = "";
            }

            //Земля (2)
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewRealEstateSet_Land.Visible = true;

                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Apartment.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;
                labelTotalFloors.Visible = false;
                textBoxTotalFloors.Visible = false;

                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
            }
        }

        private void ListViewRealEstateSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Number;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            RealEstateSet realEstate = new RealEstateSet();

            realEstate.Address_City = textBoxAddress_City.Text;
            realEstate.Address_House = textBoxAddress_House.Text;
            realEstate.Address_Street = textBoxAddress_Street.Text;
            realEstate.Address_Number = textBoxAddress_Number.Text;
            realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
            realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);

            //доп. поля для квартиры
            if (comboBoxType.SelectedIndex == 0)
            {
                realEstate.Type = 0;
                realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
            }

            //доп. поля для дома
            else if (comboBoxType.SelectedIndex == 1)
            {
                realEstate.Type = 1;
                realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);
            }

            //доп. поля для земли
            else
            {
                realEstate.Type = 2;
            }
            Program.wftDb.RealEstateSet.Add(realEstate);
            Program.wftDb.SaveChanges();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                    realEstate.Address_City = textBoxAddress_City.Text;
                    realEstate.Address_House = textBoxAddress_House.Text;
                    realEstate.Address_Street = textBoxAddress_Street.Text;
                    realEstate.Address_Number = textBoxAddress_Number.Text;
                    realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);

                    Program.wftDb.SaveChanges();
                    ShowRealEstateSet();
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;

                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                        realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                        realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        realEstate.TotalFloors = Convert.ToInt32(textBoxFloor.Text);

                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }
                    else
                    {
                        if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
                        {
                            RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;

                            realEstate.Address_City = textBoxAddress_City.Text;
                            realEstate.Address_House = textBoxAddress_House.Text;
                            realEstate.Address_Street = textBoxAddress_Street.Text;
                            realEstate.Address_Number = textBoxAddress_Number.Text;
                            realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                            realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                            
                            Program.wftDb.SaveChanges();
                            ShowRealEstateSet();
                        }
                    }
                }
            }
        }

        private void ListViewRealEstateSet_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Number;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxRooms.Text = realEstate.Rooms.ToString();
                textBoxTotalFloors.Text = realEstate.TotalFloors.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }

        }

        private void ListViewRealEstateSet_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_House.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Number;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxTotalFloors.Text = realEstate.TotalFloors.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxFloor.Text = "";
            }
        }
    }
}
