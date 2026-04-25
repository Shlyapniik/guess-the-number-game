class Program
{
    static Random random = new();
    public static void Main()
    {
        Console.Clear();
        while(true)
        {
            ShowMenu();
            ChooseOperation();
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine(
            "This is guess the number game.\n"+
            "The types of game:\n"+
            "1. Guess the number by yourself.\n"+
            "2. Guess the number by computer.\n"+
            "0. Exit program.\n"
        );
    }

    public static void ChooseOperation()
    {
        int input = ReadInt("Your choise: ");

        switch (input)
        {
            case 1:
                Console.Clear();
                GuessByUser();
                break;
            case 2:
                Console.Clear();
                GuessByComputer();
                break;
            case 0:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

    public static void GuessByUser()
    {
        
        int number = random.Next(101);
        int answer = ReadInt("I guess the number for you. Write the answer: ");

        while (answer != number)
        {
            if (answer > number)
            {
                answer = ReadInt("Number less. Try again: ");
            }
            else if (answer < number)
            {
                answer = ReadInt("Number more. Try again: ");
            }
            
        }
        
        Console.WriteLine("\nYou right! Congratulations!\n");
    }

    public static void GuessByComputer()
    {
        int attempts = 0;
        int min = 0;
        int max = 100;
        int answer = (min + max) / 2;
        Console.WriteLine(answer);

        string input;
        do
        {
            attempts++;
            Console.WriteLine($"\nIs it {answer}?\n"+
                                "l - less\n"+
                                "m - more\n"+
                                "c - correct\n");
            input = Console.ReadLine();
            if (input == "l")
            {
                max = answer - 1;
            }
            else if (input == "m")
            {
                min = answer + 1;
            }
            else if (input == "c")
            {
                Console.WriteLine($"I guessed it in {attempts} attempts!\n");
                break;
            }
            else Console.WriteLine("Wrong input. Try again.");

            if (min > max)
            {
                Console.WriteLine("You gave inconsistent answers!\n");
                break;
            }

            answer = (min + max) / 2; 

        } while (input != "c");

    }

    public static int ReadInt(string message)
    {
        int number;
        Console.Write(message);

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Try again: ");
        }

        return number;
    }
}