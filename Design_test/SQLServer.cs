using System;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_test
{
    public class SQLServer
    {
        private static MySqlConnection conn = new MySqlConnection("SERVER=localhost; Initial Catalog = pf2; UID = root; Password=");
        private MySqlCommand cmd;
        public MySqlDataReader reader;
        private int patientCount;
        public Doctor doctor;



        public void openConnection()
        {
            if (conn.State.ToString() != "Open")
            {
                conn.Open();
            }
        }

        public MySqlConnection getConnection()
        {
            return conn;
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public MySqlDataReader executeQeury(string query)
        {
            if (conn.State.ToString() == "Open")
            {
                reastablishConnection();
            }

            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            return reader;
        }

        public void reastablishConnection()
        {
            closeConnection();
            openConnection();
        }

        public Doctor loginDoctor(string username, string password)
        {
            string query = string.Format("SELECT * FROM doctor WHERE name='{0}' && password='{1}'", username, password);
            cmd = new MySqlCommand(query, conn);
            if (conn.State.ToString() == "Open")
            {
                reastablishConnection();
            }
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                doctor = new Doctor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            reader.Close();
            return doctor;
        }

    }
}

