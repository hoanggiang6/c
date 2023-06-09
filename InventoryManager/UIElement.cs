using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class UIElement
    {
        public string key = "";
        public string name = "";
        public Action CallBack = null;

        public UIElement(string key, string name, Action callBack)
        {
            this.key = key;
            this.name = name;
            CallBack = callBack;
        }
    }
}
