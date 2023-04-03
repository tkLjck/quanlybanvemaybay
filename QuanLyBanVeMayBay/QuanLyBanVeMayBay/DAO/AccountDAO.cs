using QuanLyBanVeMayBay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        { 
            get { if (instance == null) instance = new AccountDAO(); return instance; } 
            private set { instance = value; } }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE TENTK = N'" + userName + "' AND MATKHAU = N'" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public List<Account> GetListAccount()
        {
            List<Account> list = new List<Account>();
            string query = "SELECT * FROM TAIKHOAN";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
               Account account = new Account(item);
               list.Add(account);
            }

            return list;
        }
        public bool InsertAccount(string name, string password)
        {
            string query = string.Format("INSERT TAIKHOAN(TENTK, MATKHAU) VALUES (N'{0}', N'{1}')", name, password);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

