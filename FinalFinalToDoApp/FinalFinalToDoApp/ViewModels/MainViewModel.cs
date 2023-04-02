using FinalFinalToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinalFinalToDoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TodoTask> _deletedTasks;
        public ObservableCollection<TodoTask> DeletedTasks
        {
            get { return _deletedTasks; }
            set { SetProperty(ref _deletedTasks, value); }

        }




        private ObservableCollection<TodoTask> _tasks;
        public ObservableCollection<TodoTask> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        private string _todo;

        public string IsDone
        {
            get { return _todo; }
            set { SetProperty(ref _todo, value); }
        }





        private string _newTaskText;
        public string NewTaskText
        {
            get { return _newTaskText; }
            set { SetProperty(ref _newTaskText, value); }
        }

        public string Title { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand RemoveTaskCommand { get; set; }

        private string _taskStatus;
        public string TaskStatus
        {

            get { return _taskStatus; }
            set { 
                
                SetProperty(ref _taskStatus, value);

               
            }


        }




        public MainViewModel()
        {
            Tasks = new ObservableCollection<TodoTask>();



            DeletedTasks = new ObservableCollection<TodoTask>();


            AddTaskCommand = new Command(ExecuteAddTasksCommand);
            RemoveTaskCommand = new Command(ExecuteRemoveTaskCommand);

        }

        public void ExecuteAddTasksCommand()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskText))
            {
                var newItem = new TodoTask { Text = NewTaskText };


                Tasks.Add(newItem);


            }
        }

        private TodoTask _selectedTask;
        public TodoTask SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        private void ExecuteRemoveTaskCommand()
        {

            Tasks.Remove(SelectedTask);

            if (SelectedTask != null)
            {



                DeletedTasks.Add(SelectedTask);


            }
            SelectedTask = null;


        }



    }

}

