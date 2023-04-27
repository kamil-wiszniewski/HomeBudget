
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

static MenuActionService Initialize(MenuActionService actionService)
{
    actionService.AddNewAction(1, "Add new transaction", "Main");
    actionService.AddNewAction(2, "Delete transaction", "Main");
    actionService.AddNewAction(3, "View transaction", "Main");
    actionService.AddNewAction(4, "List of transactions", "Main");
    return actionService;
    
}