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
}