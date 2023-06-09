using System;

namespace InventoryManager
{
    public class Item
    {
        public enum ItemType
        {
            Weapon,
            Cloth
        }

        protected int id;
        protected string name = "";
        protected float price;
        protected ItemType itemType;

        public ItemType Type => itemType;

        public int itemID => id;

        public string ItemName => name;

        public virtual float Price { get; set; }

        public Item()
        {
            this.id = GetHashCode();
            name = GetType().Name + " " + "0" + GameUtilities.GetRandomValue(1, 10).ToString();

            InitializedContenxt();
        }

        public virtual void ShowItem()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Item ID: " + id);
            Console.WriteLine("Item Name: " + name);
            Console.WriteLine("Price: " + Price);
        }

        public virtual void UpdateItem()
        {
           
        }

        protected virtual void InitializedContenxt()
        {

        }
    }
}
