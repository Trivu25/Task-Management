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
    /// Interaction logic for TimeLeft.xaml
    /// </summary>
    public partial class TimeLeft : Window {
        public TimeLeft() {
            InitializeComponent();
        }
        private User LoggedInUser;
        private Models.Task CurrentTask;

        public TimeLeft(Models.Task task, User user) {
            InitializeComponent();
            CurrentTask = task;
            LoggedInUser = user;
            CalculateTimeLeft();
        }

        private void CalculateTimeLeft() {
            TimeSpan timeLeft = CurrentTask.DueDate.Value - DateTime.Now;
            lblTimeLeft.Content = $"Time left: {timeLeft.Days} days, {timeLeft.Hours} hours, {timeLeft.Minutes} minutes";
        }

    }
}
