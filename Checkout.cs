using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOSFashion
{
    public partial class Checkout : Form
    {
        User User;
        OrderManager orderManager = new OrderManager();
        UserManager userManager = new UserManager();
        List<Item> kundvagnList;
        MainForm mainform;
        public Checkout(List<Item> list, MainForm mainForm)
        {
            InitializeComponent();
            LoadShippingPaymentOptions();
            this.BackgroundImage = Image.FromFile("Pics/CheckOut.png");
            this.kundvagnList = list;
            this.mainform = mainForm;
        }
        //public void GetList(List<Item> list)
        //{
        //    kundvagnList = list;
        //}


        private void LoadShippingPaymentOptions()
        {

            comboBoxShipping.Items.Add("Standard Shipping");
            comboBoxShipping.Items.Add("Express Shipping");

            comboBoxPayment.Items.Add("Credit Card");
            comboBoxPayment.Items.Add("PayPal");
        }

        public void CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (Item item in kundvagnList)
            {
                totalCost += item.Price;
            }
            totalCostLabel.Text = $"Total Cost: {totalCost} kr";
        }
        public void GetUser()
        {
            List<User> users = userManager.CreateUserList();

            foreach (User user in users)
            {
                if (user.UserName == userButton.Text)
                {
                    User = user;
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;
                    textemail.Text = user.Email;
                    txtZipCode.Text = user.Zip;
                    txtCity.Text = user.City;
                    txtstreet.Text = user.Street;
                }
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtFirstName.Text;
            string name2 = txtLastName.Text;
            string address = txtstreet.Text;
            string email = textemail.Text;
            string zipCode = txtZipCode.Text;
            string phone = txtCity.Text;

            int OrderNo = orderManager.CreateNewOrder(User);
            orderManager.CreateItemList(OrderNo, kundvagnList);
            kundvagnList.Clear();
            MessageBox.Show("Order confirmed! Thank you for your purchase.", "Order Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UserPage userPage = new UserPage(User, mainform);
            userPage.Show();
            this.Close();
        }


    }
}
