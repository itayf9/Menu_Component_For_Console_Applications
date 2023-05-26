using System;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItemBase
    {
        public event Action MenuItemSelected;

        public ActionMenuItem(string i_MenuTitle)
            : base(i_MenuTitle)
        {
        }

        public override void SelectMenu()
        {
            OnSelection();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            PrevMenu.SelectMenu();
        }

        protected virtual void OnSelection()
        {
            if (MenuItemSelected != null)
            {
                MenuItemSelected.Invoke();
            }
            else
            {
                Console.WriteLine("There is no action in the menu selection.");
            }
        }
    }
}