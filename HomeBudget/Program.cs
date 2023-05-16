


using HomeBudget;
using HomeBudget.App.Concrete;
using HomeBudget.App.Managers;

MenuActionService actionService = new MenuActionService();
EntryManager entryManager = new EntryManager(actionService);

Console.WriteLine("Welcome to Home Budget App!");

while (true)
{
    Console.WriteLine("Please let me know what you want to do:");

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
            /*var typeId = entryService.EntryTypeSelectionView();
            entryService.EntriesByTypeIdView(typeId);*/

            break;

        default:
            Console.WriteLine("Action you entered does not exist");
            break;
    }
}


