using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private MenuItemBase m_MenuItem;

        public MainMenu(MenuItemBase i_MenuItem)
        {
            m_MenuItem = i_MenuItem;
        }

        public MenuItemBase MenuItem
        {
            get { return m_MenuItem; }
            set { m_MenuItem = value; }
        }

        public void Show()
        {
            m_MenuItem.SelectMenuItem();
        }
    }
}
