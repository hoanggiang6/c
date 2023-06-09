using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventoryManager.Cloth;

namespace InventoryManager
{
    public class Weapon : Item
    {
        public enum Quality
        {
            Common = 1,
            Rare = 2,
            Epic = 3,
            Legendary = 4
        }

        protected Quality quality;
        protected int level;

        public static float mediumPrice = 1.5f;

        public Quality ItemQuality => quality;

        public int Level => level;


        public override float Price => (int)quality * level * mediumPrice;


        public Weapon() : base() 
        {

        }

        public override void ShowItem()
        {
            base.ShowItem();

            Console.WriteLine("Quality: " + quality.ToString());
            Console.WriteLine("Level: " + level);
        }

        public override void UpdateItem()
        {
            quality = (Quality)int.Parse(UIManager.Instance.Input("Nhap quality: "));
            level = int.Parse(UIManager.Instance.Input("Nhap level: "));
        }

        protected override void InitializedContenxt()
        {
            quality = (Quality)GameUtilities.GetRandomValue(1, 5);
            level = GameUtilities.GetRandomValue(1, 6);
            itemType = ItemType.Weapon;
        }
    }
}
