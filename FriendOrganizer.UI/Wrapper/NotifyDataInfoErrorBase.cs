using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FriendOrganizer.UI.Wrapper
{
    public class NotifyDataInfoErrorBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errorsByProperty = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => errorsByProperty.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return errorsByProperty.ContainsKey(propertyName)
                ? errorsByProperty[propertyName]
                : null;
        }

        protected void AddError(string propertyName, string error)
        {
            if (!errorsByProperty.ContainsKey(propertyName))
                errorsByProperty[propertyName] = new List<string>();

            if (!errorsByProperty[propertyName].Contains(error))
            {
                errorsByProperty[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (errorsByProperty.ContainsKey(propertyName))
            {
                errorsByProperty.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors)); 
        }
    }

}
