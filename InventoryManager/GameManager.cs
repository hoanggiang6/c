using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class GameManager
    {

        private static GameManager _instance = null;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        public ItemPanel<Item> allItemPanel;
        public ItemPanel<Weapon> weaponPanel;
        public ItemPanel<Cloth> clothPanel;


        private GameManager()
        {
            allItemPanel = new ItemPanel<Item>();
            weaponPanel = new ItemPanel<Weapon>();
            clothPanel = new ItemPanel<Cloth>();
        }


        public void ShowMainPanel()
        {
            UIElement[] element = new UIElement[4];
            element[0] = new UIElement("1", "Quan ly weapon", ShowWeaponPanel);
            element[1] = new UIElement("2", "Quan ly cloth", ShowClothPanel);
            element[2] = new UIElement("3", "Quan ly tat ca vat pham", ShowAllItemPanel);
            element[3] = new UIElement("4", "Hien thi thong tin kho do", ShowInventoryInformation);

            UIManager.Instance.PrintMenu("Chuong trinh quan ly kho do", element);
        }

        private void ShowWeaponPanel()
        {
            ShowPanel("Quan ly weapon", weaponPanel);
        }

        private void ShowClothPanel()
        {
            ShowPanel("Quan ly cloth", clothPanel);
        }

        private void ShowAllItemPanel()
        {
            ShowPanel("Quan ly tat ca item", allItemPanel);
        }

        private void ShowPanel<T>(string title, ItemPanel<T> panel) where T : Item, new()
        {
            UIElement[] element = new UIElement[5];
            element[0] = new UIElement("1", "Hien thi tat item", () => { ShowAllItem(panel); });
            element[1] = new UIElement("2", "Cap nhap thong tin item", () => { UpdateItem(panel); });
            element[2] = new UIElement("3", "Them item", () => { AddItem(panel); });
            element[3] = new UIElement("4", "Ban item", () => { SellItem(panel); });
            element[4] = new UIElement("0", "Quay lai", ShowMainPanel);

            UIManager.Instance.PrintMenu(title, element);
        }

        private void ShowAllItem<T>(ItemPanel<T> panel) where T : Item
        {
            Console.Clear();
            UIManager.Instance.PrintMesseger("Danh sach tat ca vat pham");
            UIManager.Instance.PrintLine(30);
            panel.ShowAllItem();
            UIManager.Instance.PrintLine(30);

            UIElement[] element = new UIElement[2];
            element[0] = new UIElement("S", "Sap xep danh sach vat pham", () => { ShowItemsSorted(panel); });
            element[1] = new UIElement("0", "Quay lai", ShowMainPanel);

            UIManager.Instance.PrintMenu("", element, false);
        }

        private void ShowItemsSorted<T>(ItemPanel<T> panel) where T : Item
        {
            Console.Clear();
            UIManager.Instance.PrintMesseger("Danh sach vat pham da sap xep");
            UIManager.Instance.PrintLine(30);
            List<Item> tempItems = panel.GetItemsSorted();
            panel.ShowAllItem(tempItems);
            BackToMainPanel();
        }

        private void ShowInventoryInformation()
        {
            Console.Clear();
            UIManager.Instance.PrintMesseger("Thong tin kho do");
            UIManager.Instance.PrintLine(30);
            allItemPanel.ShowInformation();
            BackToMainPanel();
        }

        private void SellItem<T>(ItemPanel<T> panel) where T : Item, new()
        {
            string itemID;
            CheckItemContain(panel, out itemID);
            panel.SellItem(itemID);
            Console.Clear();
            UIManager.Instance.PrintMesseger("Ban vat pham ID : " + itemID + " thanh cong");
            BackToMainPanel();
        }

        private void AddItem<T>(ItemPanel<T> panel) where T : Item, new()
        {
            T item = typeof(T) == typeof(Item) ? (T)GameUtilities.GetRandomItem() : new T();
            panel.AddItem(item);
            Console.Clear();
            UIManager.Instance.PrintMesseger("Them vat pham thanh cong");
            UIManager.Instance.PrintMesseger("Thong tin vat pham");
            item.ShowItem();
            BackToMainPanel();
        }

        private void UpdateItem<T>(ItemPanel<T> panel) where T : Item
        {
            string itemID;
            CheckItemContain(panel, out itemID);
            panel.UpdateItem(itemID);
            Console.Clear();
            UIManager.Instance.PrintMesseger("Cap nhap thong tin vat pham thanh cong");
            UIManager.Instance.PrintMesseger("Thong tin vat pham");
            panel.GetItemByID(itemID).ShowItem();
            BackToMainPanel();
        }

        private void CheckItemContain<T>(ItemPanel<T> panel, out string itemID) where T : Item
        {
            while (true)
            {
                string key = UIManager.Instance.Input("Nhap item id: ");
                if (panel.ContainItem(key))
                {
                    itemID = key;
                    break;
                }
            }
        }

        private void BackToMainPanel()
        {
            UIManager.Instance.PrintLine(30);
            UIManager.Instance.Input("Nhan phim bat ky de quay lai...");
            ShowMainPanel();
        }
    }
}
