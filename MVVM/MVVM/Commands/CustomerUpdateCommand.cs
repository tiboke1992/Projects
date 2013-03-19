using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Commands
{
    class CustomerUpdateCommand : ICommand
    {
        public CustomerUpdateCommand(CustomerVM viewmodel)
        {
            _ViewModel = viewmodel;
        }
        private CustomerVM _ViewModel;

        /*
         * Does something to;
         */
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /*
         * This method returns wether the button can be klicked or not so, true or false;
         */
        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        /*
        * This method is called on execute it will call the SaveChanges method of the viewmodel
        */
        public void Execute(object parameter)
        {
            _ViewModel.SaveChanges();
        }
    }
}
