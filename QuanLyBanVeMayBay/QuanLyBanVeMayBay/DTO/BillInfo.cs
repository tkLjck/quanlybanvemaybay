using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DTO
{
    public class BillInfo
    {
        public BillInfo(int MAVE, int MAVEBAN, string DITUDEN, int SOLUONG, float TONG)
        {
            this.ID = MAVE;
            this.IDTicket = MAVEBAN;
            this.Name = DITUDEN;
            this.NumberTicket = SOLUONG;
            this.Discount = TONG;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["MAVE"];
            this.IDTicket = (int)row["MAVEBAN"];
            this.Name = row["DITUDEN"].ToString();
            this.NumberTicket = (int)row["SOLUONG"];
            this.Discount = (float)Convert.ToDouble(row["TONG"].ToString());
        }

        private int iD;

        public int ID { get {return iD; } set { iD = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private int iDTicket;
        public int IDTicket { get { return iDTicket; } set { iDTicket = value; } }

        private int numberTicket;
        public int NumberTicket { get { return numberTicket; } set { numberTicket = value; }}

        private float discount;
        public float Discount { get { return discount; } set { discount = value; } }

        
    }
}
