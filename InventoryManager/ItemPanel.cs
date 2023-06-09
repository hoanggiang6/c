using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class ItemPanel<T> where T : Item
    {
        protected Dictionary<string, Item> items;

        protected float gold = 0;

        public ItemPanel() 
        {
            items = new Dictionary<string, Item>();
            gold = 0;
        }

        public virtual void ShowInformation()
        {
            UIManager.Instance.PrintMesseger("Gold : " + gold);
            UIManager.Instance.PrintMesseger("Total item : " + items.Count);
        }

        public virtual void ShowAllItem()
        {
            foreach (var item in items) 
            {
                item.Value.ShowItem();
            }
        }

        public virtual void ShowAllItem(List<Item> collection)
        {
            foreach (var item in collection)
            {
                item.ShowItem();
            }
        }

        public virtual void AddItem(T item)
        {
            if (!items.ContainsValue(item))
                items.Add(item.itemID.ToString(), item);
        }

        public virtual void SellItem(string itemID, Action exception = null)
        {
            if (items.ContainsKey(itemID))
            {
                gold += items[itemID].Price;
                items.Remove(itemID);
            }    
            else
            {
                if (exception != null)
                    exception();
            }
        }

        public virtual void UpdateItem(string itemID, Action exception = null)
        {
            if (items.ContainsKey(itemID))
            {
                items[itemID].UpdateItem();
            }
            else
            {
                if (exception != null)
                    exception();
            }
        }

        public bool ContainItem(string itemID)
        {
            return items.ContainsKey(itemID);
        }

        public Item GetItemByID(string itemID)
        {
            return items[itemID];
        }

        public List<Item> GetItemsSorted()
        {
            List<Item> tempItems = new List<Item>();
            foreach (KeyValuePair<string, Item> item in items) 
            {
                tempItems.Add(item.Value);
            }

            tempItems.Sort(new ItemCompare());
            return tempItems;
        }
    }
}
