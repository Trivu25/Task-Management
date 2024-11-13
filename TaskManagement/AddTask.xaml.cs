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
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window {
        public AddTask() {
            InitializeComponent();
        }
        public AddTask(User user) {
            InitializeComponent();
            LoggedInUser = user;

        }
        private User LoggedInUser;
        TaskManagementContext data = new TaskManagementContext();

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                String title = txtTitle.Text;
                String description = txtDescription.Text;
                DateTime dueDate = dpkDueDate.SelectedDate.Value;

                String status = "Pending";

                int priority = 0;
                if ( rbP1.IsChecked == true )
                    priority = 1;
                else if ( rbP2.IsChecked == true )
                    priority = 2;
                else if ( rbP3.IsChecked == true )
                    priority = 3;

                if ( title.Length == 0 || description.Length == 0 ) {
                    MessageBox.Show("Hãy chọn Title và Description!");
                    return;
                } else if ( priority == 0 ) {
                    MessageBox.Show("Hãy chọn mức độ ưu tiên (Priority) !");
                } else if ( dueDate < DateTime.Now ) {
                    MessageBox.Show("Ngày hết hạn đã qua!");
                } else {
                    Models.Task task = new Models.Task();
                    task.Title = title;
                    task.Description = description;
                    task.DueDate = dueDate;
                    task.Priority = priority;
                    task.Status = status;
                    task.UserId = LoggedInUser.UserId;
                    data.Tasks.Add(task);
                    if ( data.SaveChanges() > 0 ) {
                        MessageBox.Show("Task đã được thêm thành công!");
                        this.Close();
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show("Hãy chọn ngày hết hạn!");
            }
        }
    }
}
