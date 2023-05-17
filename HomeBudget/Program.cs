


using HomeBudget;
using HomeBudget.App.Concrete;
using HomeBudget.App.Managers;


CategoryService categoryService = new CategoryService();    
MenuActionService actionService = new MenuActionService();
EntryManager entryManager = new EntryManager(actionService, categoryService);
CategoryManager categoryManager = new CategoryManager(categoryService, actionService);



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

    var operation = Console.ReadKey();

    switch (operation.KeyChar)
    {
        case '1':
            var newId = entryManager.AddNewEntry();

            break;

        case '2':
            entryManager.RemoveEntry();  

            break;

        case '3':
            entryManager.EntryDetailView();

            break;

        case '4':
            categoryManager.ManageCategories();

            break;

        default:
            Console.WriteLine("Action you entered does not exist");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;
    }
}


