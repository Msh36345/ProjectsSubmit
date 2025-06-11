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
            Console.WriteLine("Database access error 1");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
        return 0;
    }
    
    public static void GetSecretCode()
    {
        string[] name = Users.AskForName(true);
        string firstName = name.Length> 1 ? string.Join(" ",name.Take(name.Length-1)) : name[0];
        string lastName = name.Length > 1 ? name[1] : "";
        string query = $"SELECT secret_code FROM People WHERE first_name = '{firstName}' AND last_name = '{lastName}'";
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
                        string codeName = reader.GetString("secret_code");
                        Console.WriteLine($"Your secret code is : {codeName}");
                    }
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 2");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
        
    }
    
    public static void GetListByType(string type)
    {
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        string query = $"SELECT * FROM People WHERE type = '{type}' ORDER BY num_reports DESC, num_mentions DESC";
        int id = 0;
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
                        id = reader.GetInt32("id"); 
                        string first_name = reader.GetString("first_name"); 
                        string last_name = reader.GetString("last_name"); 
                        string secret_code = reader.GetString("secret_code"); 
                        int num_reports = reader.GetInt32("num_reports");
                        int num_mentions = reader.GetInt32("num_mentions");
                    
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ID : {id}\n" +
                                          $"Name : {first_name+" "+last_name}\n" +
                                          $"Secret code : {secret_code}\n" +
                                          $"Num reports : {num_reports}\n" +
                                          $"Num mentions : {num_mentions}");
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
        if (type=="potential_agent")
        {
            int avg = GetAvgLengthReport(id);
            Console.WriteLine($"Average report length : {avg}");
        }
        Console.ResetColor();
    }
    
    public static void GetDetailsByID()
    {
        Console.Write("Choice ID to check : ");
        int id = int.Parse(Console.ReadLine());
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        string query = $"SELECT * FROM People WHERE id = '{id}'";
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
                        string first_name = reader.GetString("first_name"); 
                        string last_name = reader.GetString("last_name"); 
                        string secret_code = reader.GetString("secret_code"); 
                        string type = reader.GetString("type"); 
                        int num_reports = reader.GetInt32("num_reports");
                        int num_mentions = reader.GetInt32("num_mentions");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ID : {id}\n" +
                                          $"Name : {first_name+" "+last_name}\n" +
                                          $"Secret code : {secret_code}\n" +
                                          $"Type : {type}\n" +
                                          $"Num reports : {num_reports}\n" +
                                          $"Num mentions : {num_mentions}\n");
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



    
    public static void CreateReporter()
    {
        string[] name = Users.AskForName();
        CreatePeople(name,true);
    }
    public static void CreateTarget(string[] name)
    {
        CreatePeople(name);

    }
    static void CreatePeople(string[] name,bool newp = false)
    {
        string firstName = name.Length> 1 ? string.Join(" ",name.Take(name.Length-1)) : name[0];
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

            if (newp)
            {
                Console.WriteLine($"User {firstName} created!!\nYour secret code is : {code}");
                Thread.Sleep(8000);
                Menu.Start();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }
    

        

    public static void UpdateNumReports(int id)
    {
        string query = $"UPDATE People SET num_reports = num_reports + @add WHERE id = @id";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        object add = 1;

        try
        {
            using (var connection = new MySqlConnection(connstring))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@add",add);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 3");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }
    public static void UpdateNumMentions(int id)
    {
        string query = $"UPDATE People SET num_mentions = num_mentions + @add WHERE id = @id";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        object add = 1;

        try
        {
            using (var connection = new MySqlConnection(connstring))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@add",add);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 4");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }
    
    
    
    
    public static void UpdateAndCheckThresholds(int id)
    {
        int[] thresholds = GetThresholds(id);
        CheckThresholds(thresholds,id);
    }
    static int[] GetThresholds(int id)
    {
        string query = $"SELECT `num_reports`,`num_mentions` FROM People WHERE id = '{id}'";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        int[] nums = new Int32[2];
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
                        nums[0]=reader.GetInt32("num_reports");
                        nums[1]=reader.GetInt32("num_mentions");
                    }
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 5");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
        return nums;
    }
    static int GetAvgLengthReport(int id)
    {
        string query = $"SELECT AVG(LENGTH(text)) AS avg FROM IntelReports WHERE `reporter_id` = {id}";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        int avg = 0;
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
                        avg=reader.GetInt32("avg");
                    }
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 6");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
        return avg;
    }
    static void CheckThresholds(int[] nums, int id)
    {
        int reports = nums[0];
        int mentions = nums[1];
        CheckAlertTime(id);
        if (reports>0 && mentions>0)
        {
            UpdateType(id,"Both");
        }
        else if (reports>=10 && mentions==0 && GetAvgLengthReport(id)>=100)
        {
            UpdateType(id,"potential_agent");
        }
        else if (reports==0 && mentions>0)
        {
            UpdateType(id,"Target");
            if (mentions>=20)
            {
                Alerts.AddAlert(id, $"{mentions} reports detected");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"id : {id} is a potential threat.");
                Console.ResetColor();
            }
        }
        else
        {
            UpdateType(id,"Reporter");
        }
    }
    static void UpdateType(int id,string type)
    {
        string query = $"UPDATE People SET type = @type WHERE id = @id";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        object add = 1;

        try
        {
            using (var connection = new MySqlConnection(connstring))
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@type",type);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 7");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }
    static void CheckAlertTime(int id)
    {
        string query = $"SELECT COUNT(timestamp) as count FROM IntelReports WHERE target_id = {id} AND timestamp BETWEEN NOW() -INTERVAL 15 MINUTE AND NOW()";
        string connstring = "Server=127.0.0.1; database=MalshinonDB; UID=root; password=";
        int countTime = 0;
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
                        countTime=reader.GetInt32("count");
                    }
                }
            }
        }
        catch (MySqlException)
        {
            Console.WriteLine("Database access error 8");
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }

        if (countTime>=3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ID : {id} is a potential threat\n" +
                              $"Time stamp : {DateTime.Now}\n" +
                              $"Reason : rapid reports detected");
            Console.ResetColor();
            Alerts.AddAlert(id, "rapid reports detected in the last 15 minutes");
        }
    }
}