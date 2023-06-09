using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class Inventory
    {
        private int capacity = 10;
        private int totalItem = 0;
        private float gold = 0;

        public Dictionary<string, Item> items;


        public Inventory() 
        {
            totalItem = 0;
            gold = 0;
            items = new Dictionary<string, Item>();
        }

        public void StoreItem(Item item)
        {
            if (totalItem >= capacity)
                return;

            if (!items.ContainsKey(item.ItemName))
                items.Add(item.ItemName, item);
            else
                items[item.ItemName] = item;

            totalItem++;
        }

        public void SellItem(Item item)
        {
            if (totalItem <= 0)
                return;

            if (items.ContainsValue(item))
            {
                gold += item.Price;
                items.Remove(item.ItemName);
                totalItem--;
            }
        }

        public void AddGold(float value)
        {
            gold += value;
        }

        public bool ContainsItem(Item item)
        {
            return items.ContainsKey(item.ItemName);
        }

        public Item GetItemByKey(string key)
        {
            return items[key];
        }

        public void ShowAllItem()
        {
            Console.WriteLine("Total item: " + totalItem);
            Console.WriteLine("Gold: " + gold);

            foreach (KeyValuePair<string, Item> kvalue in items)
            {
                kvalue.Value.ShowItem();
            }
        }
        public void ShowAllItem(List<Item> items)
        {
            Console.WriteLine("Total item: " + totalItem);
            Console.WriteLine("Gold: " + gold);

            foreach (var kvalue in items)
            {
                kvalue.ShowItem();
            }
        }

    }
}
