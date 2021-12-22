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
        public SQLServer sQLServer = new SQLServer();

        public int id { get; set; }
        private string username { get; set; }
        private string password;

        private string first_name { get; set; }
        public string First_name { get { return first_name; } }

        private string last_name { get; set; }
        private string email { get; set; }
        private List<Patient> patients;
        public List<Patient> Patients { get { return patients; } }




        public Doctor(int id, string first_name, string last_name, string email)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
        }


        public Doctor(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Doctor()
        {

        }

        public void loginDoctor()
        {
            string query = string.Format("SELECT * FROM doctor WHERE username='{0}' && password='{1}'", this.username, this.password);
            var reader = sQLServer.executeQeury(query);
            while (reader.Read())
            {
                this.id = reader.GetInt16("id");
                this.first_name = reader.GetString("first_name");
                this.last_name = reader.GetString("last_name");
                this.email = reader.GetString("email");
            }
        }

        public Doctor alternateLoginDoctor(string username, string password)
        {
            string query = string.Format("SELECT * FROM doctor WHERE username='{0}' && password='{1}'", username, password);
            var reader = sQLServer.executeQeury(query);
            while (reader.Read())
            {
                this.id = reader.GetInt16("id");
                this.first_name = reader.GetString("first_name");
                this.last_name = reader.GetString("last_name");
                this.email = reader.GetString("email");
            }
            return this;
        }

        public void addPatient(Patient patient)
        {
            this.patients.Add(new Patient(patient.id, patient.username, patient.firstname, patient.lastname, patient.salutation, patient.prefix, 20, patient.bsn, patient.email, patient.phone, patient.allergies, this.id));
        }


        public void loadPatients()
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

            MySqlDataReader reader = sQLServer.executeQeury(query);
            while (reader.Read())
            {
                int prefixPos = reader.GetOrdinal("prefix");
                int salutationPos = reader.GetOrdinal("salutation");
                int phonePos = reader.GetOrdinal("phone");
                int allergiesPos = reader.GetOrdinal("allergies");

                Patient patient = new Patient(
                    reader.GetInt16("id"),
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
                    this.id
                    );
                this.addPatient(patient);
            }
            reader.Close();
        }

        /*        public Doctor getPatientForDoctor()
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

                    MySqlDataReader reader = sQLServer.executeQeury(query);
                    while (reader.Read())
                    {
                        int prefixPos = reader.GetOrdinal("prefix");
                        int salutationPos = reader.GetOrdinal("salutation");
                        int phonePos = reader.GetOrdinal("phone");
                        int allergiesPos = reader.GetOrdinal("allergies");

                        Patient patient = new Patient(
                            reader.GetInt16("id"),
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
                            this.id
                            );
                        this.addPatient(patient);
                    }
                    reader.Close();
                    return this;
                }*/
    }
}
