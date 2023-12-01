using System.Data;
using System.Data.SqlClient;

namespace RentACarControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String query = "SELECT * FROM OGRENCI";
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5HFM0UD;Initial Catalog=DATABASE;Integrated Security=True");
            
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Console.WriteLine(sqlCommand.CommandText);
        
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            List<string> list = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    list.Add($"{column.ColumnName}: {row[column]}");
                }
            }

            // Listeyi düzgün bir şekilde yazdırma
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            sqlConnection.Close();

        }
    }
}