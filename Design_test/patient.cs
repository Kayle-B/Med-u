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
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }

        public Patient(int id, string name, string lastname/*, int age*/)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            //this.age = age;
        }

        public Patient getPatient(int id)
        {
            string query = string.Format("SELECT * FROM patient WHERE id = '{0}'", this.id);

            sQLServer.reader = sQLServer.executeQeury(query);

            while (sQLServer.reader.Read())
            {
                this.id = (int)sQLServer.reader.GetValue(0);
                this.name = sQLServer.reader.GetString("name");
                this.lastname = sQLServer.reader.GetString("lastname");
            }
            return this;
        }

        public void savePatient(string name, string lastname, int doctor_id)
        {
            string query = string.Format("INSERT INTO patient(name, lastname, age, doctor_id)VALUES('{0}', '{1}', '{2}', {3});", name, lastname, 20, doctor_id);
            sQLServer.reader = sQLServer.executeQeury(query);
        }

        public void updatePatient(int id, string name, string lastname)
        {

            string query = string.Format("UPDATE patient SET name='{0}', lastname='{1}' WHERE id='{2}'", name, lastname, id);
            sQLServer.reader = sQLServer.executeQeury(query);
        }


    }
}
