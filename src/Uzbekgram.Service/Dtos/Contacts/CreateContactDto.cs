using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.Contacts
{
    public class CreateContactDto
    {
        [Required, Integer]
        public long FriendId { get; set; }
    }
}
