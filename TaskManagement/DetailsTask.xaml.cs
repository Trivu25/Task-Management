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
    /// Interaction logic for DetailsTask.xaml
    /// </summary>
    public partial class DetailsTask : Window {
        public DetailsTask() {
            InitializeComponent();
        }
        public DetailsTask(Models.Task task, User user) {
            InitializeComponent();
            CurrentTask = task;
            LoggedInUser = user;
            LoadData(task, user);
        }
        TaskManagementContext data = new TaskManagementContext();
        private void LoadData(Models.Task task, User user) {
            String Priority = "";
            var Tdata = data.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            if ( Tdata == null ) {
                MessageBox.Show("Task not found!");
            } else {
                if ( Tdata.Priority == 1 ) {
                    Priority = Tdata.Priority + " - Công việc có độ ưu tiên Cao nhất!";
                } else if ( Tdata.Priority == 2 ) {
                    Priority = Tdata.Priority + " - Công việc có độ ưu tiên Trung bình!";
                } else if ( Tdata.Priority == 3 ) {
                    Priority = Tdata.Priority + " - Công việc có độ ưu tiên Thấp!";

                }
                txtTitle.Text = Tdata.Title;
                txtDescription.Text = Tdata.Description;
                txtDueDate.Text = Tdata.DueDate.ToString();
                txtPriority.Text = Priority.ToString();
                if ( Tdata.Status == "Done" ) {
                    cbStatus.IsChecked = true;
                    cbStatus.Content = "Completed";

                } else if ( Tdata.Status == "Expired" ) {
                    cbStatus.IsChecked = false;
                    cbStatus.Content = "Expired";

                } else {
                    cbStatus.IsChecked = false;
                    cbStatus.Content = "Pending";
                }
                txtCreate.Text = Tdata.CreatedOn.ToString();
                txtModify.Text = Tdata.ModifiedOn.ToString();

            }

        }

        private Models.Task CurrentTask;
        private User LoggedInUser;

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
