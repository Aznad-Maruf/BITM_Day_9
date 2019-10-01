using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BitmDay8.Repository
{
    public class CustomerRepository
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private DataTable dataTable;
        private string queryString;
        ConnectionRepository _connectionRepository = new ConnectionRepository();

        public string CanBeAdded(Customer.AllInfo allInfo)
        {
            queryString = "SELECT COUNT(CustomerID) FROM Customer WHERE CustomerName = '" + allInfo.customerName + "';";
            ConnectAndMakeSql(queryString);

            ExecuteQuery();

            if (NoOfEntries() == 0) return "OK";
            else return "NOT OK";

        }

        public string AddToRepository(Customer.AllInfo allInfo)
        {
            queryString = @"INSERT INTO Customer ( CustomerName, ContactNo, Address ) VALUES ( '"+allInfo.customerName+"', "+allInfo.contactNo+", '"+allInfo.customerAddress+"' );";

            ConnectAndMakeSql(queryString);
            return "OK";
        }

        public DataTable ShowAll()
        {
            queryString = @"SELECT * FROM Customer;";
            ConnectAndMakeSql(queryString);
            ExecuteQuery();
            return dataTable;

        }

        public DataTable Search(Customer.AllInfo allInfo)
        {
            queryString = @"SELECT * FROM Customer WHERE Customer Name = '" + allInfo.customerName + "';";
            ConnectAndMakeSql(queryString);
            ExecuteQuery();
            return dataTable;
        }

        public string Delete(Customer.AllInfo allInfo)
        {
            queryString = @"SELECT * FROM Customer WHERE CustomerName = '" + allInfo.customerName + "';";
            ConnectAndMakeSql(queryString);
            ExecuteQuery();
            if(NoOfEntries() == 0)
            {
                return "NOT OK";
            }
            else
            {
                queryString = @"DELETE FROM Customer WHERE CustomerName = '" + allInfo.customerName + "';";
                return "Data Deleted";
            }
        }

        public string Update(Customer.AllInfo allInfo)
        {
            throw new NotImplementedException();
        }


        // Methods ------------o------------

        private void ConnectAndMakeSql(string queryString)
        {
            sqlConnection = _connectionRepository.ConnectToDatabase();

            sqlCommand = _connectionRepository.CreateSqlCommand(sqlConnection, queryString);

        }

        private void ExecuteQuery()
        {
            dataTable = _connectionRepository.ExecuteQuery(sqlConnection, sqlCommand);
        }

        private int NoOfEntries()
        {
            return Convert.ToInt32(dataTable.Rows[0][0].ToString());
            
        }

    }
}
