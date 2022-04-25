using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarin.ViewModels
{
    public class AddNewTaskViewModel : ViewModelBase
    {
        
        public AddNewTaskViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Add new task";
        }
    }
}
