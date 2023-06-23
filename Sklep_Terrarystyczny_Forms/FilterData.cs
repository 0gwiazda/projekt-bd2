using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Terrarystyczny_Forms
{
    public partial class FilterData : Form
    {
        public string toFilter { get; set; }
        public FilterData()
        {
            InitializeComponent();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            Form1.FilterString = toFilter + ";" + ((string)filterCombo.SelectedItem).ToLower() + ";" + ((typeCombo.Visible) ? ((filterCombo.SelectedIndex >= 2 && filterCombo.SelectedIndex <= 4) ? typeCombo.SelectedIndex : ((string)typeCombo.SelectedItem).ToLower()) : filterText.Text.ToLower());

            SuccessError success = new SuccessError();
            success.Success = true;
            success.Message = "Please press Load / Refresh to reload data.";
            success.Show();

            Close();
        }

        private void FilterData_Load(object sender, EventArgs e)
        {
            filterLabel.Text = (toFilter.Equals("Zwierzę")) ? "Filter animals" : (toFilter.Equals("Pojemnik") ? "Filter enclosures" : "Filter tools");
            typeCombo.Visible = false;
            filterCombo.Items.Clear();

            if (toFilter.Equals("Zwierzę") || toFilter.Equals("Hodowla"))
            {
                filterCombo.Items.Add("Family");
                filterCombo.Items.Add("Species");
                filterCombo.Items.Add("Type");
                filterCombo.Items.Add("Gender");
                filterCombo.Items.Add("Maturity");
                filterCombo.Items.Add("NumOfChildren");
                filterCombo.Items.Add("Danger");
                filterCombo.Items.Add("Endangered");
            }
            if (toFilter.Equals("Pojemnik"))
            {
                filterCombo.Items.Add("Type");
                filterCombo.Items.Add("Length");
                filterCombo.Items.Add("Width");
                filterCombo.Items.Add("Height");
                filterCombo.Items.Add("Decorated");
                filterCombo.Items.Add("Enviroment");
            }
            if (toFilter.Equals("Narzędzie"))
            {
                filterCombo.Items.Add("Name");
                filterCombo.Items.Add("Details");
            }
            if (toFilter.Equals("Adres"))
            {
                filterCombo.Items.Add("Address_Line_1");
                filterCombo.Items.Add("Address_Line_2");
                filterCombo.Items.Add("Code");
                filterCombo.Items.Add("City");
            }
            if (toFilter.Equals("Email"))
            {
                filterCombo.Items.Add("Email");
                filterCombo.Items.Add("Domain");
            }
        }

        private void filterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toFilter.Equals("Zwierzę") || toFilter.Equals("Hodowla"))
            {
                if ((string)filterCombo.SelectedItem == "Type")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("Spider");
                    typeCombo.Items.Add("Scorpion");
                    typeCombo.Items.Add("Solifugae");
                    typeCombo.Items.Add("Amblypygid");
                    typeCombo.Items.Add("Uropygid");
                    typeCombo.Items.Add("Tortoise");
                    typeCombo.Items.Add("Lizard");
                    typeCombo.Items.Add("Snake");
                }
                else if ((string)filterCombo.SelectedItem == "Gender")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("NS");
                    typeCombo.Items.Add("Male");
                    typeCombo.Items.Add("Female");
                }
                else if ((string)filterCombo.SelectedItem == "Maturity")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("Hatchling");
                    typeCombo.Items.Add("Juvenile");
                    typeCombo.Items.Add("Subadult");
                    typeCombo.Items.Add("Adult");
                }
                else if ((string)filterCombo.SelectedItem == "Danger")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("Safe");
                    typeCombo.Items.Add("Medium");
                    typeCombo.Items.Add("Dangerous");
                    typeCombo.Items.Add("Deadly");
                }
                else if ((string)filterCombo.SelectedItem == "Endangered")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("True");
                    typeCombo.Items.Add("False");
                }
                else
                {
                    typeCombo.Visible = false;
                    filterText.Visible = true;
                }
            }
            if (toFilter.Equals("Pojemnik"))
            {
                if ((string)filterCombo.SelectedItem == "Type")
                {
                    typeCombo.Visible = true;
                    filterText.Visible = false;

                    typeCombo.Items.Clear();
                    typeCombo.Items.Add("Terrarium");
                    typeCombo.Items.Add("Faunarium");
                    typeCombo.Items.Add("Aquarium");
                }
                else
                {
                    typeCombo.Visible = false;
                    filterText.Visible = true;
                }
            }
        }
    }
}
