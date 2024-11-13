using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Windows.Threading;
using TaskManagement.Models;

namespace TaskManagement {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            ShowLoginWindow();
            this.Close();
        }
        public MainWindow(User user) {

            InitializeComponent();
            this.Title = user.Username;
            LoggedInUser = user;
            lbUsername.Content = user.Username;
            CountTask(user);
            // Load data
            LoadTasks(user);
            searchTimer = new DispatcherTimer();
            searchTimer.Interval = TimeSpan.FromMilliseconds(500); // 0.5 giây
            searchTimer.Tick += SearchTimer_Tick;
        }
        private void CountTask(User user) {
            int totalTask = data.Tasks.Count(t => t.UserId == user.UserId);
            int PendingTask = data.Tasks.Count(t => t.UserId == user.UserId && t.Status.Equals("Pending"));
            int ExpiredTask = data.Tasks.Count(t => t.UserId == user.UserId && t.Status.Equals("Expired "));
            int DoneTask = data.Tasks.Count(t => t.UserId == user.UserId && t.Status.Equals("Done"));
            lbTotalTask.Content = totalTask + " Task";
            lbETask.Content = ExpiredTask + " Task";
            lbPTask.Content = PendingTask + " Task";
            lbFTask.Content = DoneTask + " Task";

        }
        private User LoggedInUser;
        TaskManagementContext data = new TaskManagementContext();
        private void LoadTasks(User user) {

            CountTask(user);
            var Tdata = data.Tasks
                .Where(t => t.UserId == user.UserId)
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderByDescending(t => t.Status)
                .ThenBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();


            DateTime currentDate = DateTime.Now;
            List<String> Deadline = new List<string>();
            List<String> EndTasks = new List<string>();
			
			foreach ( var task in Tdata ) {
                String deadline = $" {task.Id} - {task.Title}";
                if ( task.DueDate.Value.Date <= currentDate.AddDays(1).Date && task.DueDate.Value.Date > currentDate.Date && task.Status.Equals("Pending") ) {
                    if ( task.Priority == 1 ) {
                        deadline += " - Ưu tiên: High ";
                    } else if ( task.Priority == 2 ) {
                        deadline += " - Ưu tiên: Normal ";

                    } else if ( task.Priority == 3 ) {
                        deadline += " - Ưu tiên: Low ";
                    }
                    Deadline.Add(deadline + $"(hạn vào ngày {task.DueDate.Value.ToShortDateString()})");
                } else if ( task.DueDate.Value.Date <= currentDate.Date && task.Status.Equals("Pending") ) {
                    Models.Task Utask = data.Tasks.FirstOrDefault(t => t.TaskId == task.Id);
                    Utask.Status = "Expired";
                    data.Tasks.Update(Utask);
                    data.SaveChanges();
                    EndTasks.Add($" {task.Id} - {task.Title} (đã hết hạn ngày {task.DueDate.Value.ToShortDateString()})");
                } else if ( task.Status.Equals("Expired") ) {
                    EndTasks.Add($" {task.Id} - {task.Title} (đã hết hạn ngày {task.DueDate.Value.ToShortDateString()})");
                }
            }
			
			if ( Deadline.Count > 0 ) {
                string message = "Các task sau đây sắp hết hạn:\n\n" + string.Join("\n", Deadline);
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if ( EndTasks.Count > 0 ) {
                string message = "Các task sau đây đã hết hạn:\n\n" + string.Join("\n", EndTasks);
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
			dgTask.ItemsSource = Tdata;

		}
        private void ReLoadTasks(User user) {
            CountTask(user);
            var Tdata = data.Tasks
                .Where(t => t.UserId == user.UserId)
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderByDescending(t => t.Status)
                .ThenBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;

        }
        private void ShowLoginWindow() {
            var loginWindow = new Login();
            loginWindow.ShowDialog();

        }
        private void ButtonLogout_Click(object sender, RoutedEventArgs e) {
            if ( MessageBox.Show("Do you want to Logout?", "Comfirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes ) {
                var loginwindow = new Login();
                loginwindow.Show();
                this.Close();

            }
        }
        private static bool TaskbarController = true;
        //private void taskbarControl_Click(object sender, RoutedEventArgs e) {
        //    if ( TaskbarController ) {
        //        taskbar.Width = new GridLength(150);
        //        taskbarControl.Content = "<";
        //        TaskbarController = false;
        //    } else {
        //        taskbar.Width = new GridLength(0);
        //        taskbarControl.Content = ">";
        //        TaskbarController = true;
        //    }

        //}
        private void ButtonReload_Click(object sender, RoutedEventArgs e) {
            LoadTasks(LoggedInUser);
        }
        private UpdateTask update;
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e) {
            try {
                Button button = sender as Button;
                int taskId = (int)button.CommandParameter;

                Models.Task task = data.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if ( task.DueDate.Value < DateTime.Now ) {
                    MessageBox.Show("Task đã hết hạn, không thể chỉnh sửa!");
                } else {
                    if ( update == null || !update.IsVisible ) {
                        update = new UpdateTask(task, LoggedInUser);
                        update.Closed += UpdateTask_Closed;
                        update.Show();
                    } else {
                        update.Activate();
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateTask_Closed(object? sender, EventArgs e) {
            update = null;
            ReLoadTasks(LoggedInUser);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e) {
            if ( addTask == null || !addTask.IsVisible ) {
                addTask = new AddTask(LoggedInUser);
                addTask.Closed += AddTask_Closed;
                addTask.Show();
            } else {
                addTask.Activate();
            }
        }
        private AddTask addTask;
        private void AddTask_Closed(object sender, EventArgs e) {
            addTask = null;
            ReLoadTasks(LoggedInUser);
        }
        private string checkInput(string input) {
            input = input.Trim();
            input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");

            return input;
        }
        private int? checkPriority(string priority) {
            int parsedPriority;
            if ( int.TryParse(priority, out parsedPriority) ) {
                if ( parsedPriority >= 1 && parsedPriority <= 3 ) {
                    return parsedPriority;
                } else {
                    return null;
                }
            } else {
                return null;
            }
        }
        private int? checkInt(string priority) {
            int parsedPriority;
            if ( int.TryParse(priority, out parsedPriority) ) {
                if ( parsedPriority >= 1 ) {
                    return parsedPriority;
                } else {
                    return null;
                }

            } else {
                return null;
            }
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e) {
            try {
                Button button = sender as Button;
                int taskId = (int)button.CommandParameter;

                Models.Task task = data.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if ( task != null ) {
                    if ( task.UserId == LoggedInUser.UserId ) {
                        MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa Task này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if ( result == MessageBoxResult.Yes ) {
                            data.Tasks.Remove(task);
                            if ( data.SaveChanges() > 0 ) {
                                MessageBox.Show("Delete success");
                                ReLoadTasks(LoggedInUser);
                            }
                        }
                    } else {
                        MessageBox.Show("Bạn không có quyền truy cập vào Task này!");
                    }

                } else {
                    MessageBox.Show("Task không tồn tại");
                }
            } catch ( Exception ex ) {
                MessageBox.Show("Cannot delete!");
            }
        }
        private DetailsTask details;
        private TimeLeft timeLeft;
        private void ButtonDetails_Click(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            int taskId = (int)button.CommandParameter;
            Models.Task task = data.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if ( task != null ) {
                if ( task.UserId == LoggedInUser.UserId ) {
                    if ( details == null || !details.IsVisible ) {
                        details = new DetailsTask(task, LoggedInUser);
                        details.Closed += DetailsTask_Close;
                        details.Show();
                    } else {
                        details.Activate();
                    }
                } else {
                    MessageBox.Show("Bạn không có quyền truy cập vào Task này!");
                }
            } else {
                MessageBox.Show("Bạn không có quyền truy cập vào Task này!");
            }

        }
        private void DetailsTask_Close(object? sender, EventArgs e) {
            details = null;
        }
        private void ButtonPending_Click(object sender, RoutedEventArgs e) {
            var Tdata = data.Tasks
                .Where(t => t.UserId == LoggedInUser.UserId && t.Status.Equals("Pending"))
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;
        }
        private void ButtonFinished_Click(object sender, RoutedEventArgs e) {
            var Tdata = data.Tasks
                .Where(t => t.UserId == LoggedInUser.UserId && t.Status.Equals("Done"))
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;
        }
        private void ButtonSearch_Click(object sender, RoutedEventArgs e) {
            String search = txtSearch.Text.ToLower();
            var Tdata = data.Tasks
                .Where(t => t.UserId == LoggedInUser.UserId && t.Title.ToLower().Contains(search)).ToList()
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderByDescending(t => t.Status)
                .ThenBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;
        }
        private DispatcherTimer searchTimer;
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) {
            searchTimer.Stop();
            searchTimer.Start();
        }
        private void SearchTimer_Tick(object sender, EventArgs e) {
            searchTimer.Stop();
            Search(txtSearch.Text);
        }
        private void Search(string search) {
            search = txtSearch.Text.ToLower();
            var Tdata = data.Tasks
                .Where(t => t.UserId == LoggedInUser.UserId && t.Title.ToLower().Contains(search)).ToList()
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderByDescending(t => t.Status)
                .ThenBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;
        }
        private void ButtonExpired_Click(object sender, RoutedEventArgs e) {
            var Tdata = data.Tasks
                .Where(t => t.UserId == LoggedInUser.UserId && t.Status.Equals("Expired"))
                .Select(t => new {
                    Id = t.TaskId,
                    Title = t.Title,
                    Status = t.Status,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                }).OrderBy(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToList();
            dgTask.ItemsSource = Tdata;
        }

        private void ButtonTime_Click(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            int taskId = (int)button.CommandParameter;
            Models.Task task = data.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if ( task != null ) {
                if ( task.UserId == LoggedInUser.UserId ) {
                    if ( timeLeft == null || !timeLeft.IsVisible ) {
                        timeLeft = new TimeLeft(task, LoggedInUser);
                        timeLeft.Closed += DetailsTask_Close;
                        timeLeft.Show();
                    } else {
                        timeLeft.Activate();
                    }
                } else {
                    MessageBox.Show("Bạn không có quyền truy cập vào Task này!");
                }
            } else {
                MessageBox.Show("Bạn không có quyền truy cập vào Task này!");
            }

        }

    }
}