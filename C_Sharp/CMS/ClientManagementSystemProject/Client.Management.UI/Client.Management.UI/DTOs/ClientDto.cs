using Client.Management.UI.NotifyPropertiesOnChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Management.UI.DTOs
{
    public class ClientDto : BaseNotifyPropertyChange
    {
        private string _firstName = string.Empty;

        public string FirstName 
        { 
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string? _lastName;

        public string? LastName 
        { 
            get
            {
                return _lastName;
            }
            set
            {
                this._lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _email = string.Empty;

        public string Email 
        { 
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _phone = string.Empty;

        public string Phone 
        { 
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string? _address;

        public string? Address 
        { 
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}
