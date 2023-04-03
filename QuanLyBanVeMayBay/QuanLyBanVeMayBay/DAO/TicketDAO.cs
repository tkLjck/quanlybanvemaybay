using QuanLyBanVeMayBay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DAO
{
    public class TicketDAO
    {
        private static TicketDAO instance;

        public static TicketDAO Instance
        {
            get { if (instance == null) instance = new TicketDAO(); return TicketDAO.instance; }
            private set { TicketDAO.instance = value; }
        }
        private TicketDAO() { }
        public List<Ticket> GetTicketListByCatagory(int id)
        {
            List<Ticket> list = new List<Ticket>();
            string query = "SELECT * FROM VEBAN WHERE MACB = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Ticket ticket = new Ticket(item);
                list.Add(ticket);
            }

            return list;
        }

        public List<Ticket> GetTicketList()
        {
            List<Ticket> list = new List<Ticket>();
            string query = "SELECT * FROM VEBAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Ticket ticket = new Ticket(item);
                list.Add(ticket);
            }

            return list;
        }
        
        public bool InsertTicket(int id, string name, float price) 
        {
            string query = string.Format("INSERT VEBAN(MACB, DITUDEN, GIA) VALUES ({0}, N'{1}', {2})", id, name, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTicket(int idTicket, int id, string name, float price)
        {
            string query = string.Format("UPDATE VEBAN SET MACB = {0}, DITUDEN = N'{1}', GIA = {2} WHERE MAVEBAN = {3}", id, name, price, idTicket);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
