using Microsoft.VisualBasic.ApplicationServices;

namespace SOSFashion
{
    public partial class LogInForm : Form
    {
        UserManager userManager = new UserManager();
        List<User> users;
        MainForm mainForm;
        public LogInForm(MainForm mainForm)
        {
            InitializeComponent();
            LogInPanel.BringToFront();
            this.BackgroundImage = Image.FromFile("Pics/LogIn.jpg");
            this.mainForm = mainForm;
            userLable.TextAlign = ContentAlignment.MiddleLeft;
        }

        public User RegisterNewUser()
        {
            newUserNameLable.Text = registerNewUserNameTextBox.Text;
            string UserName = registerNewUserNameTextBox.Text;
            string Password = registerNewPasswordTextBox.Text;
            string FirstName = registerFirstNameTextBox.Text;
            string LastName = registerLastNameTextBox.Text;
            string Email = registerEmailTextBox.Text;
            string Street = registerStreetTextBox.Text;
            string Zip = registerZipTextBox.Text;
            string City = registerCityTextBox.Text;


            User user = new User(UserName, Password, FirstName, LastName, Email, Street, Zip, City);
            return user;

        }

        private void registerNewUserButton_Click(object sender, EventArgs e)
        {
            chooseUserNamePasswordPanel.BringToFront();

        }

        private void cancelRegisterNewUserButton_Click(object sender, EventArgs e)
        {
            LogInPanel.BringToFront();
        }

        private void confirmRegisterNewUserButton_Click(object sender, EventArgs e)
        {
            User user = RegisterNewUser();
            userManager.RegisterNewUser(user);
            LogInPanel.BringToFront();

        }

        private void cancelRegisterUserButton_Click(object sender, EventArgs e)
        {
            LogInPanel.BringToFront();
        }

        private void registerUserPasswordButton_Click(object sender, EventArgs e)
        {
            if (CheckUserName() && CheckPassword())
            {
                registerNewUserPanel.BringToFront();
                newUserNameLable.Text = registerNewUserNameTextBox.Text;

            }
            else
            {
                chooseUserNamePasswordPanel.BringToFront();
            }
            newUserNameLable.Text = registerNewUserNameTextBox.Text;

        }
        private bool CheckPassword()
        {
            if (registerNewPasswordTextBox.Text != verifyNewPasswordTextBox.Text)
            {

                MessageBox.Show("Your Passwords doesnt match");
                return false;
            }
            return true;
        }
       private bool CheckUserName()
        {
            List<User> users = userManager.CreateUserList();
            foreach (User user in users)
            {
                if (user.UserName == registerNewUserNameTextBox.Text)
                {
                    MessageBox.Show("This User Name is not avalible");
                    return false;
                }

            }
            return true;
        }


        private User CheckLoggIn()
        {
            users = userManager.CreateUserList();
            foreach (User user in users)
            {
                if (UserNameTextBox.Text == user.UserName && passwordTextBox.Text == user.Password)
                {
                    return user;
                    break;
                }
            }
            return null;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            User user = CheckLoggIn();
            if (user == null)
            {
                MessageBox.Show("Invali UserId / Password");
                passwordTextBox.Clear();
            }
            else if (user.FirstName == "Admin")
            {
                UserNameTextBox.Clear();
                passwordTextBox.Clear();
                this.Hide();
                AdminForm form = new AdminForm();
                form.Show();
            }
            else
            {
                UserNameTextBox.Clear();
                passwordTextBox.Clear();
                this.Hide();
                UserPage userPage = new UserPage(user, mainForm);
                userPage.Show();

            }

        }


    }

}