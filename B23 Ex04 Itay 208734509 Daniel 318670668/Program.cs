using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Delegates.MainMenu delegatesMainMenu = buildDelegatesMainMenu();
            Interfaces.MainMenu interfacesMainMenu = buildInterfacesMainMenu();

            delegatesMainMenu.Show();
            interfacesMainMenu.Show();
        }

        private static Delegates.MainMenu buildDelegatesMainMenu()
        {
            Delegates.SimpleMenuItem rootMenuItem = new Delegates.SimpleMenuItem("Main Menu - Delegates");

            Delegates.SimpleMenuItem dateTimeSubMenu = new Delegates.SimpleMenuItem("Show Date/Time");
            Delegates.ActionMenuItem showDateAction = new Delegates.ActionMenuItem("Show Date");
            showDateAction.MenuItemSelected += Utillity.ShowDate;
            Delegates.ActionMenuItem showTimeAction = new Delegates.ActionMenuItem("Show Time");
            showTimeAction.MenuItemSelected += Utillity.ShowTime;

            dateTimeSubMenu.AddSubMenuItem(showDateAction);
            dateTimeSubMenu.AddSubMenuItem(showTimeAction);
            rootMenuItem.AddSubMenuItem(dateTimeSubMenu);

            Delegates.SimpleMenuItem versionAndSpacesSubMenu = new Delegates.SimpleMenuItem("Version and Spaces");
            Delegates.ActionMenuItem showVersionAction = new Delegates.ActionMenuItem("Show Version");
            showVersionAction.MenuItemSelected += Utillity.ShowVersion;
            Delegates.ActionMenuItem countSpacesAction = new Delegates.ActionMenuItem("Count Spaces");
            countSpacesAction.MenuItemSelected += Utillity.CountSpaces;

            versionAndSpacesSubMenu.AddSubMenuItem(showVersionAction);
            versionAndSpacesSubMenu.AddSubMenuItem(countSpacesAction);
            rootMenuItem.AddSubMenuItem(versionAndSpacesSubMenu);

            Delegates.MainMenu mainMenu = new Delegates.MainMenu(rootMenuItem);

            return mainMenu;
        }

        private static Interfaces.MainMenu buildInterfacesMainMenu()
        {
            Interfaces.SimpleMenuItem rootMenuItem = new Interfaces.SimpleMenuItem("Main Menu - Interfaces");

            Interfaces.SimpleMenuItem dateTimeSubMenu = new Interfaces.SimpleMenuItem("Show Date/Time");
            Interfaces.ActionMenuItem showDateAction = new Interfaces.ActionMenuItem("Show Date");
            showDateAction.AddMethodToInvoke(new ShowDateRunnable());
            Interfaces.ActionMenuItem showTimeAction = new Interfaces.ActionMenuItem("Show Time");
            showTimeAction.AddMethodToInvoke(new ShowTimeRunnable());

            dateTimeSubMenu.AddSubMenuItem(showDateAction);
            dateTimeSubMenu.AddSubMenuItem(showTimeAction);
            rootMenuItem.AddSubMenuItem(dateTimeSubMenu);

            Interfaces.SimpleMenuItem versionAndSpacesSubMenu = new Interfaces.SimpleMenuItem("Version and Spaces");
            Interfaces.ActionMenuItem showVersionAction = new Interfaces.ActionMenuItem("Show Version");
            showVersionAction.AddMethodToInvoke(new ShowVersionRunnable());
            Interfaces.ActionMenuItem countSpacesAction = new Interfaces.ActionMenuItem("Count Spaces");
            countSpacesAction.AddMethodToInvoke(new CountSpacesRunnable());

            versionAndSpacesSubMenu.AddSubMenuItem(showVersionAction);
            versionAndSpacesSubMenu.AddSubMenuItem(countSpacesAction);
            rootMenuItem.AddSubMenuItem(versionAndSpacesSubMenu);

            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu(rootMenuItem);

            return mainMenu;
        }
    }
}
