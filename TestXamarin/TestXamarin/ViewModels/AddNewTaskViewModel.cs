﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestXamarin.ViewModels
{
    public class AddNewTaskViewModel : ViewModelBase
    {
        private string _description;
        private string _details;
        private DateTime _dueDate;
        Task _selectedTask;
        INavigationService _navigationService;

        private ObservableCollection<Task> _taskList;
        public DelegateCommand AddCommand { get; private set; }

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

        public AddNewTaskViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddCommand = new DelegateCommand(AddExecute, CanAdd);
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
                return;

            if (parameters.ContainsKey("Adding"))
            {
                TaskList = (ObservableCollection<Task>)parameters["Adding"];

            }
            else if(parameters.ContainsKey("DetailedView"))
            {
                _selectedTask = (Task)parameters["DetailedView"];
                Description = _selectedTask.Description;
                Details = _selectedTask.Details;
                DueDate = _selectedTask.DueDate;
            }
        }


        void AddExecute()
        {
            Console.WriteLine(Description + " " + Details + "  " + DueDate.ToString());
            TaskList.Add(new Task(Description, Details, DueDate));
            _navigationService.GoBackAsync();

        }

        bool CanAdd() => true;
    }
}

