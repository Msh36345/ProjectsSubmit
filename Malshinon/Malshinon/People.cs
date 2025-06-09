using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace Malshinon;

public static class People
{
    
    public static int ChecksIfUserExists(string login)
    {
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        string query = $"SELECT id FROM People WHERE first_name='{login}' OR secret_code='{login}'";

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
                        int id = reader.GetInt32("id");
                        return id;
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
        return 0;
    }

    public static void CreatePeople()
    {
        string[] name = Users.AskForName();
        string firstName = name[0];
        string lastName = name.Length > 1 ? name[1] : "";
        string code = Users.CreateSecretCode();

        
        string query = "INSERT INTO People (first_name, last_name, secret_code) VALUES (@first_name, @last_name, @secret_code)";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";

        try
        {
            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@secret_code", code);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"User {firstName} created!!\nYour secret code is : {code}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }

        Users.LogIn();
    }
    

}