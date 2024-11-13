using Microsoft.Win32;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }
        public Login(User user) {
            InitializeComponent();
            txtUsername.Text = user.Username;
            txtPassword.Password = user.Password;
        }
        TaskManagementContext context = new TaskManagementContext();
        public bool IsLoginSuccessful { get; private set; }
        public User LoggedInUser { get; private set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            String name = txtUsername.Text;
            if ( name.Contains("@gmail.com") ) {
                var user = context.Users.FirstOrDefault(u => u.Email.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Password));
                if ( user != null ) {
                    IsLoginSuccessful = true;
                    LoggedInUser = user;
                    MainWindow main = new MainWindow(user);
                    main.Show();
                    this.Close();
                } else {
                    MessageBox.Show("Fail");
                }
            } else {
                var user = context.Users.FirstOrDefault(u => u.Username.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Password));
                if ( user != null ) {
                    IsLoginSuccessful = true;
                    LoggedInUser = user;
                    MainWindow main = new MainWindow(user);
                    main.Show();
                    this.Close();
                } else {
                    MessageBox.Show("Fail");
                }
            }

        }

        private Register registerWindow;

        private void btnRegister_Click(object sender, RoutedEventArgs e) {

            if ( registerWindow == null || !registerWindow.IsVisible ) {
                registerWindow = new Register();
                registerWindow.Show();
                this.Close();
            } else {
                registerWindow.Activate();
            }
        }
    }
}
