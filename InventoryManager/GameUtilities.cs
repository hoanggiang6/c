using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class GameUtilities
    {
        public static void ShowItems(Item[] items)
        {
            foreach (Item item in items) 
            { 
                item.ShowItem();
            }
        }

        public static Item GetRandomItem()
        {
            int value = GetRandomValue(0, 100);

            if (value % 2 == 0)
                return new Cloth();
            else
                return new Weapon();
        }


        public static Item[] RemoveItem(Item[] arr, int index)
        {
            Item[] newArr = new Item[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (i < index)
                    newArr[i] = arr[i];
                else
                    newArr[i] = arr[i + 1];
            }

            return newArr;
        }


        public static int GetRandomValue(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
