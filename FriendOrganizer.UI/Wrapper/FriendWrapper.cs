using FriendOrganizer.Model;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : NotifyDataInfoErrorBase
    {
        public FriendWrapper(Friend friend)
        {
            Model = friend;
        }

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
    }
}
