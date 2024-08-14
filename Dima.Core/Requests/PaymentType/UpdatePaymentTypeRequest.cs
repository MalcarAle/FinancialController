using Dima.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.PaymentType
{
    public class UpdatePaymentTypeRequest : Request
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome inválido")]
        [MaxLength(50, ErrorMessage = "Nome do cartão deve conter até 50 caracteres")]
        public string CardName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo inválido")]
        public ECardType CardType { get; set; }
    }
}
