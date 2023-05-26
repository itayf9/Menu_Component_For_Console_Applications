using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private const int k_ExitOrGoBackIndex = 0;
        private string m_MenuTitle;
        private List<MenuItem> m_SubMenu;
        private MenuItem m_PrevMenu;

        public string MenuTitle { get => m_MenuTitle; set => m_MenuTitle = value; }

        public List<MenuItem> SubMenu { get => m_SubMenu; }

        protected MenuItem PrevMenu { get => m_PrevMenu; set => m_PrevMenu = value; }

        public MenuItem(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
        }

        public virtual void DisplayMenu()
        {
            Console.Clear();
            int index = 1;
            Console.WriteLine(m_MenuTitle);
            string returnToPrevMenuTitle = m_PrevMenu == null ? "Exit" : "Back";
            Console.WriteLine("{0}. {1}", k_ExitOrGoBackIndex, returnToPrevMenuTitle);
            m_SubMenu.ForEach(menuItem =>
            {
                Console.WriteLine(@"{0}. {1}", index, menuItem.m_MenuTitle);
                index++;
            });
            int userChoice = getUsersChoice();
            invokeChoiceAction(userChoice);
        }

        public void AddSubMenuItem(MenuItem i_SubMenuItem)
        {
            i_SubMenuItem.PrevMenu = this;
            if (m_SubMenu == null)
            {
                m_SubMenu = new List<MenuItem>
                {
                    i_SubMenuItem,
                };
            }
            else
            {
                m_SubMenu.Add(i_SubMenuItem);
            }
        }

        private void invokeChoiceAction(int i_UserChoice)
        {
            if (i_UserChoice <= m_SubMenu.Count && i_UserChoice > 0)
            {
                m_SubMenu[i_UserChoice - 1].DisplayMenu();
            }
            else if (m_PrevMenu != null)
            {
                m_PrevMenu.DisplayMenu();
            }
        }

        private int getUsersChoice()
        {
            Console.WriteLine("Please choose an option between 0 and {0} : ", m_SubMenu.Count);

            string userInputAsStr = Console.ReadLine();
            int userInput;
            bool v_IsValidInput = int.TryParse(userInputAsStr, out userInput);
            while (!v_IsValidInput || userInput < 0 || userInput > m_SubMenu.Count)
            {
                Console.WriteLine("Invalid input, Please type a number of your choice between 0 and {0} : ", m_SubMenu.Count);
                userInputAsStr = Console.ReadLine();
                v_IsValidInput = int.TryParse(userInputAsStr, out userInput);
            }

            return userInput;
        }
    }
}