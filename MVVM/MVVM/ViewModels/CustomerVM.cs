using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;
using MVVM.Commands;
using System.Windows;

namespace MVVM.ViewModels
{
    class CustomerVM
    {
        private Customer _Customer;
        public CustomerVM()
        {
            _Customer = new Customer("Tibo");
            UpdateCommand = new CustomerUpdateCommand(this);
        }


        /*
         * This is the canUpdate validation also called by the customerupdatecommand class;
         */
        public bool CanUpdate
        {
            get
            {
                if (_Customer == null)
                {
                    return false;
                }
                return !string.IsNullOrWhiteSpace(_Customer.Name);
            }
        }

        public Customer Customer { get { return _Customer; } }

        /*
         * This method gets called by the customerupdatecommand class;
         * 
         */
        public void SaveChanges()
        {
            MessageBox.Show(string.Format("{0} has been updated", _Customer.Name), "Operation sucessfull");
        }


        /*
         * This is the UpdateCommand 
         */
        public ICommand UpdateCommand
        {
            get;
            private set;
        }

    }
}
