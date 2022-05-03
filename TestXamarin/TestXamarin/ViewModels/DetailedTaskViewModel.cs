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
    public class DetailedTaskViewModel : ViewModelBase
    {
        Tasks _selectedTask;
        INavigationService _navigationService;
        private static IDatabase _database;
        private ObservableCollection<Tasks> _taskList;
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }
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

        public DetailedTaskViewModel(INavigationService navigationService, IContainer container) : base(navigationService)
        {
            UpdateCommand = new DelegateCommand(UpdateExecute, CanUpdate);

            DeleteCommand = new DelegateCommand(DeleteExecute, CanDelete);
            _navigationService = navigationService;
            _database = container.Resolve<IDatabase>();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters == null)
                return;

            SelectedTask = (Tasks)parameters["DetailedView"];
            TaskList = (ObservableCollection<Tasks>)parameters["List"];
        }

        void DeleteExecute()
        {
            try
            {
                _database.DeleteTaskAsync(_selectedTask);
                TaskList.Remove(_selectedTask);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

            _navigationService.GoBackAsync();
        }
        bool CanDelete() => true;
        void UpdateExecute()
        {
            try
            {
                _database.SaveTaskAsync(_selectedTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _navigationService.GoBackAsync();

        }
        bool CanUpdate() => true;
    }
}
