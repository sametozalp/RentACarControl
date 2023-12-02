using System.Data;
using System.Data.SqlClient;

namespace RentACarControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
           RentACarDatabaseConnection databaseConnection = new RentACarDatabaseConnection("Data Source=DESKTOP-5HFM0UD;Initial Catalog=DATABASE;Integrated Security=True");
            
            databaseConnection.open();

            string query = "SELECT * FROM BAKIM";
            
            databaseConnection.getQueryData(query);
            
            databaseConnection.close();
        }
    }
}