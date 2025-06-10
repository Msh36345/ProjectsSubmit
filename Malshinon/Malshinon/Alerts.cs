using MySql.Data.MySqlClient;

namespace Malshinon;

public static class Alerts
{
    public static void AddAlert(int id, string reason)
    {
        string query = $"INSERT INTO Alerts (target_id,reason) VALUES (@target_id,@reason)";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";

        try
        {
            using (var connection = new MySqlConnection(connstring))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@target_id",id);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }
    
        public static void GetAllAlerts()
    {
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        string query = $"SELECT * FROM Alerts GROUP BY target_id ORDER BY id_Alerts DESC";
        try
        {
            using (var connection = new MySqlConnection(connstring))
            {
    
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id_Alerts = reader.GetInt32("id_Alerts"); 
                        int target_id = reader.GetInt32("target_id"); 
                        string reason = reader.GetString("reason"); 
                        DateTime created_at = reader.GetDateTime("created_at"); 
                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ID alerts : {id_Alerts}\n" +
                                          $"ID target : {target_id}\n" +
                                          $"Reason : {reason}\n" +
                                          $"Created at : {created_at}\n");
                        Console.ResetColor();
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }

}