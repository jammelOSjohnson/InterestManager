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
        InterestForm form;
        public Interests()
        {
            InitializeComponent();
            form = new InterestForm(this);
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
            form.Clear();
            form.ShowDialog();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //edit
                form.Clear();
                form.id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                form.Instrument = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.PaymentDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                form.Status = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }

            if(e.ColumnIndex == 1)
            {
                //delete
                if(MessageBox.Show("Are you sure you want to delete?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes){
                    InterestDB.DeleteInterest(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    Display();
                }
                return;
            }

            if (e.ColumnIndex == 2)
            {
                //Approve
                if (MessageBox.Show("Are you sure you want to Approve?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    InterestDB.ApproveInterest(2 ,Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    Display();
                }
                return;
            }

            if (e.ColumnIndex == 3)
            {
                //Approve
                if (MessageBox.Show("Are you sure you want to Cancel?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    InterestDB.ApproveInterest(3, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    Display();
                }
                return;
            }
        }
    }
}
