
//a Stworzenie(dodanie) nowej transakcji
//  a1 do wyboru typ
//  a2 do wyboru kategoria
//  a3 data, kwota, opis

using HomeBudget;

MenuActionService actionService = new MenuActionService();
actionService = Initialize(actionService);

var mainMenu = actionService.GetMenuActionsByMenuName("Main");

for (int i = 0; i < mainMenu.Count; i++) 
{
    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
}

var operation = Console.ReadKey();

EntryService entryService = new EntryService();

switch(operation.KeyChar)
{
    case '1':
        var typeCategory = entryService.AddNewEntryView(actionService);
        entryService.AddNewEntry(typeCategory);
        break;

    default:
        Console.WriteLine("Action you entered does not exist");
        break;
}


static MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add new transaction", "Main");
    actionService.AddNewAction(2, "Delete transaction", "Main");
    actionService.AddNewAction(3, "View transaction", "Main");
    actionService.AddNewAction(4, "List of transactions", "Main");

    actionService.AddNewAction(1, "Income", "AddEntryMenu1");
    actionService.AddNewAction(2, "Expense", "AddEntryMenu1");

    actionService.AddNewAction(1, "grocery", "AddEntryMenu2");
    actionService.AddNewAction(2, "entertainment", "AddEntryMenu2");
    actionService.AddNewAction(3, "health", "AddEntryMenu2");
    actionService.AddNewAction(4, "bills", "AddEntryMenu2");



    return actionService;
    
}