namespace Malshinon;

public static class Users
{
    public static int LogIn()
    {
        Console.Write("Please enter your login details : ");
        string login = Console.ReadLine();
        int id = People.ChecksIfUserExists(login);
        if (id==0)
        {
           People.CreatePeople();
           id = People.ChecksIfUserExists(login);
        }
        return id;
    }
    public static string[] AskForName()
    {
        while (true)
        {
            Console.Write("Enter full name : ");
            string[] name = Console.ReadLine().Split();
            if (name[0].Length<2 || name[0].All(char.IsDigit))
            {
                Console.WriteLine("Invalid name, Try again.");
            }
            else if (People.ChecksIfUserExists(name[0])==0)
            {
                return name;
            }
            else
            {
                Console.WriteLine("This name already exists, Try again.");
            }
        }
    }

    public static string CreateSecretCode()
    {
        Random rnd = new Random();
        string code = "";
        string letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        for (int i = 0; i < 4; i++)
        {
            code += letters[rnd.Next(0, letters.Length)];
        }
        return code;
    }
    
}