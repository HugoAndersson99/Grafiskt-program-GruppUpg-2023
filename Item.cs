using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSFashion
{
    public class Item
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int SoldTotal { get; set; }
        public string Category { get; set; }
        public string PicturePath { get; set; }


        public Item(string itemName, double price, int quantity, string size, string color, int soldTotal, string category, string picturePath)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
            Size = size;
            Color = color;
            SoldTotal = soldTotal;
            Category = category;
            PicturePath = picturePath;
        }
        public Item(string itemName, double price, int quantity, string size, string color, string category, string picturePath)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
            Size = size;
            Color = color;
            Category = category;
            SoldTotal = 0;
            PicturePath = "Pics/NoImage";

        }
        public string GetCSV()
        {
            return ItemName + ";" + Price + ";" + Quantity + ";" + Size + ";" + Color + ";" + SoldTotal + ";" + Category +";" + PicturePath;
        }
        
    }
}
