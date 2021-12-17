using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    internal class Patient
    {
        private string name;
        private string email;
        private string phone;
        private string gender;
        private string lastname;
        private int age;
        
        public Patient(string name, string lastname, int age)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }
    }
}
