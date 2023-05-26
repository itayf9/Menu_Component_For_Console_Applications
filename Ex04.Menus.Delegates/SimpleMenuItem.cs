using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class SimpleMenuItem : MenuItemBase
    {
        private readonly int r_ExitOrGoBackIndex = 0;
        private List<MenuItemBase> m_SubMenuItems;

        public List<MenuItemBase> SubMenu
        {
            get { return m_SubMenuItems; }
        }

        public SimpleMenuItem(string i_MenuTitle)
            : base(i_MenuTitle)
        {
        }

        public override void SelectMenu()
        {
            Console.Clear();
            int index = 1;
            Console.WriteLine(MenuTitle);
            string returnToPrevMenuTitle = PrevMenu == null ? "Exit" : "Back";
            Console.WriteLine("{0}. {1}", r_ExitOrGoBackIndex, returnToPrevMenuTitle);
            m_SubMenuItems.ForEach(menuItem =>
            {
                Console.WriteLine(@"{0}. {1}", index, menuItem.MenuTitle);
                index++;
            });
            int userChoice = getUsersChoice();
            invokeChoiceAction(userChoice);
        }

        public void AddSubMenuItem(MenuItemBase i_SubMenuItem)
        {
            i_SubMenuItem.PrevMenu = this;
            if (m_SubMenuItems == null)
            {
                m_SubMenuItems = new List<MenuItemBase>();
            }

            m_SubMenuItems.Add(i_SubMenuItem);
        }

        private void invokeChoiceAction(int i_UserChoice)
        {
            if (i_UserChoice <= m_SubMenuItems.Count && i_UserChoice > 0)
            {
                m_SubMenuItems[i_UserChoice - 1].SelectMenu();
            }
            else if (PrevMenu != null)
            {
                PrevMenu.SelectMenu();
            }
        }

        private int getUsersChoice()
        {
            Console.WriteLine("Please choose an option between 0 and {0}: ", m_SubMenuItems.Count);

            string userInputAsStr = Console.ReadLine();
            int userInput;
            bool isValidInput = int.TryParse(userInputAsStr, out userInput);

            while (!isValidInput || userInput < 0 || userInput > m_SubMenuItems.Count)
            {
                Console.WriteLine("Invalid input, Please type a number of your choice between 0 and {0} : ", m_SubMenuItems.Count);
                userInputAsStr = Console.ReadLine();
                isValidInput = int.TryParse(userInputAsStr, out userInput);
            }

            return userInput;
        }
    }
}