using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Messages
{
    public class AddProductMessage : ValueChangedMessage<int>
    {
        public AddProductMessage(int count) : base(count)
        {
        }
    }
}
