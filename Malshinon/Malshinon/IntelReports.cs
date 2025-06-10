using MySql.Data.MySqlClient;

namespace Malshinon;

public class IntelReports
{
    public static void AddReport(int idTarget, string report, int idReporter)
    {
        string query = "INSERT INTO IntelReports (reporter_id, target_id, text) VALUES (@reporter_id, @target_id, @text)";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";

        try
        {
            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reporter_id", idReporter);
                    cmd.Parameters.AddWithValue("@target_id", idTarget);
                    cmd.Parameters.AddWithValue("@text", report);
                    cmd.ExecuteNonQuery();
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }
    
    public static void EvaluateReporterPerformance()
    {
        string query = $"SELECT reporter_id,COUNT(reporter_id) as count, AVG(LENGTH(text)) as avg FROM IntelReports GROUP BY reporter_id";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
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
                        int id = reader.GetInt32("reporter_id");
                        int count = reader.GetInt32("count");
                        int avg = reader.GetInt32("avg");
                        Console.WriteLine($"ID : {id} || Total reports : {count} || Average length : {avg}");
                    }
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

}