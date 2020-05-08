using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.Wrapper
{
    public class ModelWrapper<T> : NotifyDataInfoErrorBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }

        public T Model { get; }

        protected TValue GetValue<TValue>([CallerMemberName]string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected void SetValue<TValue>(TValue value, [CallerMemberName]string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value);
        }

        private void ValidatePropertyInternal(string propertyName, object propertyValue)
        {
            ClearErrors(propertyName);

            IEnumerable<string> errors = ValidateDataAnnotations(propertyName, propertyValue)
                .Union(ValidateCustomErrors(propertyName));

            if (errors != null)
            {
                foreach (string error in errors)
                    AddError(propertyName, error);
            }
        }

        private IEnumerable<string> ValidateDataAnnotations(string propertyName, object propertyValue)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(Model) { MemberName = propertyName };
            Validator.TryValidateProperty(propertyValue, context, results);
            return results.Select(x => x.ErrorMessage);
        }

        protected virtual IEnumerable<string> ValidateCustomErrors(string propertyName)
        {
            return null;
        }
    }
}
