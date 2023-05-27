using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItemBase
    {
        protected MenuItemBase m_PrevMenu;
        private string m_MenuTitle;

        public string MenuTitle
        {
            get { return m_MenuTitle; }
            set { m_MenuTitle = value; }
        }

        public MenuItemBase PrevMenu
        {
            get { return m_PrevMenu; }
            set { m_PrevMenu = value; }
        }

        protected MenuItemBase(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
        }

        public abstract void SelectMenuItem();
    }
}
