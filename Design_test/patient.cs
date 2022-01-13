using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    public class Patient
    {
        SQLServer sQLServer = new SQLServer();

        public int id { get; set; }
        public int doctor_id { get; set; }

        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string? salutation { get; set; }
        public string? prefix { get; set; }
        public int age { get; set; }
        public string bsn { get; set; }
        public string email { get; set; }
        public string? phone { get; set; }
        public string? allergies { get; set; }
        public List<Medicine> medicines { get; set; }
        public List<consumption_date> consumption_date { get; set;}

        public Patient(int id, string username, string firstname, string lastname, string salutation, string prefix, int age, string bsn, string email, string phone, string allergies, int doctor_id)
        {
            this.id = id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salutation = salutation;
            this.prefix = prefix;
            this.age = age;
            this.bsn = bsn;
            this.email = email;
            this.phone = phone;
            this.allergies = allergies;
            this.doctor_id = doctor_id;
        }

        public Patient(string username, string firstname, string lastname, string salutation, string prefix, int age, string bsn, string email, string phone, string allergies, int doctor_id)
        {
            this.id = id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salutation = salutation;
            this.prefix = prefix;
            this.age = age;
            this.bsn = bsn;
            this.email = email;
            this.phone = phone;
            this.allergies = allergies;
            this.doctor_id = doctor_id;
        }

        public Patient(int id, string username, string firstname, string lastname, string salutation, string prefix, string bsn, string email, string phone, string allergies)
        {
            this.id = id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.salutation = salutation;
            this.prefix = prefix;
            this.bsn = bsn;
            this.email = email;
            this.phone = phone;
            this.allergies = allergies;
        }

        public Patient(int id)
        {

        }

        public Patient()
        {

        }

        public Patient getPatient(int id)
        {
            string query = string.Format("SELECT * FROM patient WHERE id = '{0}'", id);

            sQLServer.reader = sQLServer.executeQeury(query);
            while (sQLServer.reader.Read())
            {
                id = (int)sQLServer.reader.GetValue(0);
                this.firstname = sQLServer.reader.GetString("first_name");
                this.lastname = sQLServer.reader.GetString("last_name");
                this.salutation = sQLServer.reader.GetString("salutation");
                this.prefix = sQLServer.reader.GetString("prefix");
                this.age = sQLServer.reader.GetInt16("age");
                this.bsn = sQLServer.reader.GetString("bsn");
                this.email = sQLServer.reader.GetString("email");
                this.phone = sQLServer.reader.GetString("phone");
                this.allergies = sQLServer.reader.GetString("allergies");
                this.doctor_id = sQLServer.reader.GetInt16("doctor_id");
            }

            return this;
        }



        private int generatePassword()
        {
            Random rnd = new Random();
            int randomPass = rnd.Next(5000, 9000);

            return randomPass;
        }

        public void savePatient(Patient patient)
        {
            int password = generatePassword();
            string query = string.Format("INSERT INTO `patient` ( `username`, `password`, `first_name`, `last_name`, `salutation`, `prefix`, `age`, `BSN`, `email`, `phone`, `allergies`, `doctor_id`) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}', '{8}', '{9}', '{10}', {11});",
                this.firstname, 
                password, 
                this.firstname,
                this.lastname,
                this.salutation,
                this.prefix,
                this.age,
                this.bsn,
                this.email,
                this.phone,
                this.allergies,
                this.doctor_id
                );
            sQLServer.reader = sQLServer.executeQeury(query);
        }

        public void updatePatient(Patient patient)
        {
            string query = string.Format("UPDATE patient SET " +
                "first_name='{0}', last_name='{1}', salutation='{2}', prefix='{3}', email='{4}', phone='{5}', BSN='{6}', allergies='{7}' WHERE id='{8}'",
                patient.firstname, patient.lastname, patient.salutation, patient.prefix, patient.email, patient.phone, patient.bsn, patient.allergies, patient.id);
            sQLServer.reader = sQLServer.executeQeury(query);
        }

        public void addMedicine(Medicine medicine)
        {
            this.medicines.Add(new Medicine(medicine.id, medicine.name, medicine.consumption_method, medicine.category, medicine.prescription));
        }

        public void getMedicine(int id)
        {
            if(this.medicines == null)
            {
                this.medicines = new List<Medicine>();
            }
            else
            {
                this.medicines.Clear();
            }
            string query = string.Format("SELECT " + 
                "medicine.id, " +
                "name, " +
                "consumption_method, " +
                "category, prescription " +
                    "FROM medicine " +
                    "INNER JOIN consumption_date " +
                    "ON medicine.id = consumption_date.medicine_id " +
                    "WHERE consumption_date.patient_id = '{0}' GROUP BY name;", id);
            sQLServer.reader = sQLServer.executeQeury(query);

            while (sQLServer.reader.Read())
            {
                int prescription = sQLServer.reader.GetOrdinal("prescription");


                Medicine medicine = new Medicine(
                    sQLServer.reader.GetInt32("id"),
                    sQLServer.reader.GetString("name"),
                    sQLServer.reader.GetString("consumption_method"),
                    sQLServer.reader.GetString("category"),
                    sQLServer.reader.IsDBNull(prescription) ? String.Empty : sQLServer.reader.GetString("prescription")
                    );
                this.addMedicine(medicine);
            }
        }

        public void addConsumption_date(consumption_date consumption_date)
        {
            this.consumption_date.Add(new consumption_date(consumption_date));
        }

        // TRIED this.id here but always was 0
        public void getConsumption_dates(int id)
        {
            if (this.consumption_date == null)
            {
                this.consumption_date = new List<consumption_date>();
            }
            else
            {
                this.consumption_date.Clear();
            }

            string query = string.Format("SELECT * FROM consumption_date WHERE consumption_date.patient_id = '{0}'", id);

            var reader = sQLServer.executeQeury(query);

            while (reader.Read())
            {
                consumption_date consumption_Dates = new consumption_date(reader.GetInt32("medicine_id"), reader.GetDateTime("date"), reader.GetInt32("patient_id"), reader.GetInt32("amount"), reader.GetBoolean("is_consumed"));
                this.addConsumption_date(consumption_Dates);
            }


            /*            string query = string.Format("SELECT " +
             "consumption_date.id, " +
             "date, " +
             "amount, " +
             "medicine_id, " +
             "is_consumed" +
                 "FROM consumption_date " +
                 "INNER JOIN medicine " +
                 "ON consumption_date.medicine_id = medicine.id " +
                 "WHERE consumption_date.patient_id = '{0}' GROUP BY name;", this.id);*/
        }

    }
}
