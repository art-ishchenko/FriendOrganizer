using FriendOrganizer.Model;
using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errorsByProperty = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public FriendWrapper(Friend friend)
        {
            Model = friend;
        }

        public bool HasErrors => errorsByProperty.Any();
        public Friend Model { get; }

        public int Id
        {
            get
            {
                return Model.Id;
            }
        }

        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty();
            }
        }

        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return Model.Email;
            }
            set
            {
                Model.Email = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return errorsByProperty.ContainsKey(propertyName)
                ? errorsByProperty[propertyName]
                : null;
        }

        private void ValidateProperty([CallerMemberName]string propertyName = null)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (FirstName.Equals("Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        AddError(propertyName, "Robots are not valid friends");
                    }
                    break;
            }
        }

        private void AddError(string propertyName, string error)
        {
            if (!errorsByProperty.ContainsKey(propertyName))
                errorsByProperty[propertyName] = new List<string>();

            if (!errorsByProperty[propertyName].Contains(error))
            {
                errorsByProperty[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (errorsByProperty.ContainsKey(propertyName))
            {
                errorsByProperty.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
