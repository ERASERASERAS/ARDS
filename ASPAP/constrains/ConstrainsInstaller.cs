using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.constrains
{
    class ConstrainsInstaller
    {
        public static void setConstrains(string roadType)
        {
            switch (roadType)
            {
                case ("Тоннель"):
                    ConstrainsHolder.getConstrainsHolder().MAXSPEED = 60;
                    ConstrainsHolder.getConstrainsHolder().MINSPEED = 20;
                    break;
                case ("Загородная дорога"):
                    ConstrainsHolder.getConstrainsHolder().MAXSPEED = 90;
                    ConstrainsHolder.getConstrainsHolder().MINSPEED = 20;
                    break;
                case ("Городская дорога"):
                    ConstrainsHolder.getConstrainsHolder().MAXSPEED = 60;
                    ConstrainsHolder.getConstrainsHolder().MINSPEED = 20;
                    break;
                case ("Магистраль"):
                    ConstrainsHolder.getConstrainsHolder().MAXSPEED = 110;
                    ConstrainsHolder.getConstrainsHolder().MINSPEED = 40;
                    break;
                default:
                    break;
            }
            
        }
    }
}
