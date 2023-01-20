using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Common;
using Uzbekgram.Domain.Entities.Users;

namespace Uzbekgram.Domain.Entities.Messages
{
    public class MediaMessage : Audiable
    {
        public long SenderId { get; set; }
        public virtual User Sender { get; set; } = default!;
        public long ReceiverId { get; set; }
        public virtual User Receiver { get; set; } = default!;

        public string MediaPath { get; set; } = string.Empty;
    }
}
