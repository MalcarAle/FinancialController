using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.PaymentTypeRequest
{
    public class GetAllPaymentTypeRequest : PagedRequest
    {
        public long Id { get; set; }
    }
}
