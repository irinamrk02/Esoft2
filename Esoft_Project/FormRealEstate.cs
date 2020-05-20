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
                        realEstate.TotalFloors.ToString()
                    });

                    item.Tag = realEstate;
                    listViewRealEstateSet_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House,
                        realEstate.Address_Number, realEstate.Coordinate_Iatitude.ToString(),
                        realEstate.Coordinate_Iongitude.ToString(), realEstate.TotalArea.ToString()
                    });

                    item.Tag = realEstate;
                    listViewRealEstateSet_Land.Items.Add(item);
                    
                }
                    listViewRealEstateSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    listViewRealEstateSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    listViewRealEstateSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
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
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
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
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
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
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
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
                textBoxCoordinate_Iatitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_Iongitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
                textBoxTotalArea.Text = "";
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RealEstateSet realEstate = new RealEstateSet();

                realEstate.Address_City = textBoxAddress_City.Text;
                realEstate.Address_House = textBoxAddress_House.Text;
                realEstate.Address_Street = textBoxAddress_Street.Text;
                realEstate.Address_Number = textBoxAddress_Number.Text;
                if (textBoxCoordinate_Iatitude.Text != "")
                {
                    realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_Iatitude.Text);
                }
                else realEstate.Coordinate_Iatitude = null;
                if (textBoxCoordinate_Iongitude.Text != "")
                {
                    realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_Iongitude.Text);
                }
                else realEstate.Coordinate_Iongitude = null;
                if (textBoxTotalArea.Text != "")
                {
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                }
                else realEstate.TotalArea = null;
                if (realEstate.Coordinate_Iatitude < -90 || realEstate.Coordinate_Iatitude > 90)
                {
                    throw new Exception("Широта принимает значения только от -90 до +90");
                }
                if (realEstate.Coordinate_Iongitude < -180 || realEstate.Coordinate_Iongitude > 180)
                {
                    throw new Exception("Долгота принимает значения только от -180 до +180");
                }


                //доп. поля для квартиры
                if (comboBoxType.SelectedIndex == 0)
                {
                    realEstate.Type = 0;
                    if (textBoxRooms.Text != "")
                    {
                        realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    }
                    else realEstate.Rooms = null;
                    if (textBoxFloor.Text != "")
                    {
                        realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
                    }
                    else realEstate.Floor = null;
                }

                //доп. поля для дома
                else if (comboBoxType.SelectedIndex == 1)
                {
                    realEstate.Type = 1;
                    if (textBoxTotalFloors.Text != "")
                    {
                        realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);
                    }
                    else realEstate.TotalFloors = null;
                }

                //доп. поля для земли
                else
                {
                    realEstate.Type = 2;
                }
                Program.wftDb.RealEstateSet.Add(realEstate);
                Program.wftDb.SaveChanges();
                ShowRealEstateSet();
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    try
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        if (textBoxCoordinate_Iatitude.Text != "")
                        {
                            realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_Iatitude.Text);
                        }
                        else realEstate.Coordinate_Iatitude = null;
                        if (textBoxCoordinate_Iongitude.Text != "")
                        {
                            realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_Iongitude.Text);
                        }
                        else realEstate.Coordinate_Iongitude = null;
                        if (textBoxTotalArea.Text != "")
                        {
                            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        }
                        else realEstate.TotalArea = null;
                        if (textBoxRooms.Text != "")
                        {
                            realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                        }
                        else realEstate.Rooms = null;
                        if (textBoxFloor.Text != "")
                        {
                            realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);
                        }
                        else realEstate.Floor = null;

                        if (realEstate.Coordinate_Iatitude < -90 || realEstate.Coordinate_Iatitude > 90)
                        {
                            throw new Exception("Широта принимает значения только от -90 до +90");
                        }
                        if (realEstate.Coordinate_Iongitude < -180 || realEstate.Coordinate_Iongitude > 180)
                        {
                            throw new Exception("Долгота принимает значения только от -180 до +180");
                        }

                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                {
                    try
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;

                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        if (textBoxCoordinate_Iatitude.Text != "")
                        {
                            realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_Iatitude.Text);
                        }
                        else realEstate.Coordinate_Iatitude = null;
                        if (textBoxCoordinate_Iongitude.Text != "")
                        {
                            realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_Iongitude.Text);
                        }
                        else realEstate.Coordinate_Iongitude = null;
                        if (textBoxTotalArea.Text != "")
                        {
                            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        }
                        else realEstate.TotalArea = null;
                        if (textBoxTotalFloors.Text != "")
                        {
                            realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);
                        }
                        else realEstate.TotalFloors = null;

                        if (realEstate.Coordinate_Iatitude < -90 || realEstate.Coordinate_Iatitude > 90)
                        {
                            throw new Exception("Широта принимает значения только от -90 до +90");
                        }
                        if (realEstate.Coordinate_Iongitude < -180 || realEstate.Coordinate_Iongitude > 180)
                        {
                            throw new Exception("Долгота принимает значения только от -180 до +180");
                        }

                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }    
            }
            else
            {
                if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
                {
                    try
                    { 
                        RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;

                        realEstate.Address_City = textBoxAddress_City.Text;
                        realEstate.Address_House = textBoxAddress_House.Text;
                        realEstate.Address_Street = textBoxAddress_Street.Text;
                        realEstate.Address_Number = textBoxAddress_Number.Text;
                        if (textBoxCoordinate_Iatitude.Text != "")
                        {
                            realEstate.Coordinate_Iatitude = Convert.ToDouble(textBoxCoordinate_Iatitude.Text);
                        }
                        else realEstate.Coordinate_Iatitude = null;
                        if (textBoxCoordinate_Iongitude.Text != "")
                        {
                            realEstate.Coordinate_Iongitude = Convert.ToDouble(textBoxCoordinate_Iongitude.Text);
                        }
                        else realEstate.Coordinate_Iongitude = null;
                        if (textBoxTotalArea.Text != "")
                        {
                            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                        }
                        else realEstate.TotalArea = null;

                        if (realEstate.Coordinate_Iatitude < -90 || realEstate.Coordinate_Iatitude > 90)
                        {
                            throw new Exception("Широта принимает значения только от -90 до +90");
                        }
                        if (realEstate.Coordinate_Iongitude < -180 || realEstate.Coordinate_Iongitude > 180)
                        {
                            throw new Exception("Долгота принимает значения только от -180 до +180");
                        }

                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                textBoxCoordinate_Iatitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_Iongitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxRooms.Text = realEstate.Rooms.ToString();
                textBoxFloor.Text = realEstate.Floor.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
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
                textBoxCoordinate_Iatitude.Text = realEstate.Coordinate_Iatitude.ToString();
                textBoxCoordinate_Iongitude.Text = realEstate.Coordinate_Iongitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxTotalFloors.Text = realEstate.TotalFloors.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_Iatitude.Text = "";
                textBoxCoordinate_Iongitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxFloor.Text = "";
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;
                        Program.wftDb.RealEstateSet.Remove(realEstate);
                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Iatitude.Text = "";
                    textBoxCoordinate_Iongitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxRooms.Text = "";
                    textBoxFloor.Text = "";
                }

                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;
                        Program.wftDb.RealEstateSet.Remove(realEstate);
                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Iatitude.Text = "";
                    textBoxCoordinate_Iongitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxFloor.Text = "";
                }

                else
                {
                    if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
                    {
                        RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;
                        Program.wftDb.RealEstateSet.Remove(realEstate);
                        Program.wftDb.SaveChanges();
                        ShowRealEstateSet();
                    }

                    textBoxAddress_City.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_Iatitude.Text = "";
                    textBoxCoordinate_Iongitude.Text = "";
                    textBoxTotalArea.Text = "";
                }

            }

            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxCoordinate_Iatitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45) 
            {
                e.Handled = true;
            }
        }

        private void TextBoxCoordinate_Iongitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45) 
            {
                e.Handled = true;
            }
        }

        private void TextBoxTotalArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}
