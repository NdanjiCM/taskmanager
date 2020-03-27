using MyTasksManager.Actions;
using MyTasksManager.Models;
using System;
using System.Windows;

namespace MyTasksManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskName.Clear();
            TaskDescription.Clear();
            TaskDue.DisplayDate = DateTime.Now;
            taskPopUp.IsOpen = true;
        }

        private void Save_Task(object sender, RoutedEventArgs e)
        {
            string taskName = TaskName.Text;
            string description = TaskDescription.Text;

            TaskModel task = new TaskCreation(new DbRepository.Task.CreateTask()).CreateTask(taskName, description, null);

            if(task == null) { return; }

            //create physical card

            taskPopUp.IsOpen = false;
        }
    }
}
