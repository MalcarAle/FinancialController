﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.PaymentType
{
    public class DeletePaymentTypeRequest : Request
    {
        public long Id { get; set; }
    }
}
