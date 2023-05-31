


using HomeBudget;
using HomeBudget.App.Concrete;
using HomeBudget.App.Managers;


CategoryService categoryService = new CategoryService();    
MenuActionService actionService = new MenuActionService();
EntryService entryService = new EntryService(categoryService);
CategoryManager categoryManager = new CategoryManager(categoryService, actionService);
EntryManager entryManager = new EntryManager(actionService, categoryService, entryService);


while (true)
{
    Console.Clear();
    Console.WriteLine("WELCOME TO HOME BUDGET APP!");
    Console.WriteLine("\nPlease let me know what you want to do:");

    var mainMenu = actionService.GetMenuActionsByMenuName("Main");

    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }

    Console.WriteLine("\n0. Exit");
    
    var operation = Console.ReadKey();

    switch (operation.KeyChar)
    {
        case '1':
            var entries = entryService.GetAllItmes();

            Console.Clear();
            Console.WriteLine("SHOW ALL ENTRIES");

            entryService.ShowAllEntries(entries);
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            break;

        case '2':
            var newId = entryManager.AddNewEntry();

            break;

        case '3':
            entryManager.RemoveEntry();  

            break;

        case '4':
            entryManager.EntryDetailView();

            break;

        case '5':
            entryManager.SearchEntries();

            break;

        case '6':
            categoryManager.ManageCategories();

            break;        

        case '0':
            Environment.Exit(0);

            break;

        default:
            Console.WriteLine("\nAction you entered does not exist");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;
    }
}


