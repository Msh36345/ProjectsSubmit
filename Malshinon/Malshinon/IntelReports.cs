namespace Malshinon;

public class IntelReports
{
    public static void AddReport(int idTarget, string report, int idReporter)
    {
        // public static void GetSecretCode()
        // {
        //     string[] name = Users.AskForName();
        //     string query = $"SELECT secret_code FROM People WHERE first_name = '{name[0]}' AND last_name = '{name[1]}'";
        //     string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        //     try
        //     {
        //         using (var connection = new MySqlConnection(connstring))
        //         {
        //             connection.Open();
        //             using (var cmd = new MySqlCommand(query, connection))
        //             using (var reader = cmd.ExecuteReader())
        //             {
        //                 while (reader.Read())
        //                 {
        //                     string codeName = reader.GetString("secret_code");
        //                     Console.WriteLine($"Your secret code is : {codeName}");
        //                 }
        //             }
        //         }
        //     }
        //     catch (MySqlException)
        //     {
        //         Console.WriteLine("Database access error");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("General Error: " + ex.Message);
        //     }
    }
}