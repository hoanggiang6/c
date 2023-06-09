using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class UIManager
    {

        private static UIManager _instance = null;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UIManager();
                return _instance;
            }
        }

        private UIManager()
        {

        }

        private UIElement ContainElementByKey(string key, UIElement[] element)
        {
            foreach (var e in element)
            {
                if (e.key.Equals(key))
                    return e;
            }
            return null;
        }

        private void ValidateInput(UIElement[] element, out UIElement targetElement)
        {
            while (true)
            {
                Console.Write("Nhap lua chon: ");
                string key = Console.ReadLine();
                targetElement = ContainElementByKey(key, element);
                if (targetElement != null)
                    break;
                else
                {
                    Console.Write("Khong ton tai chuc nang tren, nhan phim bat ky de tiep tuc...");
                    Console.ReadLine();
                }
            }
        }

        public string Input(string content)
        {
            Console.Write(content);
            return Console.ReadLine();
        }

        public void PrintMesseger(string messenger)
        {
            Console.WriteLine(messenger);
        }

        public void PrintMenu(string title, UIElement[] element, bool clearScreen = true)
        {
            if (clearScreen)
                Console.Clear();

            Console.WriteLine(title);
            PrintLine(30);
            for (int i = 0; i < element.Length; i++)
            {
                Console.WriteLine($"{element[i].key}. {element[i].name}");
            }
            PrintLine(30);

            UIElement targetElement = null;
            ValidateInput(element, out targetElement);

            if (targetElement.CallBack != null)
                targetElement.CallBack();
        }


        public void PrintLine(int total)
        {
            for (int i = 0; i < total; i++)
                Console.Write("=");
            Console.WriteLine();
        }
    }
}
