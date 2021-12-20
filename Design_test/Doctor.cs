using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Design_test
{
    public class Doctor
    {
/*        private MySqlConnection conn { get; }
        private MySqlCommand cmd;
        private MySqlDataReader reader;*/
        public SQLServer sQLServer = new SQLServer();

        private int id { get; }
        private string name { get; }
        private string lastname { get; }
        private string email { get; }
        private List<Patient> patients;
        public List<Patient> Patients { get { return patients; } }


        public void addPatient(string name, string lastname, int age)
        {
            this.patients.Add(new Patient(name, lastname, age));
        }

        public Doctor(int id, string name, string lastname, string email)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.email = email;
        }

        public Doctor getPatientForDoctor()
        {
            if (this.patients == null)
            {
                this.patients = new List<Patient>();
            }
            else
            {
                this.patients.Clear();
            }
            string query = string.Format("SELECT * FROM patient WHERE doctor_id = {0}", this.id);

            //Opens reader
            MySqlDataReader reader = sQLServer.executeQeury(query);

            while (reader.Read())
            {
                this.addPatient(reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            reader.Close();
            return this;
        }
    }
}
