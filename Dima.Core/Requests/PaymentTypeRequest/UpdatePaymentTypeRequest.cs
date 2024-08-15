using Dima.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.PaymentTypeRequest
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
