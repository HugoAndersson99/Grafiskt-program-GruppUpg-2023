using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOSFashion
{
    public partial class MainForm : Form
    {
        User User { get; set; }
        UserManager userManager = new UserManager();
        public MainForm()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("Pics/EnLL5-EXMAABrTn.jpg");
            button1.Image = Image.FromFile("Pics/Assortment.png");
        }


        public void mainLogInButton_Click(object sender, EventArgs e)
        {
            if (mainLogInButton.Text == "Log In")
            {
                this.Hide();
                LogInForm logInForm = new LogInForm(this);
                logInForm.Show();
            }
            else
            {
                List<User> users = userManager.CreateUserList();

                foreach (User user in users)
                {
                    if (user.UserName == mainLogInButton.Text)
                    {
                        this.Hide();
                        UserPage userPage = new UserPage(user, this);
                        userPage.Show();
                    }
                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mainLogInButton.Text == "Log In")
            {
                this.Hide();
                ShopForm shopForm = new ShopForm(this);
                shopForm.logInButton.Text = "Log In";
                shopForm.Show();
            }
            else
            {
                ShopForm shopForm1 = new ShopForm(this);
                shopForm1.logInButton.Text = mainLogInButton.Text;
                shopForm1.logOutButton.Show();
                logOutButton.Show();
                shopForm1.Show();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            logOutButton.Hide();
            mainLogInButton.Text = "Log In";
        }


    }
}
