namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;

        public MainMenu(MenuItem i_MenuItem)
        {
            m_MenuItem = i_MenuItem;
        }

        public MenuItem MenuItem { get => m_MenuItem; set => m_MenuItem = value; }

        public void Show()
        {
            m_MenuItem.DisplayMenu();
        }
    }
}