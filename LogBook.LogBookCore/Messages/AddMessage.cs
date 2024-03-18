using CommunityToolkit.Mvvm.Messaging.Messages;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogBookCore.Messages
{
    public class AddMessage : ValueChangedMessage<Entry>
    {


        public AddMessage(Entry value) : base(value)
        {
            
        }
    }
}
