using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterestManager.Business_Objects
{
    public class DbConnector
    {
        public DbConnector() { }
        public MySqlConnection GetConnection
        {
            get
            {
                return connSetup();
            }
        }

        private MySqlConnection connSetup()
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

    }
}
