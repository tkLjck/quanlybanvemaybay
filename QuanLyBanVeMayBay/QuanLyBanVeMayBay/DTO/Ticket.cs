using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DTO
{
    public class Ticket
    {
        public Ticket( int MAVEBAN, int MACB ,string DITUDEN, float GIA)
        {
            this.ID = MAVEBAN;
            this.IDCatagory = MACB;
            this.Name1 = DITUDEN;
            this.Price = GIA;
        }
        public Ticket(DataRow row)
        {
            this.ID = (int)row["MAVEBAN"];
            this.IDCatagory = (int)row["MACB"];
            this.Name1 = row["DITUDEN"].ToString();
            this.Price = (float)Convert.ToDouble(row["GIA"].ToString());
        }

        private float price;
        public float Price { get { return price; } set { price = value; } }

        private int iDCatagory;
        public int IDCatagory { get { return iDCatagory; } set { iDCatagory = value; } }

        private string Name;
        public string Name1 { get { return Name; } set { Name = value; } }
        private int iD;

        public int ID 
        {
            get { return iD; } 
            set { iD = value; } 
        }
    }
}
