using DryIoc;
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
        private IDatabase _database;
        private INavigationService _navigationService;
        public DelegateCommand AddNewTaskCommand { get; private set; }
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
                    _navigationService.NavigateAsync("DetailedTaskView", navParams);
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


        public MainPageViewModel(INavigationService navigationService, IContainer container)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _database = container.Resolve<IDatabase>();

            try
            {
                LoadListAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }

            Title = "The TODO list ";

            AddNewTaskCommand = new DelegateCommand(AddNewTaskExecute, CanAddNewTask);    
        }

        void AddNewTaskExecute()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Adding", TaskList);

            _navigationService.NavigateAsync("AddNewTaskView", navParams);
        }

        bool CanAddNewTask() => true;

        async void LoadListAsync()
        {
            try
            {
                List<Tasks> tmp = await _database.GetTaskAsync();
                TaskList = new ObservableCollection<Tasks>(tmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

