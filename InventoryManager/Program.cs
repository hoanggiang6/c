using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item it = new Item();

            // Khoi tao 10 item ngau nhien
            Item[] tempItems = new Item[10];

            for (int i = 0; i < tempItems.Length; i++)
            {
                Item item = GameUtilities.GetRandomItem();
                if (item == null)
                    continue;

                GameManager.Instance.allItemPanel.AddItem(item);

                if (item is Weapon weapon)
                    GameManager.Instance.weaponPanel.AddItem(weapon);
                else if (item is Cloth cloth)
                    GameManager.Instance.clothPanel.AddItem(cloth);

                System.Threading.Thread.Sleep(100);
            }

            GameManager.Instance.ShowMainPanel();

            
            Console.ReadKey();
        }
    }


}
