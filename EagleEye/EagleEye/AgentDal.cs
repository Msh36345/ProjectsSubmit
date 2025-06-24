using MySql.Data.MySqlClient;
namespace EagleEye;

public class AgentDal
{
    public List<Agent> GetAllAgents()
    {
        List<Agent> agents = new List<Agent>();
        string connstring = "Server=127.0.0.1; database=eagleEyeDB; UID=root; password=";
        string query = "SELECT * FROM Agents";

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
                            string codeName = reader.GetString("codeName"); 
                            string realName = reader.GetString("realName"); 
                            string location = reader.GetString("location"); 
                            string status = reader.GetString("status"); 
                            int missionsCompleted = reader.GetInt32("missionsCompleted");
                            Agent agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                            agents.Add(agent);

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
        return agents;
    }
    
    public void AddAgent(Agent agent)
    {
        string query = "INSERT INTO agents (codeName, realName, location, status, missionsCompleted) VALUES (@codeName, @realName, @location, @status, @missionsCompleted)";
        string connstring = "Server=127.0.0.1; database=eagleEyeDB; UID=root; password=";

        try
        {
            using (var conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
                    cmd.Parameters.AddWithValue("@realName", agent.RealName);
                    cmd.Parameters.AddWithValue("@location", agent.Location);
                    cmd.Parameters.AddWithValue("@status", agent.Status);
                    cmd.Parameters.AddWithValue("@missionsCompleted", agent.MissionsCompleted);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding agent: " + ex.Message);
        }
    }

    public void PrintAllAgents()
    {
        List<Agent> list = GetAllAgents();
        foreach (Agent agent in list)
        {
            Console.WriteLine(agent.ToString());
        }
    }
    
    public void UpdateAgentLocation(int id, string newlocation)
    {
        string query = $"UPDATE Agents SET location = '{newlocation}' WHERE id={id}";
        DAL.Run(query);
    }

    public void DeleteAgent(int id)
    {
        string query = $"DELETE from Agents WHERE id={id}";
        DAL.Run(query);
    }
}