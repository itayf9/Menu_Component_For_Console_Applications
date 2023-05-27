using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItemBase
    {
        private List<IRunnable> m_MethodsToRun;

        public ActionMenuItem(string i_MenuTitle)
            : base(i_MenuTitle)
        {
        }

        public override void SelectMenuItem()
        {
            if (m_MethodsToRun != null)
            {
                foreach (IRunnable methodToRun in m_MethodsToRun)
                {
                    methodToRun.Run();
                }
            }
            else
            {
                Console.WriteLine("No action was added to this menu option.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            PrevMenu.SelectMenuItem();
        }

        public void AddMethodToInvoke(IRunnable m_MethodToAdd)
        {
            if (m_MethodsToRun == null)
            {
                m_MethodsToRun = new List<IRunnable>();
            }

            m_MethodsToRun.Add(m_MethodToAdd);
        }
    }
}
