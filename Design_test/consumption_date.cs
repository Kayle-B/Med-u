using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    internal class consumption_date
    {
        public int id { get; private set; }
        public int medicine_id { get; private set; }
        public DateTime date { get; private set; }
        public int amount { get; private set; }
        public bool is_consumed { get; private set; }
        public int patient_id { get; private set; }

        public consumption_date(int medicine_id, DateTime date, int patient_id, int amount)
        {
            this.medicine_id = medicine_id;
            this.date = date;
            this.patient_id = patient_id;
            this.amount = amount;
        }
    }
}
