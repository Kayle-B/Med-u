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
        private MySqlDataReader reader;
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

/*        public int getPatientCount()
        {
            string query = "SELECT COUNT(*) FROM users";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                patientCount = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();

            return patientCount;
        }*/

/*        public List<Patient> getPatientList(string name)
        {
            string query = string.Format("SELECT * FROM users WHERE name='{0}'", name);
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            List<Patient> patients = new List<Patient>();

            while (reader.Read())
            {
*//*                patients.Add(new Patient(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), (int)reader.GetValue(5)));
*//*            }
            reader.Close();

            return patients;
        }*/

        public MySqlDataReader executeQeury(string query)
        {
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            return reader;
        }

        public Doctor loginDoctor(string username, string password)
        {
            string query = string.Format("SELECT * FROM doctor WHERE name='{0}' && password='{1}'", username, password);
            cmd = new MySqlCommand(query, conn);
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

