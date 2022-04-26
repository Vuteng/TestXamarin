using Android.Opengl;
using DryIoc;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestXamarin.ViewModels
{
    public class AddNewTaskViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        IContainer _container;
        private static IDatabase _database;
        private string _description;
        private string _details;
        private DateTime _dueDate;
        private ObservableCollection<Tasks> _taskList;
        public DelegateCommand AddCommand { get; private set; } 
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
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged("Details");
                }
            }
        }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged("DueDate");
                }
            }
        }

      
        public AddNewTaskViewModel(INavigationService navigationService, IContainer container) : base(navigationService)
        {
            AddCommand = new DelegateCommand(AddExecute, CanAdd);
            _navigationService = navigationService;
            _database = container.Resolve<IDatabase>(); 
            _container = container;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
                return;

            TaskList = (ObservableCollection<Tasks>)parameters["Adding"];      
        }


        void AddExecute()
        {
            Tasks helperTask = (Tasks)_container.Resolve<ITasks>();
            helperTask.Description = Description;
            helperTask.Details = Details;
            helperTask.DueDate = DueDate;

            TaskList.Add(helperTask);
            try
            {
                _database.SaveTaskAsync(TaskList[TaskList.Count - 1]);
            }catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            _navigationService.GoBackAsync();
        }

        bool CanAdd() => true; 
      
    }
}

