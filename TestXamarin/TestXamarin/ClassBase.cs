﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestXamarin
{
    public class ClassBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
