namespace Ex04.Menus.Delegates
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
            m_MenuItem.SelectMenu();
        }
    }
}