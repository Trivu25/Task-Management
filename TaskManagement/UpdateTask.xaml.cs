using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window {
        TaskManagementContext context = new TaskManagementContext();
        private Models.Task currentTask;
        private User user;

        public UpdateTask(Models.Task task, User user) {
            InitializeComponent();
            currentTask = task;
            this.user = user;
            LoadTaskDetails();
        }

        private void LoadTaskDetails() {
            txtTitle.Text = currentTask.Title;
            txtDescription.Text = currentTask.Description;
            dpkDueDate.SelectedDate = currentTask.DueDate ?? DateTime.Now;

            switch ( currentTask.Priority ) {
                case 1:
                    rbP1.IsChecked = true;
                    break;
                case 2:
                    rbP2.IsChecked = true;
                    break;
                case 3:
                    rbP3.IsChecked = true;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            currentTask.Title = txtTitle.Text;
            currentTask.Description = txtDescription.Text;
            currentTask.DueDate = dpkDueDate.SelectedDate;
            currentTask.User = user;
            

            if ( rbP1.IsChecked == true )
                currentTask.Priority = 1;
            else if ( rbP2.IsChecked == true )
                currentTask.Priority = 2;
            else if ( rbP3.IsChecked == true )
                currentTask.Priority = 3;
            
            context.SaveChanges();
            MessageBox.Show("Task updated successfully!");
            this.Close();
        }

		private void btnDone_Click(object sender, RoutedEventArgs e)
		{

			Models.Task task = new Models.Task();
			string startus = "Done";
			currentTask.Title = txtTitle.Text;
			currentTask.Description = txtDescription.Text;
			currentTask.DueDate = dpkDueDate.SelectedDate;
			currentTask.User = user;
            task.Status = startus;


			if (rbP1.IsChecked == true)
				currentTask.Priority = 1;
			else if (rbP2.IsChecked == true)
				currentTask.Priority = 2;
			else if (rbP3.IsChecked == true)
				currentTask.Priority = 3;

            

			context.SaveChanges();
			MessageBox.Show("Task is done !");
			this.Close();
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			txtTitle.Text = currentTask.Title;
			txtDescription.Text = currentTask.Description;
			dpkDueDate.SelectedDate = currentTask.DueDate;
		}
	}
}
