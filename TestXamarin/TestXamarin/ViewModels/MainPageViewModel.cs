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
        private INavigationService _navigationService;
        public DelegateCommand AddNewTaskCommand { get; private set; }
        public DelegateCommand ItemTappedCommand { get; private set; }
        private ObservableCollection<Tasks> _taskList;

        Tasks _selectedTask;
        
        public Tasks SelectedTask
        {
            get => _selectedTask;
            set
            {
                if(value != null)
                {
                    var navParams = new NavigationParameters();
                    navParams.Add("DetailedView", value);
                    navParams.Add("List", TaskList);
                    _navigationService.NavigateAsync("AddNewTaskView", navParams);
                    value = null;
                }
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }


        public ObservableCollection<Tasks> TaskList
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
            _navigationService = navigationService;

            TaskList = new ObservableCollection<Tasks>();

            Title = "The TODO list ";

            AddNewTaskCommand = new DelegateCommand(AddNewTaskExecute, CanAddNewTask);
            ItemTappedCommand = new DelegateCommand(ItemTappedExecute, CanItemTap);

            TaskList.Add(new Tasks(TaskList.Count + 1, "Skuhaj kosilo","", new DateTime(2022, 4, 20)));
            TaskList.Add(new Tasks(TaskList.Count + 1, "Skuhaj kosilo", "", new DateTime(2022, 4, 20)));
            TaskList.Add(new Tasks(TaskList.Count + 1, "Skuhaj kosilo", "", new DateTime(2022, 4, 20)));
            TaskList.Add(new Tasks(TaskList.Count + 1, "Skuhaj kosiloSkuhaj kosilo", "", new DateTime(2022, 4, 20)));

        }

        void AddNewTaskExecute()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Adding", TaskList);

            _navigationService.NavigateAsync("AddNewTaskView", navParams);
        }

        bool CanAddNewTask() => true;
        void ItemTappedExecute()
        {
            Console.WriteLine("ala");
        }

        bool CanItemTap() => true;
    }
}

