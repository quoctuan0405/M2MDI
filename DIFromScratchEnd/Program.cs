using DIFromScratchEnd.Data;
using DIFromScratchEnd.DI;
using DIFromScratchEnd.Page;

bool isContinue = true;

var services = new DIServiceCollection();

services.AddScope<ApplicationDBContext>();
services.AddScope<UserPage>();
services.AddScope<SummaryPage>();

var container = services.GenerateContainer();

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
            using (var scopeProvider = container.CreateScope())
            {
                scopeProvider.GetService<UserPage>().All();
            }
            break;

        case "2":
            using (var scopeProvider = container.CreateScope())
            {
                scopeProvider.GetService<SummaryPage>().GetSummary();
            }
            break;

        default:
            isContinue = false;
            break;
    }

    Console.WriteLine();
}

