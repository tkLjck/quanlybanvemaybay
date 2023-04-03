using QuanLyBanVeMayBay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DAO
{
    public class FlightDAO
    {
        private static FlightDAO instance;

        public static FlightDAO Instance 
        {
            get { if (instance == null) instance = new FlightDAO(); return FlightDAO.instance; }
            private set { FlightDAO.instance = value; } 
        }
        private FlightDAO() { }
        public List<Flight> GetFlightList()
        {
            List<Flight> list = new List<Flight>();
            string query = "SELECT * FROM CHUYENBAY";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Flight flight = new Flight(item);
                list.Add(flight);
            }

            return list;
        }

        public Flight GetFlightByID(int id)
        {
            Flight flight = null;
            string query = "SELECT * FROM CHUYENBAY WHERE MACB =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                flight = new Flight(item);
                return flight;
            }
            return flight;
        }

        public bool InsertFlight(string name)
        {
            string query = string.Format("INSERT CHUYENBAY(TENCB) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
