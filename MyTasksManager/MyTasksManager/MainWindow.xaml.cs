using MyTasksManager.Actions;
using MyTasksManager.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            LoadPage();
        }

        private void LoadPage()
        {
            List<TaskModel> tasks = new TaskFetch(new DbRepository.Task.GetTasks()).GetAllTasks();

            foreach(var task in tasks)
            {
                AddCard(task);
            }
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
            string dueDate = TaskDue.SelectedDate.HasValue?TaskDue.SelectedDate.Value.ToString():null;

            TaskModel task = new TaskCreation(new DbRepository.Task.CreateTask()).CreateTask(taskName, description, dueDate);

            if(task == null) { return; }

            AddCard(task);

            taskPopUp.IsOpen = false;
        }

        public void AddCard(TaskModel task)
        {
            //create outer border
            Border border = new Border();
            border.Height = 150;
            border.Width = 200;
            border.BorderThickness = new Thickness(1, 1, 1, 2);
            border.BorderBrush = Brushes.Gainsboro;
            border.Margin = new Thickness(0, 10, 10, 0);

            //create inner grid
            Grid grid = new Grid();
            grid.Height = 150;
            grid.Width = 200;
            grid.Margin = new Thickness(0, 10, 10, 0);

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            
            gridCol1.Width = new GridLength(2, GridUnitType.Star);
            gridCol1.Width = new GridLength(2, GridUnitType.Star);

            grid.ColumnDefinitions.Add(gridCol1);
            grid.ColumnDefinitions.Add(gridCol2);

            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();
            RowDefinition gridRow3 = new RowDefinition();
            RowDefinition gridRow4 = new RowDefinition();
            RowDefinition gridRow5 = new RowDefinition();

            grid.RowDefinitions.Add(gridRow1);
            grid.RowDefinitions.Add(gridRow2);
            grid.RowDefinitions.Add(gridRow3);
            grid.RowDefinitions.Add(gridRow4);
            grid.RowDefinitions.Add(gridRow5);

            //Create body
            TextBlock due = new TextBlock();
            due.Text = task.DateTimeDue??"n/a";
            due.SetValue(Grid.RowProperty, 0);
            due.SetValue(Grid.ColumnProperty, 1);

            TextBlock name = new TextBlock();
            name.Text = task.TaskName;
            name.SetValue(Grid.RowProperty, 1);
            name.SetValue(Grid.ColumnSpanProperty, 2);

            TextBlock description = new TextBlock();
            description.TextWrapping = TextWrapping.Wrap;
            description.Text = task.Description;
            name.SetValue(Grid.RowProperty, 2);
            name.SetValue(Grid.ColumnSpanProperty, 2);
            name.SetValue(Grid.RowSpanProperty, 2);

            TextBlock status = new TextBlock();
            status.Text = task.Status.ToString();
            status.SetValue(Grid.RowProperty, 4);
            status.SetValue(Grid.ColumnProperty, 0);

            //compose
            grid.Children.Add(due);
            grid.Children.Add(name);
            grid.Children.Add(description);
            grid.Children.Add(status);

            border.Child = grid;
            Todo.Children.Add(border);
        }
    }
}
