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
        private static MySqlConnection conn = new MySqlConnection("SERVER=localhost; Initial Catalog = database_medu; UID = root; Password=; convert zero datetime=True");
        private MySqlCommand cmd;
        public MySqlDataReader reader;
        private bool connectionOpen = false;
        

        public void openConnection()
        {
            if (conn.State.ToString() != "Open")
            {
                conn.Open();
            }
        }

        public bool openConnectionR()
        {
            if (conn.State.ToString() != "Open")
            {
                try
                {
                    conn.Open();
                    connectionOpen = true;
                }
                catch (Exception)
                {
                    connectionOpen = false;
                }
            }
            return connectionOpen;
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
    }
}

