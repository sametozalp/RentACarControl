using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RentACarControl
{
    internal class RentACarDatabaseConnection
    {
        public RentACarDatabaseConnection(string databaseString)
        {
            try
            {
                sqlConnection = new SqlConnection(databaseString);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void open()
        {
            sqlConnection.Open();
        }

        public List<User> getQueryUserListData(string query)
        {
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);

                adapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            User user;
            foreach (DataRow row in dataTable.Rows)
            {
                user = new User(Convert.ToInt32(row["id"]), row["mail"].ToString(), Convert.ToDateTime(row["date"]));
                list.Add(user);
            }

            return list;
        }

        public void close()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        DataTable dataTable;
        public List<User> list = new List<User>();
    }
}
