using Dima.Core.Enums;

namespace Dima.Core.Models
{
    public class PaymentType
    {
        public long Id { get; set; }
        public string CardName { get; set; } = string.Empty;
        public ECardType CardType { get; set; } = ECardType.Debit;
        public string UserId { get; set; } = string.Empty;
    }
}
