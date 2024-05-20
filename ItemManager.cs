using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;

namespace SOSFashion
{
    public class ItemManager
    {
        string itemsFilePath = "Items/Items.csv";

        public List<Item> GetItemList()
        {
            List<Item> items = new List<Item>();
            using (StreamReader reader = new StreamReader(itemsFilePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    try
                    {
                        string[] strings = line.Split(";");
                        string name = strings[0];
                        int price = Convert.ToInt32(strings[1]);
                        int amountStock = Convert.ToInt32(strings[2]);
                        string size = strings[3];
                        string color = strings[4];
                        int amountSold = Convert.ToInt32(strings[5]);
                        string category = strings[6];
                        string picturePath = strings[7];

                        items.Add(new Item(name, price, amountStock, size, color, amountSold, category, picturePath));
                        line = reader.ReadLine();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return items;
        }
        public void SaveText(List<Item> itemList)
        {

            using (StreamWriter writer = new StreamWriter(itemsFilePath))
            {
                foreach (Item item in itemList)
                {
                    writer.WriteLine(item.GetCSV());
                }
            }
        }
        public void RegisterNewItem( Item item)
        {
                using (StreamWriter sw = File.AppendText(itemsFilePath))
                {
                    sw.WriteLine(item.GetCSV());
                }
        }
        public void RemoveItem(int index)
        {
            List<Item>items = GetItemList();
            items.RemoveAt(index);
            File.Delete(itemsFilePath);
            foreach (Item item in items)
            {
                RegisterNewItem(item);
            }
        }
        public void RemoveFilePath()
        {
            File.Delete(itemsFilePath);
        }
    }
}
