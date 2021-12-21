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

        public int id { get; }
        public string name { get; }
        public string lastname { get; }
        public string email { get; }
        private List<Patient> patients;
        public List<Patient> Patients { get { return patients; } }


        public void addPatient(Patient patient
            //int id, string username
            //, string firstname,
            //string lastname,
            //string salutation,
            //string prefix, int age,
            //string BSN,
            //string email,
            //string phone,
            //string allergies,
            //int doctor_id
            )
        {
            this.patients.Add(new Patient(id, patient.username, patient.firstname, patient.lastname, patient.salutation, patient.prefix, 20, patient.bsn, patient.email, patient.phone, patient.allergies, this.id));
        }

        public Doctor(int id, string first_name, string last_name, string email)
        {
            this.id = id;
            this.name = first_name;
            this.lastname = last_name;
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
                int prefixPos = reader.GetOrdinal("prefix");
                int salutationPos = reader.GetOrdinal("salutation");
                int phonePos = reader.GetOrdinal("phone");
                int allergiesPos = reader.GetOrdinal("allergies");

                Patient patient = new Patient(reader.GetInt16("id"),
                    reader.GetString("username"),
                    reader.GetString("first_name"),
                    reader.GetString("last_name"),
                    reader.IsDBNull(salutationPos) ? String.Empty : reader.GetString("salutation"),
                    reader.IsDBNull(prefixPos) ? String.Empty : reader.GetString("prefix"),
                    reader.GetInt16("age"),
                    reader.GetString("bsn"),
                    reader.GetString("email"),
                    reader.IsDBNull(phonePos) ? String.Empty : reader.GetString("phone"),
                    reader.IsDBNull(allergiesPos) ? String.Empty : reader.GetString("allergies"),
                    this.id);
                this.addPatient(patient);
            }
            reader.Close();
            return this;
        }
    }
}
