using System.Xml.Serialization;

string[] Names = { "Rod Mastria", "Elijah Reid", "Logan Reeves", "Dominic Nutaitis", "Ethan Thomas", "Justin Jones" };
string[] Foods = { "Anything Italian", "Spaghetti", "Wings", "Sushi", "Jambalaya", "Baja Blast" };
string[] Homes = { "Detroit/SaoPaulo", "Whitehall", "Mansfield", "New Baltimore", "Rolla", "Grand rapids" };
string[] nameSplit = new string[Names.Length * 2];
int j = 0;

for (int i = 0; i < nameSplit.Length; i+=2)
{
    string[] holder = Names[j].Split(" ");

    nameSplit[i] = holder[0].ToLower();
    nameSplit[i+1] = holder[1].ToLower();
    j++;
}

bool runProgram = true;

while (runProgram)
{
    Console.Clear();

    displayFacts(userMenu(Names, nameSplit), Names, Foods, Homes);


    Console.WriteLine("Press any key...");
    Console.ReadKey();

    Console.Clear();

    runProgram = contProgram();
}


static bool contProgram()
{
    Console.Write("Would you like to learn about another student?(Y/N): ");
    string answer = Console.ReadLine().ToLower().Trim().Substring(0, 1);
    Console.WriteLine();

    bool invalidInput = true;

    while (invalidInput)
    {
        if (answer == "y")
        {
            return true;
        }
        else if (answer == "n")
        {
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
            return false;
        }
        else
        {
            Console.Write("Please enter a valid answer.(Y/N): ");
            answer = Console.ReadLine().ToLower().Trim().Substring(0, 1);
            Console.WriteLine();
        }
    }
    return false;
}

static int userInput()
{

    string choice = Console.ReadLine().ToLower().Trim();

    string[] validInputsFood = { "food", "favorite", "favoritefood", "favorite food"};
    string[] validInputsHome = { "home", "town", "hometown", "home town"};

    bool invalidInput = true;

    while (invalidInput)
    {
        if (validInputsFood.Contains(choice))
        {
            invalidInput = false;
            return 0;
        }
        else if (validInputsHome.Contains(choice))
        {
            return 1;
        }
        else if (invalidInput)
        {
            Console.Write("Please enter a valid input: ");
            choice = Console.ReadLine().ToLower().Trim();
        }
    }

    return -1;
}

static bool userDisplay(string[] Names)
{
    Console.Write("Would you like to see a list of students names?(Y/N): ");
    string choice = Console.ReadLine().ToLower();
    Console.WriteLine();

    while (choice != "y" && choice != "n")
    {
        Console.Write("Please enter a valid input.(Y/N): ");
        choice = Console.ReadLine().ToLower();
        Console.WriteLine();
    }

    if (choice == "y")
    {
        for (int i = 0; i < Names.Length; i++)
        {
            Console.Write($"{Names[i]} ");
            Console.WriteLine();
        }
        Console.WriteLine();
        return true;
    }
    else
    {
        return false;
    }
}

static int userMenu(string[] Names, string[] nameSplit)
{
    if (userDisplay(Names))
    {
        Console.Write("Choose a Student by first name: ");
        string userName = Console.ReadLine().ToLower();
        Console.WriteLine();

        bool invalidInput = true;

        while (invalidInput)
        {
            if (nameSplit.Contains(userName))
            {
                for(int i = 0; i < nameSplit.Length; i++)
                {
                    if (nameSplit[i].Contains(userName))
                    {
                        return i / 2;
                    }
                }
            }

            else if (invalidInput)
            {
                Console.Write("Please enter a valid input: ");
                userName = Console.ReadLine().ToLower();
            }
        }
        return -1;
    }
    else
    {
        Console.Write($"Please enter a number from 1 - {Names.Length + 1}: ");

        int.TryParse(Console.ReadLine(), out int userNumber);
        Console.WriteLine();

        bool invalidInput = true;

        while (invalidInput)
        {
            if (userNumber >= 1 && userNumber <= Names.Length + 1)
            {
                return userNumber - 1;
            }

            else if (invalidInput)
            {
                Console.Write("Please enter a valid input: ");
                int.TryParse(Console.ReadLine(), out userNumber);
                Console.WriteLine();
            }
        }
        return -1;
    }
}

static void displayFacts(int index, string[] Names, string[] Foods, string[] Homes)
{
    Console.WriteLine($"{Names[index]} is Student {index + 1}. Would you like to know their \"Hometown\" or their \"Favorite Food\"?");
    int choice = userInput();
    Console.WriteLine();

    if (choice == 0)
    {
        Console.WriteLine($"{Names[index]}'s favorite food is {Foods[index]}");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"{Names[index]} is from {Homes[index]}");
        Console.WriteLine();
    }
}