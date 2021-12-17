using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    public class Patient
    {
        public string name { get; }
        public string email;
        public string phone;
        public string gender;
        public string lastname;
        public int age;
        
        public Patient(string name, string lastname, int age)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }
    }
}
