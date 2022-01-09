using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    public class Medicine
    {
        public int id;
        public string name;
        public string consumption_method;
        public string category;
        public string? prescription;
        SQLServer sQLServer = new SQLServer();


        public Medicine(int id, string name, string consumption_method, string category, string prescription)
        {
            this.id = id;
            this.name = name;
            this.consumption_method = consumption_method;
            this.category = category;
            this.prescription = prescription;
        }
    }
}


