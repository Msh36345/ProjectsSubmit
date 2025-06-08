using MySql.Data.MySqlClient;
namespace EagleEye;

public static class DAL
{
    public static void Run(string query)
    {
        string connstring = "Server=127.0.0.1; database=eagleEyeDB; UID=root; password=";
        MySqlConnection? conn = null;
        try
        {
            conn = new MySqlConnection(connstring);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database error: " + ex.Message);
        }
        finally
        {
            conn?.Close();
        }
    }
}