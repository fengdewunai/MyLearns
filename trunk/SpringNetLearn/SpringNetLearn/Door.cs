using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public delegate void OpenHandler(string arg);
    public class Door
    {
        public event OpenHandler OpenTheDoor;

        public void OnOpen(string arg)
        {
            //调用事件
            if (OpenTheDoor != null)
            {
                OpenTheDoor(arg);
            }
        }
    }
}
