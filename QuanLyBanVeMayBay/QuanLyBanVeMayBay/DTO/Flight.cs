using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DTO
{
    public class Flight
    {
        public Flight(int MACB, string TENCB)
        {
            this.ID = MACB;
            this.Name = TENCB;
        }
        public Flight(DataRow row)
        {
            this.ID = (int)row["MACB"];
            this.Name = row["TENCB"].ToString();
        }

        private string name;
        public string Name
        { get { return name; } set { name = value; } }

        private int iD;
        public int ID { get { return iD; } set { iD = value; } }

    }
}
