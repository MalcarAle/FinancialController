namespace Dima.Core.Requests.Order
{
    public class ConfirmOrderRequest : Request
    {
        public string Number { get; set; } = string.Empty;
    }
}
