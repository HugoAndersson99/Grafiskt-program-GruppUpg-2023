using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOSFashion
{
    public partial class ShopForm : Form
    {
        UserManager UserManager = new UserManager();
        ItemManager itemManager = new ItemManager();
        bool kundvagn = false;
        string size = string.Empty;
        string pictureFilePath = string.Empty;
        string itemsFilePath = "Items/Items.csv";
        List<Item> itemsList = new List<Item>();
        List<Item> kundvagnList = new List<Item>();
        MainForm mainForm;

        public ShopForm(MainForm mainForm)
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Pics/ShopForm.png");
            this.mainForm = mainForm;
            using (StreamReader reader = new StreamReader(itemsFilePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    try
                    {
                        string[] strings = line.Split(";");
                        string name = strings[0];
                        double price = Convert.ToInt32(strings[1]);
                        int amountStock = Convert.ToInt32(strings[2]);
                        string size = strings[3];
                        string color = strings[4];
                        int amountSold = Convert.ToInt32(strings[5]);
                        string category = strings[6];
                        string picturePath = strings[7];


                        itemsList.Add(new Item(name, price, amountStock, size, color, amountSold, category, picturePath));
                        line = reader.ReadLine();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public void ChangePanel(string name, string color, string size)
        {
            foreach (Item items in itemsList)
            {
                if (items.ItemName == name && items.Color == color && items.Size == size)
                {
                    nameLabel.Text = items.ItemName;
                    priceLabel.Text = items.Price.ToString();
                    colorLabel.Text = items.Color;
                    sizeLabel.Text = items.Size;
                    pictureFilePath = items.PicturePath + ".png";
                    mainPictureBox.Image = Image.FromFile(pictureFilePath);

                }
            }
            itemsPanel.Visible = true;
        }

        private void ChooseCategory(string category)
        {
            categoryListBox.Items.Clear();
            itemsList = itemManager.GetItemList();
            foreach (Item item in itemsList)
            {
                if (item.Category == category)
                {
                    categoryListBox.Items.Add(item.ItemName + " " + item.Color + " " + item.Size);
                }
            }
            categoryListBox.Visible = true;
        }

        private void removeKundvagnButton_Click(object sender, EventArgs e)
        {
            if (KundvagnlistBox.SelectedItem != null)
            {
                string listBoxToString = KundvagnlistBox.SelectedItem.ToString();
                foreach (Item item in kundvagnList)
                {
                    string kundvagnItemToString = item.ItemName + " STL " + item.Size + " " + "Price: " + item.Price + "kr";
                    if (listBoxToString == kundvagnItemToString)
                    {
                        kundvagnList.Remove(item);
                        KundvagnlistBox.Items.Remove(KundvagnlistBox.SelectedItem);
                        UpdateTotalCostLabel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must choose an item in your cart first!");
            }
        }


        public void GetItem(string ItemName)
        {
            foreach (Item item in itemsList)
            {
                if (item.ItemName == ItemName)
                {
                    if (item.Size == size)
                    {

                        break;
                    }
                }
            }

        }

        private void UpdateTotalCostLabel()
        {
            double totalCost = CalculateTotalCost();

            totalcostlabel.Text = $"Total Cost: {totalCost} kr";
        }

        private double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (Item item in kundvagnList)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text == "Log In")
            {
                LogInForm logInForm = new LogInForm(mainForm);
                logInForm.Show();
                this.Close();
            }
            else
            {
                List<User> users = UserManager.CreateUserList();

                foreach (User user in users)
                {
                    if (user.UserName == logInButton.Text)
                    {
                        this.Hide();
                        UserPage userPage = new UserPage(user, mainForm);
                        userPage.Show();
                    }
                }
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            logOutButton.Hide();
            logInButton.Text = "Log In";
            
            mainForm.mainLogInButton.Text = "Log In";
            mainForm.logOutButton.Hide();
            mainForm.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text == "Log In")
            {
                mainForm.mainLogInButton.Text = "Log In";
                mainForm.logOutButton.Visible = false;
                mainForm.Show();
                this.Close();
            }
            else
            {
                mainForm.Show();
                this.Close();
            }
            
        }

        private void purchasebutton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text == "Log In")
            {
                MessageBox.Show("Please log in before making a purchase.");
                LogInForm logInForm = new LogInForm(mainForm);
                logInForm.Show();
                this.Hide();

            }
            else
            {
                //double totalCost = CalculateTotalCost();
                //MessageBox.Show($"Thank you for your purchase! Total Cost: {totalCost} kr");
                //

                Checkout checkout = new Checkout(kundvagnList, mainForm);

                checkout.CalculateTotalCost();
                checkout.userButton.Text = logInButton.Text;
                checkout.GetUser();
                checkout.Show();
                this.Close();
            }
            KundvagnlistBox.Items.Clear();
            UpdateTotalCostLabel();
        }


        private void hatsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string choice = "Hats";
            ChooseCategory(choice);
        }

        private void suitsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string choice = "Suits";
            ChooseCategory(choice);

        }

        private void coatsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string choice = "Coats";
            ChooseCategory(choice);
        }

        private void dressesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string choice = "Dresses";
            ChooseCategory(choice);
        }

        private void accessoriesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string choice = "Accessories";
            ChooseCategory(choice);
        }

        private void categoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedItem != null)
            {
                string choosenItem = categoryListBox.SelectedItem.ToString();
                itemsList = itemManager.GetItemList();
                foreach (Item item in itemsList)
                {
                    string str = item.ItemName + " " + item.Color + " " + item.Size;
                    if (choosenItem == str)
                    {
                        ChangePanel(item.ItemName, item.Color, item.Size);
                    }
                }

            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            if (logInButton.Text != "Log In")
            {


                foreach (Item item in itemsList)
                {
                    if (item.ItemName == nameLabel.Text && item.Color == colorLabel.Text && item.Size == sizeLabel.Text)
                    {
                        KundvagnlistBox.Items.Add(item.ItemName + " STL " + item.Size + " " + "Price: " + item.Price + "kr");
                        int newQuantity = 1;
                        Item newItem = new Item(item.ItemName, item.Price, newQuantity, item.Size, item.Color, item.Category, item.PicturePath);

                        kundvagnList.Add(newItem);
                        UpdateTotalCostLabel();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must log in before adding to cart!");
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

        }
    }
}
