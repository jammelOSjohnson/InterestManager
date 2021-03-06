using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterestManager.Business_Objects
{
    public class InstrumentsDB
    {
        public InstrumentsDB() { }

        public static MySqlConnection GetConnection()
        {
            string connString = "datasource=localhost;port=3306;username=root;password=12345678;database=interestmanagerdb";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conn;
        }

        public static void DisplayAndFindInstruments(string query, ComboBox comboBox)
        {
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            adp.Fill(dset, "instruments");
            comboBox.DisplayMember = "description";
            comboBox.ValueMember = "ins_code";
            comboBox.DataSource = dset.Tables["instruments"];
            conn.Close();
        }
    }
}
