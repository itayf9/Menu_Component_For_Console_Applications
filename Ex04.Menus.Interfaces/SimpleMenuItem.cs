using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SimpleMenuItem : MenuItemBase
    {
        private static readonly int sr_GoToPreviousMenuIndex = 0;
        private static readonly string sr_ExitMenuText = "Exit";
        private static readonly string sr_BackMenuText = "Back";
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
            string goToPreviousMenuTitle = PrevMenu == null ? sr_ExitMenuText : sr_BackMenuText;

            Console.Clear();
            Console.WriteLine(MenuTitle);
            Console.WriteLine("{0}. {1}", sr_GoToPreviousMenuIndex, goToPreviousMenuTitle);

            for (int i = 0; i < m_SubMenuItems.Count; i++)
            {
                Console.WriteLine(@"{0}. {1}", i + 1, m_SubMenuItems[i].MenuTitle);
            }

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
            Console.WriteLine("Please select an option between 0 and {0} : ", m_SubMenuItems.Count);

            string userInputAsStr = Console.ReadLine();
            int userInput;
            bool isValidInput = int.TryParse(userInputAsStr, out userInput);

            while (!isValidInput || userInput < 0 || userInput > m_SubMenuItems.Count)
            {
                Console.WriteLine("Invalid input. Please select an option between 0 and {0} : ", m_SubMenuItems.Count);
                userInputAsStr = Console.ReadLine();
                isValidInput = int.TryParse(userInputAsStr, out userInput);
            }

            return userInput;
        }
    }
}
