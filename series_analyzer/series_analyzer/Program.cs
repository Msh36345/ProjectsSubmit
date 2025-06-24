namespace series_analyzer
{
    internal class Program
    
    
                {/// <summary>
     /// Convert a list of string to list of int
     /// </summary>
     /// <param name="list">the list with string</param>
     /// <returns>the list of int</returns>
                static List<int> ConvertListToInt(List<string> list)
        {
            List<int> listNum = new List<int>();
            foreach (string index in list)
            {
                if (int.TryParse(index,out int number))
                {listNum.Add(number);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error : '{index}' is not a int");
                    Console.ResetColor();
                    return ReadNewSeries();
                }

        }

            return listNum;
        }
                 /// <summary>
    /// Check if the list is upper from 3 numbers and they all positive
    /// </summary>
    /// <param name="list">the list with int</param>
    /// <returns>return true/false</returns>
                 static bool IsValidList(List<int> list)
        {
            int counter = 0;
            foreach (int number in list)
            {
                counter += 1;
                if (!(number > 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error : '{number}' is a negative number");
                    Console.ResetColor();
                    return false;
                    
                }
            }
            if (counter < 3) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : the series is lower from 3");
                Console.ResetColor();
                return false;}
            return true;
        }
    /// <summary>
/// Create a validate series
/// </summary>
/// <param name="list">the series to check and convert</param>
/// <returns>a validate series or null</returns>
        static List<int> CheckSeries(List<string> list)
        {
            List<int> numList = ConvertListToInt(list);
            bool isValid = IsValidList(numList);
            if (isValid)
            {
                return numList;
            }
            else
            {
                return ReadNewSeries();
            }
        }
    /// <summary>
    /// Asks the user to create a new series and then checks if the series is valid.
    /// </summary>
    /// <returns>A valid list</returns>
        static List<int> ReadNewSeries()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter a positive number (at least 3 times). To stop, press Enter.");
            Console.ResetColor();
            List<string> listInput = new List<string> ();
            bool check = true;
            while (check)
            {            
                string? input = Console.ReadLine();
                if (input!="")
                {
                    listInput.Add(input);
                }
                else
                {
                    check = false;
                }
            } 
            List<int> newSeries = CheckSeries(listInput);
            return newSeries;
        }
    
        /// <summary>
        /// “Checks the length of the series”
        /// </summary>
        /// <param name="series">series to check lengh</param>
        /// <returns>the length of the series</returns>
        static int LengthOfAnySeries(List<int> series)
        {
            int counter = 0;
            foreach (var _ in series)
            {
                counter += 1;
            }

            return counter;
        }
        /// <summary>
/// Print the series forword or backword.
/// </summary>
/// <param name="series">the series to print</param>
/// <param name="forward">true for forwards and false to backwards</param>
        static void PrintSeries(List<int> series,bool forward)
        {
            int lengh = LengthOfAnySeries(series);
            for (int i = 0; i < lengh; i++)
            {
                int num;
                if (forward)
                {
                    num = i;
                }
                else
                {
                    num = (lengh - 1) - i;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i+1}. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(series[num]+"  ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
        /// <summary>
/// Searches for the minimum or maximum in the series.
/// </summary>
/// <param name="series">the series to search</param>
/// <param name="which">'-' for the min and '+' for the max</param>
/// <returns>tje min/max number</returns>
        static int MinMaxOfAnySeries(List<int> series, char which)
        {
            int minMaxNum = series[0];

            foreach (int num in series)
            {
                if (which == '+' && num > minMaxNum)
                {                    
                    minMaxNum = num;
                }

                if (which == '-' && num < minMaxNum)
                {
                    minMaxNum = num;
                }
            }

            return minMaxNum;
        }
        /// <summary>
/// Print the series sorted from low to high.
/// </summary>
/// <param name="series">the series to sort</param>
        static void SortSeries(List<int> series)
        {
            List<int> copySeries = new List<int>(series);
            List<int> newSeries = new List<int> ();
            for (int i = 0; i < LengthOfAnySeries(series); i++)
            {
                int minNum = MinMaxOfAnySeries(copySeries, '-');
                newSeries.Add(minNum);
                copySeries.Remove(minNum);
            }
            PrintSeries(newSeries,true);
        }
        /// <summary>
/// Calculates the sum of the numbers in the series.
/// /// </summary>
/// <param name="series">the series to calculates the sum</param>
/// <returns>the sum</returns>
        static int SumOfAnySeries(List<int> series)
        {
            int sum = 0;
            foreach (int num in series)
            {
                sum += num;
            }
            return sum;
        }
        /// <summary>
/// Calculates and print the average of the series.
/// </summary>
/// <param name="series">the series to calculates the average</param>
        static void AvrageOfAnySeries(List<int> series)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"The average of the series is : {SumOfAnySeries(series)/LengthOfAnySeries(series)}");
            Console.ResetColor();
        }
        /// <summary>
        /// Print the menu for the user
        /// </summary>
        static void PrintMenu ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("chose from menu :");
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.WriteLine("1. Input a Series.");
            Console.WriteLine("2. Display the series in the order it was entered.");
            Console.WriteLine("3. Display the series in the reversed order it was entered.");
            Console.WriteLine("4. Display the series in sorted order.");
            Console.WriteLine("5. Display the Max value of the series.");
            Console.WriteLine("6. Display the Min value of the series.");
            Console.WriteLine("7. Display the Average of the series.");
            Console.WriteLine("8. Display the Number of elements in the series.");
            Console.WriteLine("9. Display the Sum of the series.");
            Console.WriteLine("0. Exit");
            Console.ResetColor();

        }
        /// <summary>
/// Receives the user’s choice and performs the requested actions
/// </summary>
/// <param name="series">the series</param>
/// <returns>“f required, returns a new list.</returns>
        static List<int> GetUserChoice(List<int> series)
        {
            ConsoleKeyInfo userChoice = Console.ReadKey();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White; 
            switch (userChoice.KeyChar)
            {
                case '1' :
                    series = ReadNewSeries();
                    break;
                case '2' :
                    Console.Write("the series is : ");
                    PrintSeries(series,true);
                    break;
                case '3' :
                    Console.Write("the  series in reverse is : ");
                    PrintSeries(series,false);
                    break;
                case '4' :
                    Console.Write("the sort series is : ");
                    SortSeries(series);
                    break;
                case '5' :
                    Console.WriteLine($"the max number in the series is : {MinMaxOfAnySeries(series,'+')}");
                    break;
                case '6' :
                    Console.WriteLine($"the min number in the series is : {MinMaxOfAnySeries(series,'-')}");
                    break;
                case '7' :
                    AvrageOfAnySeries(series);
                    break;
                case '8' :
                    Console.WriteLine($"the lengh of the series is : {LengthOfAnySeries(series)}");
                    break;
                case '9' :
                    Console.WriteLine($"the sum of the series is : {SumOfAnySeries(series)}");
                    Console.ResetColor();
                    break;
                case '0' :
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("Logged out successfully.\nCouldn’t handle the awesomeness, huh?");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Error : choose from the available options only.");
                    Console.ResetColor();
                    break;
            }
            return series;
            
        }
        /// <summary>
/// Starting the project by printing the menu and ask for a choice from the user
/// </summary>
/// <param name="toseries">the args</param>
        static void StartProgram(string[] toseries)
        {
            List<int> series = CheckSeries(toseries.ToList());
            while (true)
            {            
                PrintMenu();
                series = GetUserChoice(series);
                Thread.Sleep(1000);

            }
        }
        
        
        
        
        static void Main(string[] args)
        {
        StartProgram(args);
        }
    
    }

}
