using QuanLyBanVeMayBay.DAO;
using QuanLyBanVeMayBay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay
{
    public partial class fAdmin : Form
    {
        BindingSource ticketList = new BindingSource();
        BindingSource flightList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dtgvTicket.DataSource = ticketList;
            dtgvFlight.DataSource = flightList;
            dtgvAccount.DataSource = accountList;

            LoadTicketList();
            LoadFlightList();
            LoadAccount();
            LoadBillInfoList();
            AddTicketBinding();
            AddFlightBinding();
            AddAccountBinding();
            LoadCatagoryIntoComboBox(cbTicketCatagory);
        }
      
        void LoadTicketList()
        {
            ticketList.DataSource = TicketDAO.Instance.GetTicketList();
        }

        void AddTicketBinding()
        {
            txbNameTicket.DataBindings.Add(new Binding("Text", dtgvTicket.DataSource, "Name1", true, DataSourceUpdateMode.Never));
            txbIDTicket.DataBindings.Add(new Binding("Text", dtgvTicket.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmPriceTicket.DataBindings.Add(new Binding("Value", dtgvTicket.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        
        void LoadCatagoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = FlightDAO.Instance.GetFlightList();
            cb.DisplayMember = "Name";
        }

        private void btnShowTicket_Click(object sender, EventArgs e)
        {
            LoadTicketList();
        }

        private void txbIDTicket_TextChanged(object sender, EventArgs e)
        {
            if (dtgvTicket.SelectedCells.Count > 0)
            {
                int id = (int)dtgvTicket.SelectedCells[0].OwningRow.Cells["IDCatagory"].Value;
                Flight cataogory = FlightDAO.Instance.GetFlightByID(id);
                cbTicketCatagory.SelectedItem = cataogory;

                int index = -1;
                int i = 0;
                foreach (Flight item in cbTicketCatagory.Items)
                {
                    if (item.ID == cataogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbTicketCatagory.SelectedIndex = index;
            }
        }
        private void btnAddTicket_Click(object sender, EventArgs e)
        {           
            int IDCatagory = (cbTicketCatagory.SelectedItem as Flight).ID;
            string Name1 = txbNameTicket.Text;
            float Price = (float)nmPriceTicket.Value;

            if (TicketDAO.Instance.InsertTicket(IDCatagory, Name1, Price))
            {
                MessageBox.Show("Thêm vé thành công");
                LoadTicketList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm vé");
            }
        }

        private void btnEditTicket_Click(object sender, EventArgs e)
        {
            int IDCatagory = (cbTicketCatagory.SelectedItem as Flight).ID;
            string Name1 = txbNameTicket.Text;
            float Price = (float)nmPriceTicket.Value;
            int id = Convert.ToInt32(txbIDTicket.Text);

            if (TicketDAO.Instance.UpdateTicket(id, IDCatagory, Name1, Price))
            {
                MessageBox.Show("Sửa vé thành công");
                LoadTicketList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa vé");
            }
        }
        
        void LoadFlightList()
        {
            dtgvFlight.DataSource = FlightDAO.Instance.GetFlightList();
        }

        void AddFlightBinding()
        {
            txbFlightID.DataBindings.Add(new Binding("Text", dtgvFlight.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbFlightName.DataBindings.Add(new Binding("Text", dtgvFlight.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void btnShowFlight_Click(object sender, EventArgs e)
        {
            LoadFlightList();
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            string name = txbFlightName.Text;
            if (FlightDAO.Instance.InsertFlight(name))
            {
                MessageBox.Show("Thêm chuyến bay thành công");
                LoadFlightList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm chuyến bay");
            }
        }

        void AddAccountBinding()
        {
            txbPassWord.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "PassWord"));
            txbNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Name"));
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string name = txbNameAccount.Text;
            string password = txbPassWord.Text;
            if (AccountDAO.Instance.InsertAccount(name, password))
            {
                MessageBox.Show("Thêm tài khoản mới thành công");
                LoadFlightList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản");
            }
        }

        void LoadBillInfoList()
        {
            dtgvBillInfo.DataSource = BillInfoDAO.Instance.GetBillInfoList();
        }

        private void btnShowBillInfo_Click(object sender, EventArgs e)
        {
            LoadBillInfoList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
