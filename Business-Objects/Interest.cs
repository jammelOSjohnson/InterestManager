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
    public class Interest
    {
        //Variables
        public int interest_id { get; set; }
        public string ins_code { get; set; }
        public decimal interest_rate { get; set; }
        public DateTime effective_date { get; set; }
        public int status_id { get; set; }

        //Constructor
        public Interest() { }

        public static MySqlConnection GetConnection()
        {
            string connString = "datasource=localhost;port=3306;username=root;password=12345678;database=interestmanagerdb";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }catch(Exception ex)
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conn;
        }

        public static void AddInterest(Interest interest)
        {
            //Configure Query
            string query = "INSERT INTO interests VALUES(@interest_id, @ins_code, @interest_rate, @effective_date, @status_id)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@interest_id", MySqlDbType.Int32).Value = interest.interest_id;
            cmd.Parameters.Add("@ins_code", MySqlDbType.Int32).Value = interest.ins_code;
            cmd.Parameters.Add("@interest_rate", MySqlDbType.Int32).Value = interest.interest_rate;
            cmd.Parameters.Add("@effective_date", MySqlDbType.Int32).Value = interest.effective_date;
            cmd.Parameters.Add("@status_id", MySqlDbType.Int32).Value = interest.status_id;

            try
            {
                //Run Query and show result
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                //If query failed
                MessageBox.Show("Interest not inserted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Close connection
            conn.Close();
        }

        public static void UpdateInterest(Interest interest, int interest_ID)
        {
            //Configure Query
            string query = "UPDATE interests SET ins_code = @ins_code, " +
                "interest_rate = @interest_rate, " +
                "effective_date = @effective_date, status_id = @status_id" +
                "WHERE interest_id = @interest_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@interest_id", MySqlDbType.Int32).Value = interest_ID;
            cmd.Parameters.Add("@ins_code", MySqlDbType.Int32).Value = interest.ins_code;
            cmd.Parameters.Add("@interest_rate", MySqlDbType.Int32).Value = interest.interest_rate;
            cmd.Parameters.Add("@effective_date", MySqlDbType.Int32).Value = interest.effective_date;
            cmd.Parameters.Add("@status_id", MySqlDbType.Int32).Value = interest.status_id;

            try
            {
                //Run Query and show result
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                //If query failed
                MessageBox.Show("Interest not updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Close connection
            conn.Close();
        }

        public static void DeleteInterest(int interest_ID)
        {
            string query = "DELETE FROM interests WHERE interest_id = @interest_id";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@interest_id", MySqlDbType.Int32).Value = interest_ID;

            try
            {
                //Run Query and show result
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                //If query failed
                MessageBox.Show("Interest not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Close connection
            conn.Close();
        }

        public static void DisplayAndFindInterests(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dTbl = new DataTable();
            adp.Fill(dTbl);
            conn.Close();
        }

    }
}
