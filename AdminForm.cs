using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using CheckBox = System.Windows.Forms.CheckBox;

namespace SOSFashion
{
    public partial class AdminForm : Form
    {
        bool switchLists = true;
        List<Order> allOrders;
        List<Order> pendingOrders = new List<Order>();
        List<Order> finishedOrders = new List<Order>();
        UserManager UserManager = new UserManager();
        OrderManager orderManager = new OrderManager();
        ItemManager ItemManager = new ItemManager();
        List<Item> items = new List<Item>();
        string itemsFilePath = "Items/Items.csv";
        private List<CheckBox> checkBoxes;
        public string picName;

        public AdminForm()
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox> { hatCheckBox, coatsCheckBox, dressesCheckBox, suitsCheckBox, accessoriesCheckBox };
            mainPanel.Visible = false;
            registerNewItemPanel.Visible = false;
            editItemPanel.Visible = false;
            removeCostumerButton.Visible = false;
            editItemButton.Visible = false;
            stockUpButton.Visible = false;
            stockUpPanel.Visible = false;
            orderHistoryPanel.Visible = false;
            sendOrderButton.Visible = false;

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = sender as CheckBox;

            if (currentCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes)
                {
                    if (checkBox != currentCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }
        public bool CheckVariebles(string Category, string ItemName, string Color)
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                MessageBox.Show("Item Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Color))
            {
                MessageBox.Show("Color cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(Category))
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }

        }

        public string CheckCategory()
        {
            if (hatCheckBox.Checked) { return "Hat"; }
            else if (coatsCheckBox.Checked) { return "Coats"; }
            else if (dressesCheckBox.Checked) { return "Dresses"; }
            else if (suitsCheckBox.Checked) { return "Suits"; }
            else if (accessoriesCheckBox.Checked) { return "Accessories"; }
            return null;
        }
        private void confirmRegisterNewUserButton_Click(object sender, EventArgs e)
        {
            string picturePath = "Pics/NoImage";
            string Category = CheckCategory();
            string Size;
            string ItemName = itemTextBox.Text;
            double Price;
            int Quantity = 0;
            string Color = colorTextBox.Text;

            bool allBoxesChecked = false;


            allBoxesChecked = CheckVariebles(Category, ItemName, Color);
            try
            {
                Price = Convert.ToInt32(priceTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (allBoxesChecked)
            {

                if (OneSize() || smallCheckBox.Checked || mediumCheckBox.Checked || LargeCheckBox.Checked)
                {

                    if (pictureBox1.Image != null)
                    {
                        picName = SaveImage();
                        picturePath = "Pics/" + picName;
                        RegisterItem(ItemName, Price, Quantity, Color, Category, picturePath);
                        registerNewItemPanel.Visible = false;
                    }
                    else
                    {
                        RegisterItem(ItemName, Price, Quantity, Color, Category, picturePath);
                        registerNewItemPanel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a size.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }
        public async void RegisterItem(string ItemName, double Price, int Quantity, string Color, string Category, string picturePath)
        {
            string Size;

            if (OneSize() == true)
            {
                Size = "One Size";

                Item item = new Item(ItemName, Price, Quantity, Size, Color, Category, picturePath);
                ItemManager.RegisterNewItem(item);

            }
            if (smallCheckBox.Checked)
            {

                Size = "S";
                Item item = new Item(ItemName, Price, Quantity, Size, Color, Category, picturePath);
                ItemManager.RegisterNewItem(item);

            }
            if (mediumCheckBox.Checked)
            {

                Size = "M";
                Item item = new Item(ItemName, Price, Quantity, Size, Color, Category, picturePath);
                ItemManager.RegisterNewItem(item);

            }
            if (LargeCheckBox.Checked)
            {
                Size = "L";
                Item item = new Item(ItemName, Price, Quantity, Size, Color, Category, picturePath);
                ItemManager.RegisterNewItem(item);

            }
        }
        public void PopulateStockUpNewItem(string ItemName, double Price, int Quantity, string Size, string Color, string Category)
        {
            stockUpItemNameTextBox.Text = ItemName;
            stockUpPricetextBox.Text = Price.ToString();
            stockUpSizetextBox.Text = Size;
            stockUpColortextBox.Text = Color;
            stockUpCategorytextBox.Text = Category;
            stockUpQuantitytextBox.Text = Quantity.ToString();
        }
        public bool OneSize()
        {

            if (oneSizeCheckBox.Checked)
            {
                smallCheckBox.Checked = false;
                mediumCheckBox.Checked = false;
                LargeCheckBox.Checked = false;
                smallCheckBox.Visible = false;
                mediumCheckBox.Visible = false;
                LargeCheckBox.Visible = false;

                return true;
            }
            if (oneSizeCheckBox.Checked == false)
            {
                smallCheckBox.Visible = true;
                mediumCheckBox.Visible = true;
                LargeCheckBox.Visible = true;

            }
            return false;
        }

        private void registerNewItemkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeItemButton.Visible = false;
            totaltSoldLabel.Visible = false;
            soldLabel.Visible = false;
            sendOrderButton.Visible = false;
            removeCostumerButton.Visible = false;
            editItemButton.Visible = false;
            mainPanel.Visible = false;
            stockUpButton.Visible = false;
            registerNewItemPanel.Visible = true;
            registerNewItemPanel.BringToFront();
        }

        private void oneSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OneSize();
        }
        private void SetTotalLabel()
        {
            int totalSold = 0;
            List<Item> items = ItemManager.GetItemList();
            foreach (Item item in items)
            {
                int intPrice = Convert.ToInt32(item.Price);
                totalSold += intPrice * item.SoldTotal;
            }
            totaltSoldLabel.Text = totalSold.ToString() + " KR";
        }

        private void productlistLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminListBox1.Items.Clear();
            removeItemButton.Visible = true;
            totaltSoldLabel.Visible = true;
            soldLabel.Visible = true;
            sendOrderButton.Visible = false;
            registerNewItemPanel.Visible = false;
            removeCostumerButton.Visible = false;
            editItemButton.Visible = true;
            stockUpButton.Visible = true;
            mainPanel.Visible = true;
            mainPanel.BringToFront();
            PopulateListBoxItem();
            SetTotalLabel();
        }
        public void PopulateListBoxItem()
        {
            List<Item> items = ItemManager.GetItemList();

            for (int i = 0; i < items.Count; i++)
            {
                double price = items[i].Price; price.ToString();
                int quantity = items[i].Quantity; quantity.ToString();
                int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                string formattedText = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);
                adminListBox1.Items.Add(formattedText);
            }


        }
        private void ChangeOrderLabels()
        {
            orderHistoryAdminlistBox.Items.Clear();
            adminListBox1.Items.Clear();
            removeItemButton.Visible = false;
            totaltSoldLabel.Visible = false;
            soldLabel.Visible = false;
            sendOrderButton.Visible = true;
            registerNewItemPanel.Visible = false;
            removeCostumerButton.Visible = false;
            editItemButton.Visible = false;
            stockUpButton.Visible = false;
            mainPanel.Visible = false;
            orderHistoryPanel.Visible = true;
            orderHistoryPanel.BringToFront();
            List<Order> orders = orderManager.GetOrders("AllOrders");
            foreach (Order order in orders)
            {
                if (order.FinishedOrder == "False")
                {
                    pendingOrders.Add(order);
                    int orderNo = order.OrderNo;
                    orderNo.ToString();
                    DateTime dateTime = order.Placedtime;
                    dateTime.ToString();

                    orderHistoryAdminlistBox.Items.Add(orderNo + "\t" + dateTime + "\t" + order.Username);
                }
            }

        }
        private void placedOrdersLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switchLists = true;
            ChangeOrderLabels();
        }
        private void orderHistoryAdminlistBox_MouseDown(object sender, MouseEventArgs e)
        {
            orderDetailsAdminListBox.Items.Clear();
            int index = orderHistoryAdminlistBox.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                orderHistoryAdminlistBox.SelectedIndex = index;
                if (switchLists == true)
                {


                    for (int j = 0; j < pendingOrders.Count; j++)
                    {
                        if (index == j)
                        {
                            List<Item> items = orderManager.GetItems(pendingOrders[j].OrderNo);
                            orderNoLabel.Text = pendingOrders[j].OrderNo.ToString();
                            for (int i = 0; i < items.Count; i++)
                            {
                                double price = items[i].Price; price.ToString();
                                int quantity = items[i].Quantity; quantity.ToString();
                                int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                                string formattedText = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);
                                orderDetailsAdminListBox.Items.Add(formattedText);
                            }
                        }
                    }
                }
                else if (switchLists == false)
                {
                    for (int j = 0; j < finishedOrders.Count; j++)
                    {
                        if (index == j)
                        {
                            List<Item> items = orderManager.GetItems(finishedOrders[j].OrderNo);
                            orderNoLabel.Text = finishedOrders[j].OrderNo.ToString();
                            for (int i = 0; i < items.Count; i++)
                            {
                                double price = items[i].Price; price.ToString();
                                int quantity = items[i].Quantity; quantity.ToString();
                                int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                                string formattedText = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);
                                orderDetailsAdminListBox.Items.Add(formattedText);
                            }
                        }
                    }
                }
            }

        }
        private void costumorLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeItemButton.Visible = false;
            totaltSoldLabel.Visible = false;
            soldLabel.Visible = false;
            sendOrderButton.Visible = false;
            registerNewItemPanel.Visible = false;
            mainPanel.Visible = true;
            removeCostumerButton.Visible = true;
            editItemButton.Visible = false;
            stockUpButton.Visible = false;
            mainPanel.BringToFront();
            PopulateListBoxUser();
        }
        public void PopulateListBoxUser()
        {
            adminListBox1.Items.Clear();
            adminListBox1.Refresh();
            List<User> users = UserManager.CreateUserList();

            for (int i = 0; i < users.Count; i++)
            {

                string formattedText = string.Format("{0,-15}\t{1,-25}\t{2,-15}\t{3,-30}\t{4,-35}\t{5}\t{6}",
                    users[i].UserName,
                    users[i].FirstName,
                    users[i].LastName,
                    users[i].Email,
                    users[i].Street,
                    users[i].Zip,
                    users[i].City);
                adminListBox1.Items.Add(formattedText);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (adminListBox1.SelectedIndex != -1)
            {
                List<User> users = UserManager.CreateUserList();
                for (int i = 0; i < users.Count; i++)
                {
                    //string user = users[i].UserName + "\t" + users[i].FirstName + "\t" + users[i].LastName + "\t" + users[i].Email + "\t" + users[i].Street + "\t" + users[i].Zip + "\t" + users[i].City;
                    string user = string.Format("{0,-15}\t{1,-25}\t{2,-15}\t{3,-30}\t{4,-35}\t{5}\t{6}",
                    users[i].UserName,
                    users[i].FirstName,
                    users[i].LastName,
                    users[i].Email,
                    users[i].Street,
                    users[i].Zip,
                    users[i].City);
                    string selectedItem = adminListBox1.SelectedItem.ToString();
                    if (selectedItem == user)
                    {
                        UserManager.RemoveUser(i);
                        adminListBox1.Items.Clear();
                        PopulateListBoxUser();
                    }
                }

            }
            else
            {
                MessageBox.Show("Ingen rad markerad.", "Meddelande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PopulateEditItem(int index)
        {
            List<Item> items = ItemManager.GetItemList();
            for (int i = 0; i < items.Count; i++)
            {
                if (index == i)
                {
                    editItemNameTextBox.Text = items[i].ItemName;
                    editPriceTextBox.Text = items[i].Price.ToString();
                    editSizetextBox.Text = items[i].Size;
                    editIColorTextBox.Text = items[i].Color;
                    editCategoryTextBox.Text = items[i].Category;
                    quantityTextBox.Text = items[i].Quantity.ToString();
                    pictureBoxEditItem.Image = Image.FromFile(items[i].PicturePath + ".png");
                    break;

                }
            }
        }

        private void editItemEditPanelButton_Click(object sender, EventArgs e)
        {

            string Size = editSizetextBox.Text;
            string ItemName = editItemNameTextBox.Text;
            double Price = double.Parse(editPriceTextBox.Text);
            int Quantity = int.Parse(quantityTextBox.Text);
            string Color = editIColorTextBox.Text;

            List<Item> items = ItemManager.GetItemList();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemName == ItemName && items[i].Size == Size)
                {
                    items[i].Price = Price;
                    items[i].Quantity = Quantity;
                    items[i].Color = Color;

                    ItemManager.RemoveFilePath();
                    foreach (Item item in items)
                    {
                        ItemManager.RegisterNewItem(item);
                    }
                }
            }
        }

        private void editItemButton_Click(object sender, EventArgs e)
        {
            if (adminListBox1.SelectedIndex != -1)
            {
                List<Item> items = ItemManager.GetItemList();
                for (int i = 0; i < items.Count; i++)
                {
                    double price = items[i].Price; price.ToString();
                    int quantity = items[i].Quantity; quantity.ToString();
                    int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                    string item = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);

                    if (adminListBox1.SelectedItem.ToString() == item)
                    {
                        totaltSoldLabel.Visible = false;
                        soldLabel.Visible = false;
                        mainPanel.Visible = false;
                        sendOrderButton.Visible = false;
                        removeCostumerButton.Visible = false;
                        editItemButton.Visible = false;
                        stockUpButton.Visible = false;
                        editItemPanel.Visible = true;
                        editItemPanel.BringToFront();
                        PopulateEditItem(i);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingen rad markerad.", "Meddelande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void PopulateStockUp(int index)
        {
            List<Item> items = ItemManager.GetItemList();
            for (int i = 0; i < items.Count; i++)
            {
                if (index == i)
                {
                    stockUpItemNameTextBox.Text = items[i].ItemName;
                    stockUpPricetextBox.Text = items[i].Price.ToString();
                    stockUpSizetextBox.Text = items[i].Size;
                    stockUpColortextBox.Text = items[i].Color;
                    stockUpCategorytextBox.Text = items[i].Category;
                    stockUpQuantitytextBox.Text = items[i].Quantity.ToString();
                    break;

                }
            }
        }

        private void stockUpButton_Click(object sender, EventArgs e)
        {
            if (adminListBox1.SelectedIndex != -1)
            {
                List<Item> items = ItemManager.GetItemList();
                for (int i = 0; i < items.Count; i++)
                {
                    double price = items[i].Price; price.ToString();
                    int quantity = items[i].Quantity; quantity.ToString();
                    int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                    string item = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);
                    string selection = adminListBox1.SelectedItem.ToString();
                    if (selection == item)
                    {
                        totaltSoldLabel.Visible = false;
                        soldLabel.Visible = false;
                        mainPanel.Visible = false;
                        removeCostumerButton.Visible = false;
                        editItemButton.Visible = false;
                        stockUpButton.Visible = false;

                        PopulateStockUp(i);
                        stockUpPanel.BringToFront();
                        stockUpPanel.Visible = true;

                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingen rad markerad.", "Meddelande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void stockUpButtonStockupPanel_Click(object sender, EventArgs e)
        {
            string ItemName = stockUpItemNameTextBox.Text;
            double Price = double.Parse(stockUpPricetextBox.Text);
            string Size = stockUpSizetextBox.Text;
            string Color = stockUpColortextBox.Text;
            string Category = stockUpCategorytextBox.Text;
            int Quantity = int.Parse(stockUpQuantitytextBox.Text);
            int incomming = int.Parse(incommingQuantity.Text);
            int newQuantity = Quantity + incomming;
            List<Item> items = ItemManager.GetItemList();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemName == ItemName && items[i].Size == Size)
                {
                    items[i].Quantity = newQuantity;
                    ItemManager.RemoveFilePath();
                    foreach (Item item in items)
                    {
                        ItemManager.RegisterNewItem(item);
                    }
                    break;
                }
            }

            incommingQuantity.Text = "";
            stockUpPanel.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            editItemPanel.Visible = false;
            mainPanel.Visible = true;
            mainPanel.BringToFront();
            removeCostumerButton.Visible = true;
            editItemButton.Visible = true;
            stockUpButton.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stockUpPanel.Visible = false;
            mainPanel.Visible = true;
            mainPanel.BringToFront();
            removeCostumerButton.Visible = true;
            editItemButton.Visible = true;
            stockUpButton.Visible = true;
        }
        private void DisplayImage(string imagePath)
        {
            try
            {

                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open Image",
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                DisplayImage(imagePath);
            }
        }

        public string SaveImage()
        {
            if (pictureBox1.Image != null)
            {
                string targetDirectory = "Pics";

                string fullPath = Path.Combine(targetDirectory, picName);

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                pictureBox1.Image.Save(fullPath);

                return fullPath;
            }
            else
            {
                return "Pics/NoImage";
            }

        }

        private void insertPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open Image",
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                DisplayImage(imagePath);
                picName = Path.GetFileName(imagePath);
            }
        }

        private void logOutAdminLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void sendOrderButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (orderHistoryAdminlistBox.SelectedItem != null)
            {
                int orderNo = Convert.ToInt32(orderNoLabel.Text);
                List<Item> itemsList = ItemManager.GetItemList();
                List<Item> orderItems = orderManager.GetItems(orderNo);
                List<Order> orders = orderManager.GetAllOrders();
                foreach (Item orderItem in orderItems)
                {
                    foreach (Item item in itemsList)
                    {
                        if (item.ItemName == orderItem.ItemName && item.Size == orderItem.Size && item.Color == orderItem.Color)
                        {
                            item.Quantity -= orderItem.Quantity;
                            item.SoldTotal++;
                            success = true;
                        }
                    }
                }
                if (success == true)
                {

                    foreach (Order order in orders)
                    {
                        if (order.OrderNo == orderNo)
                        {
                            order.FinishedOrder = "True";
                        }
                    }
                    ItemManager.SaveText(itemsList);
                    orderManager.SaveOrder(orders);
                    ChangeOrderLabels();
                }
                else if (success == false)
                {
                    MessageBox.Show("DIDNT WORKD");
                }
            }
            else
            {
                MessageBox.Show("Pick an order");
            }

        }

        private void finishedOrdersLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeItemButton.Visible = false;
            totaltSoldLabel.Visible = false;
            soldLabel.Visible = false;
            switchLists = false;
            orderNoLabel.Text = string.Empty;
            orderDetailsAdminListBox.Items.Clear();
            orderHistoryAdminlistBox.Items.Clear();
            adminListBox1.Items.Clear();
            sendOrderButton.Visible = false;
            registerNewItemPanel.Visible = false;
            removeCostumerButton.Visible = false;
            editItemButton.Visible = false;
            stockUpButton.Visible = false;
            mainPanel.Visible = false;
            orderHistoryPanel.Visible = true;
            orderHistoryPanel.BringToFront();
            List<Order> orders = orderManager.GetOrders("AllOrders");
            foreach (Order order in orders)
            {
                if (order.FinishedOrder == "True")
                {
                    int orderNo = order.OrderNo;
                    orderNo.ToString();
                    DateTime dateTime = order.Placedtime;
                    dateTime.ToString();
                    finishedOrders.Add(order);
                    orderHistoryAdminlistBox.Items.Add(orderNo + "\t" + dateTime + "\t" + order.Username);
                }
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if (adminListBox1.SelectedIndex != -1)
            {
                List<Item> items = ItemManager.GetItemList();
                for (int i = 0; i < items.Count; i++)
                {
                    double price = items[i].Price; price.ToString();
                    int quantity = items[i].Quantity; quantity.ToString();
                    int soldtotal = items[i].SoldTotal; soldtotal.ToString();
                    string item = string.Format("{0,-20}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", items[i].ItemName, price, quantity, items[i].Size, items[i].Color, soldtotal, items[i].Category);
                    if (adminListBox1.SelectedItem.ToString() == item)
                    {
                        ItemManager.RemoveItem(i);
                        adminListBox1.Items.Clear();
                        PopulateListBoxItem();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingen rad markerad.", "Meddelande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
