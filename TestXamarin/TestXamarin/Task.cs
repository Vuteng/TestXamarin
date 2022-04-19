using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TestXamarin.ViewModels;

namespace TestXamarin
{
    public class Task : ClassBase
    {
        private string _description;
        private DateTime _dueDate;

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

        public Task(string desc, DateTime dateTime)
        {
            Description = desc;
            DueDate = dateTime;
        }

    }
}
