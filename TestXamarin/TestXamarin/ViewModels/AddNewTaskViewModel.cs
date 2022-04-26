using Android.Opengl;
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
        Tasks _selectedTask;
        INavigationService _navigationService;
        bool _adding;
        bool _deleting;

        private string _description;
        private string _details;
        private DateTime _dueDate;
        private ObservableCollection<Tasks> _taskList;
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

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

        public bool Adding
        {
            get { return _adding; }
            set
            {
                if (_adding != value)
                {
                    _adding = value;
                    OnPropertyChanged("Adding");
                }
            }
        }
        public bool Deleting
        {
            get { return _deleting; }
            set
            {
                if (_deleting != value)
                {
                    _deleting = value;
                    OnPropertyChanged("Deleting");
                }
            }
        }

        public Tasks SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged("SelectedTask");
                }
            }
        }

        public AddNewTaskViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddCommand = new DelegateCommand(AddExecute, CanAdd);
            DeleteCommand = new DelegateCommand(DeleteExecute, CanDelete);
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
                return;

            if (parameters.ContainsKey("Adding"))
            {
                TaskList = (ObservableCollection<Tasks>)parameters["Adding"];
                Deleting = false;
                Adding = true;

            }
            else if(parameters.ContainsKey("DetailedView"))
            {
                SelectedTask = (Tasks)parameters["DetailedView"];
                TaskList = (ObservableCollection<Tasks>)parameters["List"];

                Deleting = true;
                Adding = false;
            }
        }


        void AddExecute()
        {
            TaskList.Add(new Tasks(TaskList.Count + 1, Description, Details, DueDate)) ;

            _navigationService.GoBackAsync();
        }

        bool CanAdd() => true; 
        void DeleteExecute()
        {

            TaskList.Remove(_selectedTask);

            _navigationService.GoBackAsync();
        }

        bool CanDelete() => true;
    }
}

