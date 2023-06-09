using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class Cloth : Item
    {
        public enum Rarity
        {
            Acient = 1,
            Shadow = 2,
            GodLight = 3,
            Eternal = 4
        }

        protected Rarity rarity;
        protected int star;

        public int Star => star;

        public Rarity Ratity => rarity;

        public static float mediumPrice = 1.5f;

        public override float Price => (int)rarity * star * mediumPrice;

        public Cloth() : base() 
        {
            
        }

        public override void ShowItem()
        {
            base.ShowItem();

            Console.WriteLine("Rarity: " + rarity.ToString());
            Console.WriteLine("Star: " + star);
        }

        public override void UpdateItem()
        {
            rarity = (Rarity)int.Parse(UIManager.Instance.Input("Nhap rarity: "));
            star = int.Parse(UIManager.Instance.Input("Nhap star: "));
        }

        protected override void InitializedContenxt()
        {
            rarity = (Rarity)GameUtilities.GetRandomValue(1, 5);
            star = GameUtilities.GetRandomValue(1, 6);
            itemType = ItemType.Cloth;
        }
    }
}
