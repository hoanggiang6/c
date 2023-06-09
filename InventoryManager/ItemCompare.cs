using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class ItemCompare : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            int value = x.Type.CompareTo(y.Type);

            if (value == 0)
            {
                if (x is Weapon result)
                {
                    Weapon tempY = y as Weapon;
                    int compareValue = result.ItemQuality.CompareTo(tempY.ItemQuality);

                    if (compareValue == 0)
                        return CompareLevel(x, y);

                    return compareValue;
                }
                else if (x is Cloth _result)
                {
                    Cloth tempY = y as Cloth;
                    int compareValue = _result.Ratity.CompareTo(tempY.Ratity);

                    if (compareValue == 0)
                        return CompareLevel(x, y);

                    return compareValue;
                }

            }

            return value;
        }

        public int CompareQuality(Item x, Item y)
        {
            if (x is Weapon result)
            {
                Weapon tempY = y as Weapon;
                return result.ItemQuality.CompareTo(tempY.ItemQuality);
            }
            else if (x is Cloth _result)
            {
                Cloth tempY = y as Cloth;
                return _result.Ratity.CompareTo(tempY.Ratity);
            }

            return 0;
        }

        public int CompareLevel(Item x, Item y)
        {
            if (x is Weapon result)
            {
                Weapon tempY = y as Weapon;
                return result.Level.CompareTo(tempY.Level);
            }
            else if (x is Cloth _result)
            {
                Cloth tempY = y as Cloth;
                return _result.Star.CompareTo(tempY.Star);
            }

            return 0;
        }
    }
}
