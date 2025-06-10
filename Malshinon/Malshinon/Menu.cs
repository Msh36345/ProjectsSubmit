namespace Malshinon;

public class Menu
{
    public static void Start()
    {
        while (true)
        {
            Console.WriteLine("-----Malshinon Menu-----\n" +
                              "1. start reporting\n" +
                              "2. restore code\n" +
                              "3. get lists");
            string choice = GetChoice();
            switch (choice)
            {
                case "1":
                    int id = Users.LogIn();
                    Reports.StartReport(id);
                    break;
                case "2":
                    People.GetSecretCode();
                    break;
                case "3":
                    GetTop();
                    break;

                default:
                    Console.WriteLine("Invalid name, Try again.");
                    break;
            }
        }
    }

    static string GetChoice()
    {
        Console.Write("Enter your choice : ");
        string choice = Console.ReadLine();
        return choice;
    }

    static void GetTop()
    {
        Console.WriteLine("1. Reporter\n" +
                          "2. Target\n" +
                          "3. Both\n" +
                          "4. potential agent\n" +
                          "5. back");
        string choice = GetChoice();
        switch (choice)
        {
            case "1": 
                People.GetListByType("Reporter");
                break;
            case "2":
                People.GetListByType("Target");
                break;
            case "3":
                People.GetListByType("Both");
                break;
            case "4" :
                People.GetListByType("potential_agent");
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Invalid name, Try again.");
                break;
        }
    }
}