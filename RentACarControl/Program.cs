using System.Data;
using System.Data.SqlClient;

namespace RentACarControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string query = "SELECT * FROM BAKIM";
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-5HFM0UD;Initial Catalog=DATABASE;Integrated Security=True");
            
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Console.WriteLine(sqlCommand.CommandText);
        
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DateTime dateTimeNow = DateTime.Now;

            List<User> list = new List<User>();
            User user;
            foreach (DataRow row in dataTable.Rows) 
            {
                user = new User(Convert.ToInt32(row["id"]), row["mail"].ToString(), Convert.ToDateTime(row["date"]));
                list.Add(user);
            }
            int subDays;
            foreach (var item in list)
            {
                Console.WriteLine("id: " + item.getAd() + " date: " + item.getDate() + " mail: " + item.getMail());
                subDays = (item.getDate() - dateTimeNow).Days + 1;
                Console.WriteLine(subDays + " gün fark..");

            }


            sqlConnection.Close();

        }
    }
}