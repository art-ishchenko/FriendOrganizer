using FriendOrganizer.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendOrganizer.UI.Event
{
    public class FriendSavedEvent : PubSubEvent<Friend>
    {
    }
}
