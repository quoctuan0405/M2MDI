using DIFromScratchStart.Data;
using DIFromScratchStart.Page;

bool isContinue = true;

while (isContinue)
{
    Console.WriteLine("Welcome to Admin Console");
    Console.WriteLine("1. User Page");
    Console.WriteLine("2. Summary Page");
    Console.Write("Please chooose: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            new UserPage().All();
            break;

        case "2":
            new SummaryPage().GetSummary();
            break;

        default:
            isContinue = false;
            break;
    }

    Console.WriteLine();
}

