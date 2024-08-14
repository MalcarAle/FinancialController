using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Stripe
{
    public class CreateSessionRequest : Request
    {
        public string OrderNumber { get; set; } = string.Empty;
    }
}
