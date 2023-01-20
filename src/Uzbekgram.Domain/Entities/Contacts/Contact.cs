using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Common;
using Uzbekgram.Domain.Entities.Users;

namespace Uzbekgram.Domain.Entities.Contacts
{
    public class Contact : Audiable
    {
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public long FriendId { get; set; }
        public virtual User Friend { get; set; } = default!;
    }
}
