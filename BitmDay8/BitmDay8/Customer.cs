using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitmDay8.Manager;

namespace BitmDay8
{
    public partial class Customer : Form
    {

        public struct AllInfo
        {
            public string customerId, customerName, contactNo, customerAddress;

        }
        AllInfo allInfo;
        string verdict;
        DataTable dataTable;
        

        CustomerManager _customerManager = new CustomerManager();

        

        public Customer()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            GetAllData();
            verdict = _customerManager.CanBeAdded(allInfo);
            if( verdict.Equals("OK"))
            {
                _customerManager.AddToRepository(allInfo);
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show(verdict);
            }
            
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            dataTable = _customerManager.ShowAll();
            if (Convert.ToInt32(dataTable.Rows[0][0].ToString()) != 0)
            {
                displayDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Exists");
            }
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            verdict = _customerManager.Update(allInfo);
            if( verdict.Equals("OK"))
            {
                MessageBox.Show("Data Updated");
            }
            else
            {
                MessageBox.Show(verdict);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            verdict = _customerManager.Delete(allInfo);
            if(verdict.Equals("OK"))
            {
                MessageBox.Show("Data Deleted");
            }
            else
            {
                MessageBox.Show(verdict);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataTable = _customerManager.Search(allInfo);
            if (Convert.ToInt32(dataTable.Rows[0][0].ToString()) != 0)
            {
                displayDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found!");
            }
        }

        // Methods ------------------o----------

        private void GetAllData()
        {
            allInfo.customerId = customerIdTextBox.Text;
            allInfo.customerName = customerNameTextBox.Text;
            allInfo.contactNo = customerContactNoTextBox.Text;
            allInfo.customerAddress = customerAddressTextBox.Text;
        }

    }
}
