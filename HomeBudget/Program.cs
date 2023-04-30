
//a Stworzenie(dodanie) nowej transakcji
//  a1 do wyboru typ
//  a2 do wyboru kategoria
//  a3 data, kwota, opis

using HomeBudget;

MenuActionService actionService = new MenuActionService();
actionService = Initialize(actionService);
EntryService entryService = new EntryService();


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
            var typeCategory = entryService.AddNewEntryView(actionService);
            var id = entryService.AddNewEntry(typeCategory);
            break;

        case '2':
            var removeId = entryService.RemoveEntryView();
            entryService.RemoveEntry(removeId);

            break;

        case '3':
            var detailId = entryService.EntryDetailSelectionView();
            entryService.EntryDetailView(detailId);

            break;


        default:
            Console.WriteLine("Action you entered does not exist");
            break;
    }
}


static MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add new entry", "Main");
    actionService.AddNewAction(2, "Delete entry", "Main");
    actionService.AddNewAction(3, "View entry", "Main");
    actionService.AddNewAction(4, "List of entries", "Main");

    actionService.AddNewAction(1, "Income", "AddEntryMenu1");
    actionService.AddNewAction(2, "Expense", "AddEntryMenu1");

    actionService.AddNewAction(1, "grocery", "AddEntryMenu2");
    actionService.AddNewAction(2, "entertainment", "AddEntryMenu2");
    actionService.AddNewAction(3, "health", "AddEntryMenu2");
    actionService.AddNewAction(4, "bills", "AddEntryMenu2");



    return actionService;
    
}