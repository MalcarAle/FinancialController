using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Responses;
using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Dima.Core.Requests.PaymentTypeRequest;

namespace Dima.Api.Handlers.PaymentTypeHandler
{
    public class PaymentTypeHandler(AppDbContext context) : IPaymentTypeHandler
    {
        public async Task<Response<PaymentType?>> CreateAsync(CreatePaymentTypeRequest request)
        {
            try
            {
                var paymentType = new PaymentType
                {
                    UserId = request.UserId,
                    CardName = request.CardName,
                    CardType = request.CardType,
                };

                await context.AddAsync(paymentType);
                await context.SaveChangesAsync();

                return new Response<PaymentType?>(paymentType, 201, "Cartão cadastrado com sucesso!");
            }
            catch
            {
                return new Response<PaymentType?>(null, 500, "Erro ao cadastrar cartão");
            }
        }

        public async Task<Response<PaymentType?>> DeleteAsync(DeletePaymentTypeRequest request)
        {
            try
            {
                var paymentType = await context
                    .PaymentTypes
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (paymentType is null)
                    return new Response<PaymentType?>(null, 404, "Método de pagamento não encontrado!");

                context.PaymentTypes.Remove(paymentType);
                await context.SaveChangesAsync();

                return new Response<PaymentType?>(paymentType, message: "Método de pagamento deletado com sucesso");
            }
            catch
            {
                return new Response<PaymentType?>(null, 500, "Erro ao deletar Método de pagamento");

            }
        }

        public async Task<PagedResponse<List<PaymentType>>> GetAllAsync(GetAllPaymentTypeRequest request)
        {
            try
            {
                var query = context
                    .PaymentTypes
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Id);

                var paymentsType = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<PaymentType>>(
                    paymentsType,
                    count,
                    request.PageNumber,
                    request.PageSize);

            }
            catch
            {
                return new PagedResponse<List<PaymentType>>(null, 500, "Erro ao recuperar os metodos de pagamentos");
            }
        }

        public async Task<Response<PaymentType?>> GetByIdAsync(GetPaymentTypeByIdRequest request)
        {
            try
            {
                var paymentType = await context
                    .PaymentTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return paymentType is null
                    ? new Response<PaymentType?>(null, 404, "Método de pagamento não encontrado")
                    : new Response<PaymentType?>(paymentType);

            }
            catch
            {
                return new Response<PaymentType?>(null, 500, "Erro ao recuperar metodo de pagamento");
            }
        }

        public async Task<Response<PaymentType?>> UpdateAsync(UpdatePaymentTypeRequest request)
        {
            try
            {
                var paymentType = await context
                    .PaymentTypes
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (paymentType is null)
                    return new Response<PaymentType?>(null, 404, "Método de pagamento não encontrado");

                paymentType.CardName = request.CardName;
                paymentType.CardType = request.CardType;

                context.PaymentTypes.Update(paymentType);
                await context.SaveChangesAsync();

                return new Response<PaymentType?>(paymentType, message: "Método de pagamento atualizado");
            }
            catch
            {
                return new Response<PaymentType?>(null, 500, "Erro ao atualizar metodo de pagamento");
            }
        }
    }
}
