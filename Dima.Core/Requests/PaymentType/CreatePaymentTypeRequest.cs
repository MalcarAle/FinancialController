using Dima.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.PaymentType
{
    public class CreatePaymentTypeRequest : Request
    {
        [Required(ErrorMessage = "Nome inválido")]
        public string CardName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo inválido")]
        public ECardType CardType { get; set; } = ECardType.Debit;
    }
}
