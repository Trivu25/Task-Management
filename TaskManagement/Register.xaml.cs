using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManagement.Models;

namespace TaskManagement {
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window {
        TaskManagementContext context = new TaskManagementContext();

		


		public Register() {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
			var existingUser = context.Users.FirstOrDefault(u => u.Username == txtUsername.Text);
            if ((existingUser != null))
            {
                MessageBox.Show("Account already haved");
                this.Show();
            }
            else
            {
				var newUser = new User
				{
					Username = txtUsername.Text,
					Password = txtPassword.Password,
					Email = txtEmail.Text
				};

				context.Users.Add(newUser);
				context.SaveChanges();
				MessageBox.Show("Registration successful!");
			}
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

    }

}

