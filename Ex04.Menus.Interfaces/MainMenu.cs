using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private SimpleMenuItem m_MenuItem;

        public MainMenu(SimpleMenuItem i_MenuItem)
        {
            m_MenuItem = i_MenuItem;
        }

        public SimpleMenuItem MenuItem { get { return m_MenuItem; } set { m_MenuItem = value; } }

        public void Show()
        {
            m_MenuItem.DisplayOrInvokeMenu();
        }
    }
}
