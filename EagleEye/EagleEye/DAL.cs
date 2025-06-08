using MySql.Data.MySqlClient;
namespace EagleEye;

public static class DAL
{
    public static void Run(string query)
    {
        string connstring = "Server=127.0.0.1; database=eagleEyeDB; UID=root; password=";

        using (MySqlConnection conn = new MySqlConnection(connstring))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }
}