using MySql.Data.MySqlClient;
namespace EagleEye;

public class CreateAndAdd
{
    public static void CreateTable(string name,int col,string DB)
    {
        string connstring = $"Server=127.0.0.1; database={DB}; UID=root; password=";
        string colNames = "";
        for (int i = 0; i < col; i++)
        {
            colNames += AddCol();
            if (i < col - 1) colNames += ", ";
        }
        string query = $"create table {name} ({colNames})";
        
        using (MySqlConnection conn = new MySqlConnection(connstring))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Table '{name}' created successfully.");
        }

    }

    static string AddCol()
    {
        string col = "";
        Console.Write("Enter column name : ");
        string colName = Console.ReadLine();
        Console.Write("Enter Type column : ");
        string colType = Console.ReadLine();
        col = $"{colName} {colType}";
        return col;
    }
}