namespace SOSFashion
{
    partial class UserPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newUserNameLable = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            OrderHistory = new ListBox();
            cityLable = new Label();
            zipLable = new Label();
            streetLable = new Label();
            emailLable = new Label();
            firstNameLable = new Label();
            lastNameLable = new Label();
            UserNameLable = new Label();
            passwordLable = new Label();
            showPasswordButton = new Button();
            leaveUserPageButton = new Button();
            orderDetailsListBox = new ListBox();
            SuspendLayout();
            // 
            // newUserNameLable
            // 
            newUserNameLable.BackColor = SystemColors.Control;
            newUserNameLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            newUserNameLable.Location = new Point(152, 33);
            newUserNameLable.Name = "newUserNameLable";
            newUserNameLable.Size = new Size(152, 30);
            newUserNameLable.TabIndex = 33;
            newUserNameLable.Text = "User Name";
            newUserNameLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(34, 242);
            label11.Name = "label11";
            label11.Size = new Size(110, 30);
            label11.TabIndex = 32;
            label11.Text = "City";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(34, 207);
            label10.Name = "label10";
            label10.Size = new Size(110, 30);
            label10.TabIndex = 31;
            label10.Text = "Zip";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.BackColor = SystemColors.Control;
            label9.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(34, 172);
            label9.Name = "label9";
            label9.Size = new Size(110, 30);
            label9.TabIndex = 30;
            label9.Text = "Street";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.Control;
            label8.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(34, 137);
            label8.Name = "label8";
            label8.Size = new Size(110, 30);
            label8.TabIndex = 29;
            label8.Text = "Email";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.BackColor = SystemColors.Control;
            label7.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(34, 67);
            label7.Name = "label7";
            label7.Size = new Size(110, 30);
            label7.TabIndex = 23;
            label7.Text = "First Name";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(34, 102);
            label4.Name = "label4";
            label4.Size = new Size(110, 30);
            label4.TabIndex = 21;
            label4.Text = "Last Name";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(34, 32);
            label5.Name = "label5";
            label5.Size = new Size(110, 30);
            label5.TabIndex = 20;
            label5.Text = "User Name";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrderHistory
            // 
            OrderHistory.Font = new Font("Modern No. 20", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            OrderHistory.FormattingEnabled = true;
            OrderHistory.ItemHeight = 18;
            OrderHistory.Location = new Point(396, 32);
            OrderHistory.Name = "OrderHistory";
            OrderHistory.Size = new Size(300, 328);
            OrderHistory.TabIndex = 34;
            OrderHistory.MouseDown += OrderHistory_MouseDown;
            // 
            // cityLable
            // 
            cityLable.BackColor = SystemColors.Control;
            cityLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            cityLable.Location = new Point(150, 243);
            cityLable.Name = "cityLable";
            cityLable.Size = new Size(240, 30);
            cityLable.TabIndex = 41;
            cityLable.Text = "City";
            cityLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zipLable
            // 
            zipLable.BackColor = SystemColors.Control;
            zipLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            zipLable.Location = new Point(150, 208);
            zipLable.Name = "zipLable";
            zipLable.Size = new Size(240, 30);
            zipLable.TabIndex = 40;
            zipLable.Text = "Zip";
            zipLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // streetLable
            // 
            streetLable.BackColor = SystemColors.Control;
            streetLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            streetLable.Location = new Point(150, 173);
            streetLable.Name = "streetLable";
            streetLable.Size = new Size(240, 30);
            streetLable.TabIndex = 39;
            streetLable.Text = "Street";
            streetLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // emailLable
            // 
            emailLable.BackColor = SystemColors.Control;
            emailLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            emailLable.Location = new Point(150, 138);
            emailLable.Name = "emailLable";
            emailLable.Size = new Size(240, 30);
            emailLable.TabIndex = 38;
            emailLable.Text = "Email";
            emailLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // firstNameLable
            // 
            firstNameLable.BackColor = SystemColors.Control;
            firstNameLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            firstNameLable.Location = new Point(150, 68);
            firstNameLable.Name = "firstNameLable";
            firstNameLable.Size = new Size(240, 30);
            firstNameLable.TabIndex = 37;
            firstNameLable.Text = "First Name";
            firstNameLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lastNameLable
            // 
            lastNameLable.BackColor = SystemColors.Control;
            lastNameLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lastNameLable.Location = new Point(150, 103);
            lastNameLable.Name = "lastNameLable";
            lastNameLable.Size = new Size(240, 30);
            lastNameLable.TabIndex = 36;
            lastNameLable.Text = "Last Name";
            lastNameLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UserNameLable
            // 
            UserNameLable.BackColor = SystemColors.Control;
            UserNameLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            UserNameLable.Location = new Point(150, 33);
            UserNameLable.Name = "UserNameLable";
            UserNameLable.Size = new Size(240, 30);
            UserNameLable.TabIndex = 35;
            UserNameLable.Text = "User Name";
            UserNameLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordLable
            // 
            passwordLable.BackColor = SystemColors.Control;
            passwordLable.Font = new Font("Modern No. 20", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            passwordLable.Location = new Point(222, 296);
            passwordLable.Name = "passwordLable";
            passwordLable.Size = new Size(110, 32);
            passwordLable.TabIndex = 43;
            passwordLable.Text = "****";
            passwordLable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // showPasswordButton
            // 
            showPasswordButton.Font = new Font("Modern No. 20", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            showPasswordButton.Location = new Point(34, 296);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(171, 32);
            showPasswordButton.TabIndex = 44;
            showPasswordButton.Text = "Show Password";
            showPasswordButton.UseVisualStyleBackColor = true;
            showPasswordButton.MouseDown += showPasswordButton_MouseDown;
            showPasswordButton.MouseLeave += showPasswordButton_MouseLeave;
            // 
            // leaveUserPageButton
            // 
            leaveUserPageButton.Font = new Font("Modern No. 20", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            leaveUserPageButton.Location = new Point(34, 387);
            leaveUserPageButton.Name = "leaveUserPageButton";
            leaveUserPageButton.Size = new Size(171, 32);
            leaveUserPageButton.TabIndex = 45;
            leaveUserPageButton.Text = "Leave userpage";
            leaveUserPageButton.UseVisualStyleBackColor = true;
            leaveUserPageButton.Click += leaveUserPageButton_Click;
            // 
            // orderDetailsListBox
            // 
            orderDetailsListBox.Font = new Font("Modern No. 20", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            orderDetailsListBox.FormattingEnabled = true;
            orderDetailsListBox.ItemHeight = 18;
            orderDetailsListBox.Location = new Point(702, 33);
            orderDetailsListBox.Name = "orderDetailsListBox";
            orderDetailsListBox.Size = new Size(495, 328);
            orderDetailsListBox.TabIndex = 46;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1223, 450);
            Controls.Add(orderDetailsListBox);
            Controls.Add(leaveUserPageButton);
            Controls.Add(showPasswordButton);
            Controls.Add(passwordLable);
            Controls.Add(cityLable);
            Controls.Add(zipLable);
            Controls.Add(streetLable);
            Controls.Add(emailLable);
            Controls.Add(firstNameLable);
            Controls.Add(lastNameLable);
            Controls.Add(UserNameLable);
            Controls.Add(OrderHistory);
            Controls.Add(newUserNameLable);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label5);
            Name = "UserPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserPage";
            ResumeLayout(false);
        }

        #endregion

        private Label newUserNameLable;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label5;
        private ListBox OrderHistory;
        private Label cityLable;
        private Label zipLable;
        private Label streetLable;
        private Label emailLable;
        private Label firstNameLable;
        private Label lastNameLable;
        private Label UserNameLable;
        private Label passwordLable;
        private Button showPasswordButton;
        private Button leaveUserPageButton;
        private ListBox orderDetailsListBox;
    }
}