using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SOSFashion
{
    internal class OrderManager
    {
        public string OrderFilePath;
        UserManager userManager = new UserManager();

        public List<Order> GetOrders(string UserName)
        {
            OrderFilePath = "OrderLists/" + UserName + ".csv";
            List<Order> orders = new List<Order>();
            using (StreamReader sr = new StreamReader(OrderFilePath))
            {

                string nextLine = sr.ReadLine();
                while (nextLine != null)
                {
                    string[] variables = nextLine.Split(';');
                    int orderNo = int.Parse(variables[0]);
                    DateTime date = DateTime.Parse(variables[2]);
                    string finishedOrder = variables[3];

                    Order order = new Order(orderNo, variables[1], date, finishedOrder);
                    orders.Add(order);

                    nextLine = sr.ReadLine();
                }
            }
            return orders;
        }
        public List<Item> GetItems(int OrderNo)
        {

            OrderFilePath = "OrderLists/OrderDetail/" + OrderNo + ".csv";
            List<Item> items = new List<Item>();
            using (StreamReader sr = new StreamReader(OrderFilePath))
            {

                string nextLine = sr.ReadLine();
                while (nextLine != null)
                {
                    string[] variables = nextLine.Split(';');
                    int Price = int.Parse(variables[1]);
                    int Quantity = int.Parse(variables[2]);
                    int SoldTotal = int.Parse(variables[5]);
                    

                    Item item = new Item(variables[0], Price, Quantity, variables[3], variables[4], SoldTotal, variables[6], variables[7]);
                    items.Add(item);

                    nextLine = sr.ReadLine();
                }
            }
            return items;
        }   

        public List<Order> GetAllOrders()
        {
            List<Order> allOrders = GetOrders("AllOrders");
            return allOrders;
        }
        public void SaveOrder(List<Order> orderList)
        {
            OrderFilePath = "OrderLists/AllOrders.csv";
            using (StreamWriter writer = new StreamWriter(OrderFilePath))
            {
                foreach (Order order in orderList)
                {
                    writer.WriteLine(order.GetOrderCSV());
                }
            }
        }

        public int CreateNewOrder(User user)
        {
            List<Order> allOrders = GetAllOrders();
            int newOrderNumber = 0;
            for (int i = 0; i < allOrders.Count; i++)
            {
                if (allOrders[i] == allOrders.Last())
                {
                    newOrderNumber = allOrders[i].OrderNo;
                    newOrderNumber++;
                }
            }

            Order newOrder = new Order(newOrderNumber, user.UserName, DateTime.Now);
            allOrders.Add(newOrder);
            RegisterNewOrder(newOrder, "AllOrders");

            List<Order> accounts = new List<Order>();
            allOrders.Add(newOrder);
            RegisterNewOrder(newOrder, user.UserName);

            return newOrderNumber;
        }

        public void RegisterNewOrder(Order order, string UserName)
        {
            OrderFilePath = "OrderLists/" + UserName + ".csv";

            using (StreamWriter sw = File.AppendText(OrderFilePath))
            {
                sw.WriteLine(order.GetOrderCSV());
            }

        }

        public void CreateItemList (int OrderNo, List<Item> cart) 
        {
            OrderFilePath = "OrderLists/OrderDetail/" + OrderNo + ".csv";

            foreach (Item item in cart)
            {
                using (StreamWriter sw = File.AppendText(OrderFilePath))
                {
                    sw.WriteLine(item.GetCSV());
                }
            }
            
        }
    }
}
