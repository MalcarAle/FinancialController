using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;

namespace Dima.Core.Handlers
{
    public interface IPaymentTypeHandler
    {
        Task<Response<PaymentType?>> CreateAsync(CreatePaymentTypeRequest request);
        Task<Response<PaymentType?>> UpdateAsync(UpdatePaymentTypeRequest request);
        Task<Response<PaymentType?>> DeleteAsync(DeletePaymentTypeRequest request);
        Task<PagedResponse<List<PaymentType>>> GetAllAsync(GetAllPaymentTypeRequest request);
        Task<Response<PaymentType?>> GetByIdAsync(GetPaymentTypeByIdRequest request);
    }
}
