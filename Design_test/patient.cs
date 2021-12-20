using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    public class Patient
    {
        public int id { get; }
        public string name { get; }
        public string email;
        public string phone;
        public string gender;
        public string lastname;
        public int age;
        
        public Patient(int id, string name, string lastname, int age)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }
    }
}
