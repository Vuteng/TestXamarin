using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TestXamarin.ViewModels;

namespace TestXamarin
{
    public class Tasks : ClassBase, ITasks
    {
        public int _id;
        public string _description;
        public DateTime _dueDate;
        private string _details;

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

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public Tasks()
        {

        }

        public Tasks(string desc, string details, DateTime dateTime)
        {
            Description = desc;
            DueDate = dateTime;
            Details = details;
        }

    }
}
