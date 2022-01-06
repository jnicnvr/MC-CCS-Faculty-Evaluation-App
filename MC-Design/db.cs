using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Design
{
    class db
    {
        public MySqlConnection con = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader cmdread;
        DataSet ds = new DataSet();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        const String host = "fundamental-winches.000webhostapp.com";
        const String username = "mcfeAdmin123_";
        const String password = "id17578467_mcfe";
        const String database = "id17578467_sample";
        string conString = string.Format("server={0};uid={1};password={2};persistsecurityinfo=True;database={3};port={4};SslMode=none;", host, username, password, database, "3306");
        public void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                con.ConnectionString = conString;
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public DataTable fillDS(string query)
        {

            DataTable ds = new DataTable();
            openConnection();
            cmd = new MySqlCommand(query, con);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

    }
}
