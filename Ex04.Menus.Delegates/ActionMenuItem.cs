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

        public override void SelectMenuItem()
        {
            OnSelection();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            PreviousMenu.SelectMenuItem();
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