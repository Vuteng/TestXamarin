using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand AddNewTaskCommand { get; private set; }

        private ObservableCollection<Task> _taskList;
        public ObservableCollection<Task> TaskList
        {
            get { return _taskList; }
            set
            {
                if (_taskList != value)
                {
                    _taskList = value;
                    OnPropertyChanged("TaskList");
                }
            }
        }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            TaskList = new ObservableCollection<Task>();

            Title = "The TODO list ";

            AddNewTaskCommand = new DelegateCommand(AddNewTaskExecute, CanAddNewTask);

            TaskList.Add(new Task("Skuhaj kosilo", new DateTime(2022, 4, 20)));
            TaskList.Add(new Task("Skuhaj kosilo", new DateTime(2022, 4, 20)));
            TaskList.Add(new Task("Skuhaj kosilo", new DateTime(2022, 4, 20)));
            TaskList.Add(new Task("Skuhaj kosiloSkuhaj kosilo", new DateTime(2022, 4, 20)));
        }

        void AddNewTaskExecute()
        {

        }

        bool CanAddNewTask()
        {
            return true;
        }
    }
}

