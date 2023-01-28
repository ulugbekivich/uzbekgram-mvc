using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzbekgram.Service.Interfaces.Common;
public interface IIdentityService
{
    public long? Id { get; }

    public string FullName { get; }

    public string Email { get; }

    public string ImagePath { get; }

    public string Status { get; }
}
