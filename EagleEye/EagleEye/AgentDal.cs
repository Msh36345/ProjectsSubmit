using MySql.Data.MySqlClient;
namespace EagleEye;

public class AgentDal
{
    public List<Agent> GatAllAgents()
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
                         
                            int id = reader.GetInt32(0); 
                            string codeName = reader.GetString(1); 
                            string realName = reader.GetString(2); 
                            string location = reader.GetString(3); 
                            string status = reader.GetString(4); 
                            int missionsCompleted = reader.GetInt32(5);
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
        string query = $"INSERT INTO agents (codeName, realName, locition, status, missionsCompleted) VALUES ({agent.ToAdd()})";
        DAL.Run(query);
    }

    public void PrintAllAgent()
    {
        List<Agent> list = GatAllAgents();
        foreach (Agent agent in list)
        {
            Console.WriteLine(agent.ToString());
        }
    }
    
    public void UpdateAgentLocition(int id, string newLocition)
    {
        string query = $"UPDATE Agents SET locition = '{newLocition}' WHERE id={id}";
        DAL.Run(query);
    }

    public void DeleteAgent(int id)
    {
        string query = $"DELETE from Agents WHERE id={id}";
        DAL.Run(query);
    }
}