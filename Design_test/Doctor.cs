using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    internal class Doctor
    {
        private string name { get; }
        private string lastname { get; }


        // list class patienten
        // aanmaken van doc moet voor en achternaam mee
        private List<patient> patients { get; }

        private void addPatient(string name)
        {
            patients.Add(new patient(name));   
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public Doctor(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }
        public string getFullName()
        {
            return name + " " + lastname; 
        }
    }
}
