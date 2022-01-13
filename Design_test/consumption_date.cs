using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    public class consumption_date
    {
        public int id { get; private set; }
        public int medicine_id { get; private set; }
        public DateTime date { get; private set; }
        public int amount { get; private set; }
        public bool is_consumed { get; private set; }
        public int patient_id { get; private set; }

        SQLServer sQLServer = new SQLServer();

        public consumption_date(int medicine_id, DateTime date, int patient_id, int amount, bool is_consumed)
        {
            this.medicine_id = medicine_id;
            this.date = date;
            this.patient_id = patient_id;
            this.amount = amount;
            this.is_consumed = is_consumed;
        }

        public consumption_date(int medicine_id, DateTime date, int patient_id, int amount)
        {
            this.medicine_id = medicine_id;
            this.date = date;
            this.patient_id = patient_id;
            this.amount = amount;
        }

        public consumption_date(consumption_date consumption_date)
        {
            this.medicine_id = consumption_date.medicine_id;
            this.date = consumption_date.date;
            this.patient_id = consumption_date.patient_id;
            this.amount = consumption_date.amount;
            this.is_consumed = consumption_date.is_consumed;
        }

    }
}
