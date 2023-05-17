using HomeBudget.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.Domain.Entity;

namespace HomeBudget.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService() 
        {
            Initialize();
        }
        

        public List<MenuAction> GetMenuActionsByMenuName(string menuName) 
        {
            List<MenuAction> result = new List<MenuAction>();

            foreach (var  menuAction in Items) 
            {
                if (menuAction.MenuName == menuName) 
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add new entry", "Main"));
            AddItem(new MenuAction(2, "Delete entry", "Main"));
            AddItem(new MenuAction(3, "View entry", "Main"));
            AddItem(new MenuAction(4, "Manage categories", "Main"));
            AddItem(new MenuAction(5, "List of entries", "Main"));

            AddItem(new MenuAction(1, "Income", "AddEntryMenu1"));
            AddItem(new MenuAction(2, "Expense", "AddEntryMenu1"));

            AddItem(new MenuAction(1, "Show all categories", "ManageCategories"));
            AddItem(new MenuAction(2, "Add category", "ManageCategories"));
            AddItem(new MenuAction(3, "Remove Category", "ManageCategories"));

        }
    }
}
