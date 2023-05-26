using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class ShowDateRunnable : Interfaces.IRunnable
    {
        void Interfaces.IRunnable.Run()
        {
            Utillity.ShowDate();
        }
    }
}
