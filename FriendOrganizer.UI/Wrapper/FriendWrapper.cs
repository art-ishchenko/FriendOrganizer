using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend friend) : base(friend)
        {
        }

        public int Id
        {
            get
            {
                return GetValue<int>();
            }
        }

        public string FirstName
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue<string>(value);
            }
        }

        public string LastName
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue<string>(value);
            }
        }

        public string Email
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue<string>(value);
            }
        }

        protected override IEnumerable<string> ValidateCustomErrors(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (FirstName.Equals("Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid friends";
                    }
                    break;
            }
        }
    }
}
