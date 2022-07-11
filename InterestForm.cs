using InterestManager.Business_Objects;
using InterestManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterestManager
{
    public partial class InterestForm : Form
    {
        private readonly Interests _parent;
        public int id;
        public string Instrument, Status;
        public DateTime PaymentDate;

        public InterestForm(Interests parent)
        {
            InitializeComponent();
            _parent = parent;
            Display();
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Interest";
            btnSave.Text = "Update";
            menu_ins_code.SelectedItem = Instrument;
            dpeff_date.Value = PaymentDate;
        }

        public InterestForm() 
        {
            InitializeComponent();
            Display();
        }

        public void Clear()
        {
            txtins_rate.Text =  string.Empty;
            dpeff_date.Value = DateTime.Now;
        }

        public void Display()
        {
            string query = "SELECT * FROM instruments";
            InstrumentsDB.DisplayAndFindInstruments(query, menu_ins_code);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (menu_ins_code.Text.Trim().Length < 3)
            {
                MessageBox.Show("Enter Insurance Code");
                return;
            }

            if (txtins_rate.Text.Trim().Length < 1 || txtins_rate.Text.Trim() == "0")
            {
                MessageBox.Show("Enter Insurance Rate");
                return;
            }       

            if(btnSave.Text == "Save")
            {
                Interest interest = new Interest(0, menu_ins_code.SelectedValue.ToString(), Convert.ToDecimal(txtins_rate.Text.Trim()), dpeff_date.Value, 1);
                InterestDB.AddInterest(interest);
                Clear();
            }

            if(btnSave.Text == "Update")
            {
                Interest interest = new Interest(0, menu_ins_code.SelectedValue.ToString(), Convert.ToDecimal(txtins_rate.Text.Trim()), dpeff_date.Value, 1);
                InterestDB.UpdateInterest(interest, id);
            }
            _parent.Display();
        }
    }
}
