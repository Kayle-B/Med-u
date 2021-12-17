using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Design_test
{
    internal class Doctor
    {
        private MySqlConnection conn { get; }
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        private int id { get; }
        private string name { get; }
        private string lastname { get; }
        private string email { get; }
        private List<Patient> patients;
        public List<Patient> Patients { get { return patients; } }


        private void addPatient(string name, string lastname, int age)
        {
            this.patients.Add(new Patient(name, lastname, age));
        }

/*        public override string ToString()
        {
            return base.ToString();
        }
*/
        public Doctor(MySqlConnection conn, int id, string name, string lastname, string email)
        {
            this.conn = conn;
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.email = email;
        }

        /*  public string getFullName()
            {
                return name + " " + lastname; 
            }*/


        public Doctor getPatientForDoctor()
        {
            if (this.patients == null)
            {
                this.patients = new List<Patient>();
            }
            string query = string.Format("SELECT * FROM patient WHERE doctor_id = {0}", this.id);
            cmd = new MySqlCommand(query, this.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.addPatient(reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            reader.Close();
            return this;
        }
    }
}
