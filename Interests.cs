using InterestManager.Business_Objects;
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
    public partial class Interests : Form
    {
        public Interests()
        {
            InitializeComponent();
        }

        public void Display()
        {
            string query = "SELECT interest_id, instruments.description, effective_date, status_codes.status_name "
            +"FROM interests "
            +"JOIN instruments ON instruments.ins_code = interests.ins_code "
            +"JOIN status_codes ON interests.status_id = status_codes.status_id";
            InterestDB.DisplayAndFindInterests(query, dataGridView1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InterestForm Form = new InterestForm(this);
            Form.ShowDialog();

        }

        private void Interests_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT interest_id, instruments.description, effective_date, status_codes.status_name "
            + "FROM interests "
            + "JOIN instruments ON instruments.ins_code = interests.ins_code "
            + "JOIN status_codes ON interests.status_id = status_codes.status_id"
            + " WHERE instruments.description like '%"+ txtSearch.Text +"%'";

            InterestDB.DisplayAndFindInterests(query, dataGridView1);
        }
    }
}
