namespace Malshinon;

public class Menu
{
    public static void Start()
    {
        Welcome();
        while (true)
        {
            Console.WriteLine("-----Malshinon Menu-----\n" +
                              "1. start reporting\n" +
                              "2. restore code\n" +
                              "3. Manger access\n" +
                              "4. Exit\n");
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
                    Admin();
                    break;
                case "4":
                    Console.WriteLine("Bye bye");
                    return;
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
        while (true)
        {
            Console.WriteLine("1. all Reporter\n" +
                              "2. all Target\n" +
                              "3. all Both\n" +
                              "4. all potential agent\n" +
                              "5. all alerts\n" +
                              "6. get details by ID\n" +
                              "7. Evaluate Reporter Performance\n" +
                              "8. back");
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
                case "4":
                    People.GetListByType("potential_agent");
                    break;
                case "5":
                    Alerts.GetAllAlerts();
                    break;
                case "6":
                    People.GetDetailsByID();
                    break;
                case "7":
                    IntelReports.EvaluateReporterPerformance();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid name, Try again.");
                    break;
            }
        }
    }

    static void Admin()
    {
        string correctPassword = "Admin";
        int count = 0;

        while (count<5)
        {
            Console.Write("Enter admin password : ");
            string password = Console.ReadLine();

            if (password == correctPassword)
            {
                GetTop();
                return;
            }
            else
            {
                Console.WriteLine("Incorrect password.");
                count++;
            }
        }
    }

    static void Welcome()
    {
        int count = 0;
        while (count<5)
        {
            Console.WriteLine("Welcome.");
            Thread.Sleep(100); 
            Console.Clear();
            Console.WriteLine("Welcome..");
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine("Welcome...");
            Thread.Sleep(100); 
            Console.Clear();
            Console.WriteLine("Welcome....");
            Thread.Sleep(100); 
            Console.Clear();
            count++;
        }
    }
}