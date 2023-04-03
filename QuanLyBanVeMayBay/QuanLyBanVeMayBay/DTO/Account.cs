using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.DTO
{
     public class Account
    {
        public Account(string TENTK, string MATKHAU)
        {
            this.Name = TENTK;
            this.PassWord = MATKHAU;
        }

        public Account(DataRow row)
        {
            this.Name = row["TENTK"].ToString();
            this.PassWord = row["MATKHAU"].ToString();
        }

        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; } 
        }

        private string name;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
    }
}
